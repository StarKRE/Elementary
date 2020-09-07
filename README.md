# Elementary
[![GitHub license](https://img.shields.io/badge/license-Apache%20License%202.0-blue.svg?style=flat)](https://www.apache.org/licenses/LICENSE-2.0)
[![Download](https://img.shields.io/github/downloads/StarKRE/Elementary/v.1.6/total?color=green&label=download%20v.1.6)](https://github.com/StarKRE/Elementary/releases/download/v.1.6/Elementary.unitypackage)

---

### How to start with Unity?
1. [Download](https://github.com/StarKRE/Elementary/releases/download/v.1.6/Elementary.unitypackage) the library
2. Import Elementary.unitypackage
3. Create a **GameObject** on scene and add **MainScript.cs**

```csharp
using Elementary;
using UnityEngine;

public sealed class MainScript : MonoBehaviour
{
    public static IElementContext ElementContext = new ElementContext();
    
    private void Start()
    {
        ElementContext.Initialize();
    }
}
```

---

### Example: Compose a sample application
![image](https://user-images.githubusercontent.com/22048950/89481366-3b6d9d00-d7a0-11ea-9af1-4e7938d68596.png)

### I. Create the root application class
1. Create **MyApplication** class
```csharp
using Elementary;
using UnityEngine;

[Using]
public sealed class MyApplication : Element, IRootElement
{
    //OnCreate is called after constructor
    protected override void OnCreate(Element _, IElementContext context)
    {
        Debug.Log("Hello world!");
    }
}
```
- [**[Using]**](https://github.com/StarKRE/Elementary/blob/master/Attribute/Using.cs) - Only classes annotated this attribute can be **instantiated**
- [**Element**](https://github.com/StarKRE/Elementary/blob/master/Element.cs) - A **base class** of element context.
- [**IRootElement**](https://github.com/StarKRE/Elementary/blob/master/IRootElement.cs) - **Main elements** of the context that is created automatically.

2. **Play Unity**
> Console:  **Hello world!**

## ✅ DONE!
![image](https://user-images.githubusercontent.com/22048950/89481265-0e20ef00-d7a0-11ea-8761-64765d28b019.png)


---
### II. Create the sample client
1. Create **Client** class
```csharp
using Elementary;
using UnityEngine;

//Let's provide our client by interface for the MyApplication class:
public interface IClient : IElement
{
}

[Using]
public sealed class Client : Element, IClient
{
    protected override void OnCreate(Element _, IElementContext context)
    {
        Debug.Log("Client is created!");
    }
}

```
2. Update **MyApplication.cs**
```csharp
using Elementary;

[Using]
public sealed class MyApplication : Element, IRootElement
{
    public IClient Client { get; private set; }
    
    //OnCreate is called after constructor
    protected override void OnCreate(Element _, IElementContext context)
    {
        Debug.Log("Hello world!");
        this.Client = this.CreateElement<IClient>(typeof(Client));
    }
}
```
3. **Play Unity**
> Console: **Hello world!**

> Console: **Client is created!**

## ✅ DONE!
![image](https://user-images.githubusercontent.com/22048950/89481452-6526c400-d7a0-11ea-899b-07eb6fea31b8.png)

### III. Create the sample repository layer
1. Create abstract **Repository** class and provide **Client**

```csharp
using Elementary;

public abstract class Repository : Element
{
    protected IClient Client { get; private set; }

    //OnPrepare is called after all elements are created 
    protected override void OnPrepare(Element _)
    {
        //Provide client from MyApplication class
        this.Client = this.GetRootElement<MyApplication>().Client; 
    }
}
```

2. Create some implementations of **Repository** for example

```csharp
using Elementary;
using UnityEngine;

[Using]
public sealed class UserRepository : Repository
{
    protected override void OnCreate(Element _, IElementContext context)
    {
        Debug.Log("UserRepository is created!");
    }
}

[Using]
public sealed class LevelsRepository : Repository
{
    protected override void OnCreate(Element _, IElementContext context)
    {
        Debug.Log("LevelsRepository is created!");
    }
}
```

3. Create **RepositoryLayer** for repositories

```csharp
using Elementary;

//Keeps all repositories
//They are created automatically
[Using]
public sealed class RepositoryLayer : ElementLayer<Repository> 
{
    //Returns a repository. We will use this method by interactors further.
    public T GetRepository<T>() where T : Repository
    {
        return this.GetElement<T>();
    }
}
```

- [**ElementLayer**](https://github.com/StarKRE/Elementary/blob/master/Lib/ElementLayer.cs) - **A dictionary of "T" elements by type**

4. Update **MyApplication.cs**

```csharp
using Elementary;

[Using]
public sealed class MyApplication : Element, IRootElement
{
    public IClient Client { get; private set; }

    public RepositoryLayer RepositoryLayer { get; private set; }
    
    //OnCreate is called after constructor
    protected override void OnCreate(Element _, IElementContext context)
    {
        Debug.Log("Hello world!");
        this.Client = this.CreateElement<IClient>(typeof(Client));
        this.RepositoryLayer = this.CreateElement<RepositoryLayer>(typeof(RepositoryLayer));
    }
}
```

5. **Play Unity**

> Console: **Hello world!**

> Console: **Client is created!**

> Console: **UserRepository is created!**

> Console: **LevelsRepository is created!**

## ✅ DONE!
![image](https://user-images.githubusercontent.com/22048950/89481497-8687b000-d7a0-11ea-9638-70a3c9371884.png)


### IV. Create the sample domain layer
1. Create abstract **Interactor** class and provide **RepositoryLayer**

```csharp
using Elementary;

public abstract class Interactor : Element
{
    private RepositoryLayer repositoryLayer;

    protected override void OnPrepare(Element _)
    {
        //Provide repository layer from MyApplication class
        this.repositoryLayer = this.GetRootElement<MyApplication>().RepositoryLayer;
    }
    
    //We add this method to provide repositories for inherited interactor classes
    protected T GetRepository<T>() where T : Repository
    {
        return this.repositoryLayer.GetRepository<T>();
    }
}
```
2. Create some implementations of **Interactor** for example

```csharp
using Elementary;
using UnityEngine;

[Using]
public sealed class UserInteractor : Interactor
{
    protected override void OnPrepare(Element _)
    {
        var userRepository = this.GetRepository<UserRepository>();
        Debug.Log($"User interactor -> {userRepository.GetType().Name}");
    }
}

[Using]
public sealed class LevelsInteractor : Interactor
{
    protected override void OnPrepare(Element _)
    {
        var levelsRepository = this.GetRepository<LevelsRepository>();
        Debug.Log($"Levels interactor -> {levelsRepository.GetType().Name}");
    }
}
```

3. Update **MyApplication.cs**

```csharp
using System.Collections.Generic;
using Elementary;
using UnityEngine;

[Using]
public sealed class MyApplication : Element, IRootElement
{
    public IClient Client { get; private set; }

    public RepositoryLayer RepositoryLayer { get; private set; }
    
    public IEnumerable<Interactor> Interactors { get; private set; }

    //OnCreate is called after constructor
    protected override void OnCreate(Element _, IElementContext context)
    {
        Debug.Log("Hello world!");
        this.Client = this.CreateElement<IClient>(typeof(Client));
        this.RepositoryLayer = this.CreateElement<RepositoryLayer>(typeof(RepositoryLayer));
        this.Interactors = this.CreateElements<Interactor>();
    }
}
```

4. **Play Unity**

> Console: **Hello world!**

> Console: **Client is created!**

> Console: **UserRepository is created!**

> Console: **LevelsRepository is created!**

> Console: **User interactor -> UserRepository**

> Console: **Levels interactor -> LevelsRepository**

## ✅ ✅ ✅ COMPLETE!
![image](https://user-images.githubusercontent.com/22048950/89481562-ae771380-d7a0-11ea-9a7d-c331d08f9d8f.png)
