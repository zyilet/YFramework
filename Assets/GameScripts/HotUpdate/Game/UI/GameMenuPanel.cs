using GameScripts.HotUpdate.Extensions;
using GameScripts.HotUpdate.Game.MessageDefine;
using GameScripts.HotUpdate.Systems.UI;
using MessagePipe;
using TMPro;
using UnityEngine.UI;
using VContainer;
using YooAsset;

namespace GameScripts.Game.UI
{
    public class GameMenuPanel : UIPanel
    {
        private static readonly UIPanelInfo Info = new UIPanelInfo(
            "GameMenu",
            "GameMenu"
        );

        [Inject] private IPublisher<ChangeToBattleScene> _publisher;
        private Button _btnStart;
        private TextMeshProUGUI _textVersion;

        public GameMenuPanel() : base(Info)
        {
        }

        public override void OnStart()
        {
            _btnStart = UIGameObj.FindComponentWithGameObjNameInChildren<Button>("Start");
            _textVersion = UIGameObj.FindComponentWithGameObjNameInChildren<TextMeshProUGUI>("Version");

            _textVersion.text = "Ver: " + YooAssets.GetPackage("DefaultPackage").GetPackageVersion();
            _btnStart.onClick.AddListener(OnClickStart);
        }

        private void OnClickStart()
        {
            _publisher.Publish(new ChangeToBattleScene());
        }
    }
}