# Elementary. Unity Framework
[![GitHub license](https://img.shields.io/badge/license-Apache%20License%202.0-blue.svg?style=flat)](https://www.apache.org/licenses/LICENSE-2.0)
![image](https://img.shields.io/badge/unity-%3E%3D2019.1.8f-lightgrey)
[![Download](https://img.shields.io/github/downloads/StarKRE/Elementary/v.1.4/total?color=green&label=download%20v.1.4)](https://github.com/StarKRE/Elementary/releases/download/v.1.4/Elementary.unitypackage)


### DESIGN YOUR ARCHITECTURE ELEMENTARY

### How to start?
Create a **GameObject** on scene and add **MainScript.cs**:
```csharp
using ElementaryFramework.Core;
using UnityEngine;

public sealed class MainScript : MonoBehaviour
{
    private void Start()
    {
        Elementary.Initialize();
    }
}
```
---

## Create a Simple Game Architecture (Example)
![image](https://user-images.githubusercontent.com/22048950/89131144-48c22780-d513-11ea-9186-78a81ce11d09.png)

### I. Create The Root Application Class
1. Create **MyGame** class
```csharp
using ElementaryFramework.Core;
using UnityEngine;

[Using]
public sealed class MyGame : Element, IRootElement
{
    //OnCreate is called after constructor
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("Hello world!");
    }
}
```
- **[Using]** - **MyGame** class is registered into the framework as **element**
- **Element** - **the base** class of the context
- **IRootElement** - a root element in the system. It is created automatically

2. **Play Unity**
> Console:  **Hello world!**

## ✅ DONE!
![image](https://user-images.githubusercontent.com/22048950/89132169-d5bcaf00-d51a-11ea-9721-47508a2799d2.png)


---
### II. Create The Client
1. Create **Client** class
```csharp
using ElementaryFramework.Core;
using UnityEngine;

public interface IClient : IElement
{
}

[Using]
public sealed class Client : Element, IClient
{
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("Client is created!");
    }
}

```
2. Update **MyGame.cs**
```csharp
using ElementaryFramework.Core;

[Using]
public sealed class MyGame : Element, IRootElement
{
    public IClient client { get; private set; }
    
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("Hello world!");
        this.client = this.CreateElement<IClient>(typeof(Client));
    }
}
```
3. **Play Unity**
> Console: **Hello world!**

> Console: **Client is created!**

## ✅ DONE!
![image](https://user-images.githubusercontent.com/22048950/89132192-14eb0000-d51b-11ea-8801-b2eb18e6f6db.png)

### III. Create The Repository Layer
1. Create abstract **Repository** class and provide **Client**

```csharp
using ElementaryFramework.Core;

public abstract class Repository : Element
{
    protected IClient client { get; private set; }

    //OnPrepare is called after all elements are created 
    public override void OnPrepare()
    {
        base.OnPrepare();
        this.client = this.GetRoot<MyGame>().client; //Provide client
    }
}
```

2. Create some implementations of **Repository** for example

```csharp
using ElementaryFramework.Core;
using UnityEngine;

[Using]
public sealed class UserRepository : Repository
{
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("UserRepository is created!");
    }
}

[Using]
public sealed class LevelsRepository : Repository
{
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("LevelsRepository is created!");
    }
}
```

3. Create **RepositoryLayer** for repositories

```csharp
using ElementaryFramework.Core;

//Keeps all repositories
//They are created automatically
[Using]
public sealed class RepositoryLayer : ElementLayer<Repository> 
{
    //Returns a repository. We will use this method from interactors
    public T GetRepository<T>() where T : Repository
    {
        return this.GetElement<T>();
    }
}
```

4. Update **MyGame.cs**

```csharp
using ElementaryFramework.Core;

[Using]
public sealed class MyGame : Element, IRootElement
{
    public IClient client { get; private set; }

    public RepositoryLayer repositoryLayer { get; private set; }
    
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("Hello world!");
        this.client = this.CreateElement<IClient>(typeof(Client));
        this.repositoryLayer = this.CreateElement<RepositoryLayer>(typeof(RepositoryLayer));
    }
}
```

5. **Play Unity**

> Console: **Hello world!**

> Console: **Client is created!**

> Console: **UserRepository is created!**

> Console: **LevelsRepository is created!**

## ✅ DONE!
![image](https://user-images.githubusercontent.com/22048950/89132224-524f8d80-d51b-11ea-9fa7-5f3795819bcd.png)


### IV. Create The Domain Layer
1. Create abstract **Interactor** class and provide **RepositoryLayer**

```csharp
using ElementaryFramework.Core;

public abstract class Interactor : Element
{
    private RepositoryLayer repositoryLayer;

    public override void OnPrepare()
    {
        base.OnPrepare();
        this.repositoryLayer = this.GetRoot<MyGame>().repositoryLayer;
    }
    
    //We write this method to provide repositories for inherited interactor classes
    protected T GetRepository<T>() where T : Repository
    {
        return this.repositoryLayer.GetRepository<T>();
    }
}
```
2. Create some implementations of **Interactor** for example

```csharp
using ElementaryFramework.Core;
using UnityEngine;


[Using]
public sealed class UserInteractor : Interactor
{
    public override void OnPrepare()
    {
        base.OnPrepare();
        var userRepository = this.GetRepository<UserRepository>();
        Debug.Log($"User interactor get {userRepository.GetType().Name}");
    }
}

[Using]
public sealed class LevelsInteractor : Interactor
{
    public override void OnPrepare()
    {
        base.OnPrepare();
        var levelsRepository = this.GetRepository<LevelsRepository>();
        Debug.Log($"Levels interactor get {levelsRepository.GetType().Name}");
    }
}
```

3. Update **MyGame.cs**

```csharp
using System.Collections.Generic;
using ElementaryFramework.Core;
using UnityEngine;

[Using]
public sealed class MyGame : Element, IRootElement
{
    public IClient client { get; private set; }

    public RepositoryLayer repositoryLayer { get; private set; }
    
    public IEnumerable<Interactor> interactors { get; private set; }
    
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("Hello world!");
        this.client = this.CreateElement<IClient>(typeof(Client));
        this.repositoryLayer = this.CreateElement<RepositoryLayer>(typeof(RepositoryLayer));
        this.interactors = this.CreateElements<Interactor>();
    }
}
```

5. **Play Unity**

> Console: **Hello world!**

> Console: **Client is created!**

> Console: **UserRepository is created!**

> Console: **LevelsRepository is created!**

> Console: **User interactor get UserRepository**

> Console: **Levels interactor get LevelsRepository**

## ✅ ✅ ✅ COMPLETE!
![image](https://user-images.githubusercontent.com/22048950/89132255-9347a200-d51b-11ea-9b76-03ff8b1230f3.png)

