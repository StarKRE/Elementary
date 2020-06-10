using System.Collections.Generic;
using OregoFramework.Core;

namespace OregoFramework.UI
{
    public abstract class OregoUIElement : OregoUIBehaviour
    {
        private bool isUiSystemBound;

        private IOregoUISystem _uiSystem;

        private IOregoUISystem uiSystem
        {
            get
            {
                if (!this.isUiSystemBound)
                {
                    this._uiSystem = Orego.GetObject<IOregoUISystem>(nameof(IOregoUISystem));
                    this.isUiSystemBound = true;
                }

                return this._uiSystem;
            }
        }

        protected T GetUISystem<T>() where T : IOregoUISystem
        {
            return (T) this.uiSystem;
        }

        protected T GetUIController<T>() where T : IOregoUIController
        {
            return this.uiSystem.GetUIController<T>();
        }

        protected IEnumerable<T> GetUIControllers<T>() where T : IOregoUIController
        {
            return this.uiSystem.GetUIControllers<T>();
        }
    }
}