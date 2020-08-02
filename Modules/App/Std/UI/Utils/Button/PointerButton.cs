using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ElementaryFramework.Util
{
    public class PointerButton : Button
    {
        #region Event

        public event Action OnPointerDownEvent;

        public event Action OnPointerEnterEvent;

        public event Action OnPointerExitEvent;

        public event Action OnPointerUpEvent;

        #endregion

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            this.OnPointerDownEvent?.Invoke();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            this.OnPointerEnterEvent?.Invoke();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            this.OnPointerExitEvent?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            this.OnPointerUpEvent?.Invoke();
        }
    }
}