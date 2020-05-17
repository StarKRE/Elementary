using System;
using OregoFramework.Util;
using UnityEngine;
using UnityEngine.UI;

namespace OregoFramework.UI
{
    public class OregoUIInfoDialogLayout : OregoUIElement
    {
        #region Event

        public AutoEvent OnOkEvent { get; private set; }

        #endregion

        [SerializeField] 
        private Params m_params;

        protected Button buttonOk { get; private set; }

        protected virtual void Awake()
        {
            this.OnOkEvent = this.New<AutoEvent>();
            this.buttonOk = this.m_params.m_buttonOk;
        }

        protected virtual void OnEnable()
        {
            this.buttonOk.onClick.AddListener(this.OnOkClick);
        }

        protected virtual void OnOkClick()
        {
            this.OnOkEvent?.Invoke();
        }
        
        protected virtual void OnDisable()
        {
            this.buttonOk.onClick.RemoveAllListeners();
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField] 
            public Button m_buttonOk;
        }
    }
}