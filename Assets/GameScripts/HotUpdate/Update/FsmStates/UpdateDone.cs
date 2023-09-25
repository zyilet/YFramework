using System.Drawing;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine.SceneManagement;
using YooAsset;

namespace GameScripts.HotUpdate.UpdateAssets.FsmStates
{
    [Category("UpdateAssets")]
    public class UpdateDone : FSMState
    {
        protected override async void OnEnter()
        {
            if (graphBlackboard.GetVariable<bool>("HaveUpdatedDlls").value)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            else
            {
                YooAssets.GetPackage("DefaultPackage").ForceUnloadAllAssets();
                YooAssets.LoadSceneAsync("Game");
            }
        }
    }
}