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

Create **MyGame** class
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

**Play Unity**
> Console:  **Hello world!**

---

Create **Client** class
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
Update **MyGame.cs**
```csharp
using ElementaryFramework.Core;

[Using]
public sealed class MyGame : Element, IRootElement
{
    public IClient client { get; private set; }
    
    public override void OnCreate(IElementContext context)
    {
        base.OnCreate(context);
        this.gameManager = this.CreateElement<IClient>(typeof(Client));
    }
}
```
**Play Unity**
> Console: **Client is created!**

### Create Repository Layer



