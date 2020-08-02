using System;
using System.Collections.Generic;

namespace ElementaryFramework.Core
{
    public interface IElementContext : Elementary.ICore
    {
        HashSet<Type> GetImplementationTypes(Type interfaceType);
        
        T CreateElement<T>(Type requiredType) where T : IElement;

        IEnumerable<T> CreateElements<T>() where T : IElement;
        
        T GetRoot<T>() where T : IRootElement;

        IEnumerable<T> GetRoots<T>() where T : IRootElement;
    }
}