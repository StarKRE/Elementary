using System.Collections.Generic;

namespace ElementaryFramework.App
{
    public abstract class UIElement : UIBehaviour
    {
        private bool isUiSystemBound;

        private IUISystem _uiSystem;

        private IUISystem uiSystem
        {
            get
            {
                if (!this.isUiSystemBound)
                {
                    this._uiSystem = UISystem.instance;
                    this.isUiSystemBound = true;
                }

                return this._uiSystem;
            }
        }

        protected T GetUISystem<T>() where T : IUISystem
        {
            return (T) this.uiSystem;
        }

        protected T GetUIController<T>() where T : IUIController
        {
            return this.uiSystem.GetUIController<T>();
        }

        protected IEnumerable<T> GetUIControllers<T>() where T : IUIController
        {
            return this.uiSystem.GetUIControllers<T>();
        }
    }
}