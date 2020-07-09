# Orego. Unity Framework
[![GitHub license](https://img.shields.io/badge/license-Apache%20License%202.0-blue.svg?style=flat)](https://www.apache.org/licenses/LICENSE-2.0)


### Design Your Architecture

> Library support Unity 2019.1.8f and later.

> [Download v.1.3](https://github.com/StarKRE/Orego/releases/download/v.1.3/Orego.unitypackage)


### How to start?

```csharp
using OregoFramework.Core;
using UnityEngine;

public sealed class MainScript : MonoBehaviour
{
    private void Start()
    {
        Orego.Start();
    }
}
```
---

### Create your First Element

```csharp
using OregoFramework.Core;

[OregoContext]
public sealed class MyApplication : Element
{
}
```

### Add Singleton Interface
Orego creates an instance automatically

```csharp
using OregoFramework.Core;
using UnityEngine;

[OregoContext]
public sealed class MyApplication : Element, ISingletonElement
{
    public void OnBecameSingleton()
    {
        Debug.Log("Hello world!");
    }
}
```

### Add _MainScript.cs_ to your Game Object and play Unity:
>  Hello World!
---

### Create your First Element Layer

For example we create a repository layer:

#### 1.) Create a repository

```csharp
using OregoFramework.Core;
using UnityEngine;

public interface IRepository : IElement
{
}

[OregoContext]
public sealed class UserRepository : Element, IRepository
{
    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("User repository started!");
    }
}
```
#### 2.) Create a repository layer

```csharp
using OregoFramework.Core;

[OregoContext]
public sealed class RepositoryLayer : ElementLayer<IRepository>
{
}
```

#### 3.) Connect the repository layer to the my app

```csharp
using OregoFramework.Core;
using UnityEngine;

[OregoContext]
public sealed class MyApplication : Element, ISingletonElement
{
    private IElement repositoryLayer;
    
    public void OnBecameSingleton()
    {
        Debug.Log("Hello world!");
    }

    public override void OnCreate()
    {
        base.OnCreate();
        this.repositoryLayer = this.CreateElement<IElement>(typeof(RepositoryLayer));
    }
}
```

### Play Unity:
>  Hello World!

>  User repository started!
