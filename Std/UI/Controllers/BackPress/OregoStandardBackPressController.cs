using UnityEngine;

namespace OregoFramework.UI
{
    public class OregoStandardBackPressController : OregoBackPressController
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