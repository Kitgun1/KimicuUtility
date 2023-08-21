using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace KiUtilities
{
    [DisallowMultipleComponent]
    public sealed class KiButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler,
        IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private bool _interactable = true;

        public bool Interactable
        {
            get => _interactable;
            set
            {
                _interactable = value;
                OnInteractChange?.Invoke(Interactable);
            }
        }

        #region UnityEvents

        [SerializeField] private bool _collapseUnityEvents = true;

        /// <summary>
        /// Вызывется, когда курсор входит на границы UI element-а
        /// </summary>
        [HideIf(nameof(_collapseUnityEvents))] public UnityEvent OnEnterHandler;

        /// <summary>
        /// Вызыветсяholder, когда курсор выходит за границы UI element-а
        /// </summary>
        [HideIf(nameof(_collapseUnityEvents))] public UnityEvent OnExitHandler;

        /// <summary>
        /// Вызыветсяholder, когда был произведен клик на UI element
        /// </summary>
        [HideIf(nameof(_collapseUnityEvents))] public UnityEvent OnClickHandler;

        /// <summary>
        /// Вызывется, когда происходит зажатие UI element
        /// </summary>
        [HideIf(nameof(_collapseUnityEvents))] public UnityEvent OnDownHandler;

        /// <summary>
        /// Вызывется, когда происходит отжатие UI element
        /// </summary>holder
        [HideIf(nameof(_collapseUnityEvents))] public UnityEvent OnUpHandler;

        /// <summary>
        /// Вызывется, когда поле "Interactable" изменено
        /// </summary>
        [HideIf(nameof(_collapseUnityEvents))] public UnityEvent<bool> OnInteractChange;

        #endregion

        #region Action

        /// <summary>
        /// Вызывется, когда курсор входит на границы UI element-а
        /// </summary>
        public event Action EnterHandler;

        /// <summary>
        /// Вызыветсяholder, когда курсор выходит за границы UI element-а
        /// </summary>
        public event Action ExitHandler;

        /// <summary>
        /// Вызыветсяholder, когда был произведен клик на UI element
        /// </summary>
        public event Action ClickHandler;

        /// <summary>
        /// Вызывется, когда происходит зажатие UI element
        /// </summary>
        public event Action DownHandler;

        /// <summary>
        /// Вызывется, когда происходит отжатие UI element
        /// </summary>holder
        public event Action UpHandler;

        /// <summary>
        /// Вызывется, когда поле "Interactable" изменено
        /// </summary>
        public event Action<bool> InteractChange;

        #endregion

        #region ContextMethods

        [Header("Debug"), SerializeField] private bool _isDebug = false;

        [ContextMenu(nameof(EnterHandlerInvoke))]
        [Button, ShowIf(nameof(_isDebug))]
        private KiButton EnterHandlerInvoke()
        {
            OnEnterHandler?.Invoke();
            EnterHandler?.Invoke();
            return this;
        }

        [ContextMenu(nameof(ExitHandlerInvoke))]
        [Button, ShowIf(nameof(_isDebug))]
        private KiButton ExitHandlerInvoke()
        {
            OnExitHandler?.Invoke();
            ExitHandler?.Invoke();
            return this;
        }

        [ContextMenu(nameof(ClickHandlerInvoke))]
        [Button, ShowIf(nameof(_isDebug))]
        private KiButton ClickHandlerInvoke()
        {
            OnClickHandler?.Invoke();
            ClickHandler?.Invoke();
            return this;
        }

        [ContextMenu(nameof(DownHandlerInvoke))]
        [Button, ShowIf(nameof(_isDebug))]
        private KiButton DownHandlerInvoke()
        {
            OnDownHandler?.Invoke();
            DownHandler?.Invoke();
            return this;
        }

        [ContextMenu(nameof(UpHandlerInvoke))]
        [Button, ShowIf(nameof(_isDebug))]
        private KiButton UpHandlerInvoke()
        {
            OnUpHandler?.Invoke();
            UpHandler?.Invoke();
            return this;
        }

        [ContextMenu(nameof(InteractChangeInvoke))]
        [Button, ShowIf(nameof(_isDebug))]
        private KiButton InteractChangeInvoke()
        {
            OnInteractChange?.Invoke(Interactable);
            InteractChange?.Invoke(Interactable);
            return this;
        }

        #endregion

        #region Event

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!Interactable) return;
            EnterHandlerInvoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!Interactable) return;
            ExitHandlerInvoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!Interactable) return;
            ClickHandlerInvoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!Interactable) return;
            DownHandlerInvoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!Interactable) return;
            UpHandlerInvoke();
        }

        #endregion
    }
}