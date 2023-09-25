using GameScripts.HotUpdate.Systems.Log;
using GameScripts.HotUpdate.Systems.UI;
using GameScripts.HotUpdate.UpdateAssets.UI.Panels;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using VContainer;

namespace GameScripts.HotUpdate.UpdateAssets.FsmStates
{
    [Category("UpdateAssets")]
    public class CreateUI : FSMState
    {
        [Inject] private IUI _ui;
        [Inject] private ILog _log;

        protected override void OnEnter()
        {
            _ui.Push<UpdateResourcePanel>();
            Finish();
        }
    }
}