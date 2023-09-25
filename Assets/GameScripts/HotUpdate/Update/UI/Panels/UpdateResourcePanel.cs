using System;
using GameScripts.HotUpdate.Extensions;
using GameScripts.HotUpdate.Systems.UI;
using GameScripts.HotUpdate.UpdateAssets.UI.Components;
using MessagePipe;
using TMPro;
using UnityEngine;
using VContainer;

namespace GameScripts.HotUpdate.UpdateAssets.UI.Panels
{
    public class UpdateResourcePanel : UIPanel
    {
        private static readonly UIPanelInfo PanelInfo = new UIPanelInfo(
            "UpdateResource",
            "UpdateResource"
        );

        [Inject] private ISubscriber<UpdateProgressChange> _updateProgressChangeSubscriber;
        private IDisposable _disposable;
        private ProgressBar _progressBar;
        private TextMeshProUGUI _updateInfo;

        public UpdateResourcePanel() : base(PanelInfo)
        {
        }

        public override void OnStart()
        {
            _progressBar = UIGameObj.FindComponentWithGameObjNameInChildren<ProgressBar>("ProgressBar");
            _updateInfo = UIGameObj.FindComponentWithGameObjNameInChildren<TextMeshProUGUI>("UpdateInfo");

            _progressBar.ProgressValue = 0f;
            _updateInfo.text = string.Empty;

            var bagBuilder = DisposableBag.CreateBuilder();
            _updateProgressChangeSubscriber
                .Subscribe(changeValue =>
                {
                    _progressBar.ProgressValue = Mathf.Clamp01(changeValue.Value);
                    _updateInfo.text = $"{changeValue.UpdatePhase} {(int)(Mathf.Clamp01(changeValue.Value) * 100)}%";
                })
                .AddTo(bagBuilder);
            _disposable = bagBuilder.Build();
        }

        public override void OnDestroy()
        {
            _disposable?.Dispose();
        }
    }
}