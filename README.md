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

### Create your first element

```csharp
using OregoFramework.Core;

[OregoContext]
public sealed class MyApplication : Element
{
}
```

- ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) `#f03c15`

### Add interface.

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

### Add MainScript.cs to your game object and launch.
![image](https://user-images.githubusercontent.com/22048950/87091531-7f718e80-c242-11ea-9579-229a38977b67.png)



