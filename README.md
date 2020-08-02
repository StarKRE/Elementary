# Elementary. Unity Framework
[![GitHub license](https://img.shields.io/badge/license-Apache%20License%202.0-blue.svg?style=flat)](https://www.apache.org/licenses/LICENSE-2.0)


### Design your architecture elementary

> Library support Unity 2019.1.8f and later.

> [Download v.1.4](https://github.com/StarKRE/Elementary/releases/download/v.1.4/Elementary.unitypackage)


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

### I. Create Root Application Class
1. Create **MyGame** class
```csharp
using ElementaryFramework.Core;
using UnityEngine;

[Using]
public sealed class MyGame : Element, IRootElement
{
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        Debug.Log("Hello world!");
    }
}
```
- **[Using]** - **MyGame** class is registered into the framework.
- **Element** - the base class.
- **IRootElement** - **MyGame** class is created automatically.
- **OnCreate** is called after constructor.

2. **Play Unity**
> Console:  **Hello world!**

---
### II. Create Client
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

### III. Create Repository Layer
1. Create abstract **Repository** class and provide client

```csharp
using ElementaryFramework.Core;

public abstract class Repository : Element
{
    protected IClient client { get; private set; }

    //OnPrepare is called after all elements are created 
    public override void OnPrepare()
    {
        base.OnPrepare();
        this.client = this.GetRoot<App>().client; //Provide client
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

[Using]
public sealed class RepositoryLayer : ElementLayer<Repository> //Repositories are created automatically
{
}
```

4. Update **MyGame.cs**

```csharp
using ElementaryFramework.Core;

[Using]
public sealed class App : Element, IRootElement
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

