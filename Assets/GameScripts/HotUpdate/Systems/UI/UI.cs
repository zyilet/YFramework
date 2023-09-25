using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameScripts.HotUpdate.Extensions;
using GameScripts.HotUpdate.Systems.Assets;
using GameScripts.HotUpdate.Systems.Log;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace GameScripts.HotUpdate.Systems.UI
{
    public class UI : IUI
    {
        private const string UI_CANVAS_PREFAB_PATH = "UISystem";

        [Inject] private readonly ILog _log;

        [Inject] private readonly IAssets _assets;

        // [Inject] private readonly IResource _resource;
        [Inject] private readonly IObjectResolver _objectResolver;
        private readonly Stack<UIPanel> _stackUIPanels = new();
        private readonly Dictionary<string, GameObject> _dictUIGameObjs = new();
        private GameObject _uiRootGameObj;
        private Transform _uiCanvasTransform;

        public string TopUIPanelName => _stackUIPanels.FirstOrDefault()?.Name;
        public IEnumerable<string> AllUIPanelNames => _stackUIPanels.Select(ele => ele.Name);
        public int CurrentUIPanelCount => _stackUIPanels.Count;

        public UI()
        {
            // _uiRootGameObj = _assets.LoadAndInstantiate(UI_CANVAS_PREFAB_PATH);
            // _uiCanvasTransform = _uiRootGameObj.transform.Find("Canvas");
            // _uiRootGameObj.name = $"[{nameof(UI)}]";
        }

        /// <summary>
        /// 将指定的页面类型入栈并启用
        /// </summary>
        /// <typeparam name="TUIPanel"></typeparam>
        public void Push<TUIPanel>() where TUIPanel : UIPanel, new()
        {
            //创建ui画布
            if (_uiRootGameObj == null)
            {
                _uiRootGameObj = _assets.LoadAndInstantiate(UI_CANVAS_PREFAB_PATH);
                _uiCanvasTransform = _uiRootGameObj.transform.Find("Canvas");
                _uiRootGameObj.name = $"[{nameof(UI)}]";
            }

            //（反射）获取uiPanel的泛化对象，包含uiPanelInfo
            // var uiPanel = GetUIPanel<TUIPanel>();
            // 替换成new T()
            var uiPanel = new TUIPanel();
            _objectResolver.Inject(uiPanel);
            //（同步）加载ui元素
            var uiGameObj = GetUIGameObj(uiPanel);
            uiGameObj.transform.SetParent(_uiCanvasTransform, false); //todo:: 在_uiRootGameObj下寻找挂载了Canvas组件的GameObject

            //将上级ui元素停用
            if (_stackUIPanels.Any())
                _stackUIPanels.Peek().OnDisable();

            //将ui元素入栈并启用
            uiPanel.UIGameObj = uiGameObj;
            _stackUIPanels.Push(uiPanel);
            uiPanel.OnStart();
        }

        public UniTask PushAsync<TPanel>() where TPanel : UIPanel, new()
        {
            throw new NotImplementedException();
        }

        public void Push<TPanel>(object param) where TPanel : UIPanel, new()
        {
            throw new NotImplementedException();
        }

        public UniTask PushAsync<TPanel>(object param) where TPanel : UIPanel, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将栈顶页面出栈并销毁
        /// </summary>
        public void Pop()
        {
            Pop(1);
        }

        /// <summary>
        /// 将所有页面出栈并销毁
        /// </summary>
        public void PopAll()
        {
            Pop(_stackUIPanels.Count);
        }

        /// <summary>
        /// 将栈顶的指定个数的页面出栈并销毁
        /// </summary>
        /// <param name="popTimes">需要出栈的页面个数</param>
        private void Pop(int popTimes)
        {
            while (popTimes > 0)
            {
                if (_stackUIPanels.Empty())
                    return;

                var uiPanel = _stackUIPanels.Pop();

                _dictUIGameObjs.Remove(uiPanel.Name);

                uiPanel.OnDisable();
                uiPanel.OnDestroy();
                Object.Destroy(uiPanel.UIGameObj);

                popTimes--;
            }

            if (_stackUIPanels.Any())
                _stackUIPanels.Peek().OnEnable();
        }

        private GameObject GetUIGameObj(UIPanel uiPanel)
        {
            if (_dictUIGameObjs.NotContainsKey(uiPanel.Name))
            {
                // var uiGameObj = _resource.LoadAndInstantiate(uiPanel.Path);
                // var uiGameObj = Object.Instantiate(Resources.Load<GameObject>(uiPanel.Path));
                var uiGameObj = _assets.LoadAndInstantiate(uiPanel.Path);
                uiGameObj.name = uiPanel.Name;
                _dictUIGameObjs.Add(uiPanel.Name, uiGameObj);
            }

            return _dictUIGameObjs[uiPanel.Name];
        }
    }
}