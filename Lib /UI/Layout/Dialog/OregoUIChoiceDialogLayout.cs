using System;
using OregoFramework.Util;
using UnityEngine;
using UnityEngine.UI;

namespace OregoFramework.UI
{
    public class OregoUIChoiceDialogLayout : OregoUIElement
    {
        #region Event

        public AutoEvent OnYesEvent { get; private set; }

        public AutoEvent OnNoEvent { get; private set; }

        #endregion

        [SerializeField] 
        private Params m_params;

        protected Button buttonYes { get; private set; }
        
        protected Button buttonNo { get; private set; }

        protected virtual void Awake()
        {
            this.OnYesEvent = this.New<AutoEvent>();
            this.OnNoEvent = this.New<AutoEvent>();
            this.buttonYes = this.m_params.m_buttonYes;
            this.buttonNo = this.m_params.m_buttonNo;
        }

        protected virtual void OnEnable()
        {
            this.buttonYes.onClick.AddListener(this.OnYesClick);
            this.buttonNo.onClick.AddListener(this.OnNoClick);
        }

        protected virtual void OnYesClick()
        {
            this.OnYesEvent?.Invoke();
        }

        protected virtual void OnNoClick()
        {
            this.OnNoEvent?.Invoke();
        }

        protected virtual void OnDisable()
        {
            this.buttonYes.onClick.RemoveAllListeners();
            this.buttonNo.onClick.RemoveAllListeners();
        }


        [Serializable]
        public sealed class Params
        {
            [SerializeField] 
            public Button m_buttonYes;

            [SerializeField] 
            public Button m_buttonNo;
        }
    }
}