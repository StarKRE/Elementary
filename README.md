# Orego. Unity Framework

[![GitHub license](https://img.shields.io/badge/license-Apache%20License%202.0-blue.svg?style=flat)](https://www.apache.org/licenses/LICENSE-2.0)

[Download v.1.3](https://github.com/StarKRE/Orego/releases/download/v.1.3/Orego.unitypackage)

Library support Unity 2019.1.8f+ 

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

### Create your First Element

```csharp
using OregoFramework.Core;

[OregoContext]
public sealed class MyApplication : Element
{
}
```

### Add magic interface

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

### Add MainScript.cs to your game object and play.

![image](https://user-images.githubusercontent.com/22048950/87091720-d24b4600-c242-11ea-9491-841d5aa31b48.png)


### Create your First Element Layer

For example we create Repository Layer:

#### 1.) Create repository classes:

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
#### 2.) Create repository Layer

```csharp
using OregoFramework.Core;

[OregoContext]
public sealed class RepositoryLayer : ElementLayer<IRepository>
{
}
```

#### 3.) Connect repository layer to the my app:

```csharp
using OregoFramework.Core;
using UnityEngine;

[OregoContext]
public sealed class MyApplication : Element, ISingletonElement
{
    private RepositoryLayer repositoryLayer;
    
    public void OnBecameSingleton()
    {
        Debug.Log("Hello world!");
    }

    public override void OnCreate()
    {
        base.OnCreate();
        this.repositoryLayer = this.CreateElement<RepositoryLayer>(typeof(RepositoryLayer));
    }
}
```

#### Result:






