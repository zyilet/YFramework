using UnityEngine;
using VContainer;

namespace GameScripts.HotUpdate.Systems.UI
{
    public abstract class UIPanel
    {
        protected UIPanel(UIPanelInfo uiPanelInfo)
        {
            UIPanelInfo = uiPanelInfo;
        }

        [Inject] private UIUtilities _uiUtilities;

        public UIPanelInfo UIPanelInfo { get; }
        public GameObject UIGameObj { get; set; }
        public string Name => UIPanelInfo.Name;
        public string Path => UIPanelInfo.Path;
        
        public void Start()
        {
            _uiUtilities.GetOrAddComponent<CanvasGroup>(UIGameObj).interactable = true;
            OnStart();
        }

        public void Enable()
        {
            _uiUtilities.GetOrAddComponent<CanvasGroup>(UIGameObj).interactable = true;
            OnEnable();
        }

        public void Disable()
        {
            _uiUtilities.GetOrAddComponent<CanvasGroup>(UIGameObj).interactable = false;
            OnDisable();
        }

        public void Destroy()
        {
            _uiUtilities.GetOrAddComponent<CanvasGroup>(UIGameObj).interactable = false;
            OnDestroy();
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnEnable()
        {
        }

        public virtual void OnDisable()
        {
        }

        public virtual void OnDestroy()
        {
        }
    }
}