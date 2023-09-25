using System;
using GameScripts.HotUpdate.Extensions;
using GameScripts.HotUpdate.Systems.UI;
using MessagePipe;
using TMPro;
using UnityEngine.UI;
using VContainer;

namespace GameScripts.HotUpdate.UpdateAssets.UI.Panels
{
    public class UpdateResourceInfoBox : UIPanel
    {
        public UpdateResourceInfoBox() : base(Info)
        {
        }

        private static readonly UIPanelInfo Info = new UIPanelInfo(
            "UpdateResourceInfo",
            "UpdateResourceInfoBox"
        );

        [Inject] private ISubscriber<UpdateResourceFailedInfo> _subscriber;
        private IDisposable _disposable;
        private Button _btnReTry;
        private TextMeshProUGUI _info;

        public override void OnStart()
        {
            _btnReTry = UIGameObj.FindComponentWithGameObjNameInChildren<Button>("Button");
            _info = UIGameObj.FindComponentWithGameObjNameInChildren<TextMeshProUGUI>("Info");

            var bagBuilder = DisposableBag.CreateBuilder();
            _subscriber
                .Subscribe(message =>
                {
                    _info.text = message.Info;
                    _btnReTry.onClick.AddListener(() => message.Callback());
                })
                .AddTo(bagBuilder);
            _disposable = bagBuilder.Build();
        }

        public override void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}