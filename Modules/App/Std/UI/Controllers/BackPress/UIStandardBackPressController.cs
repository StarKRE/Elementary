using UnityEngine;

namespace ElementaryFramework.App
{
    public class UIStandardBackPressController : UIBackPressController
    {
        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) ||
                Input.GetKeyDown(KeyCode.Backspace) ||
                Input.GetKeyDown(KeyCode.Home))
            {
                this.OnBackPressed();
            }
        }
    }
}