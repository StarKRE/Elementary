using System;

namespace ElementaryFramework.App
{
    public abstract class UIStandardScreenController : UIStatefulScreenController
    {
        protected override IUIStateAdapter LoadStateAdapter(Type screenType)
        {
            var resource = this.screenTypeVsResourceMap[screenType];
            if (!(resource is IUIStatefulResource statefulScreenResource))
            {
                var resourceName = resource.GetType().Name;
                throw new Exception($"Resource {resourceName} is not stateful resource!");
            }

            var adapterType = statefulScreenResource.stateAdapterType;
            var newAdapter = (IUIStateAdapter) Activator.CreateInstance(adapterType);
            return newAdapter;
        }
    }
}