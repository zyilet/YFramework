using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace GameScripts.HotUpdate.Systems.UI
{
    public interface IUI
    {
        string TopUIPanelName { get; }
        IEnumerable<string> AllUIPanelNames { get; }
        int CurrentUIPanelCount { get; }

        void Push<TPanel>() where TPanel : UIPanel, new();
        UniTask PushAsync<TPanel>() where TPanel : UIPanel, new();
        void Push<TPanel>(object param) where TPanel : UIPanel, new();
        UniTask PushAsync<TPanel>(object param) where TPanel : UIPanel, new();
        void Pop();
        void PopAll();
    }
}