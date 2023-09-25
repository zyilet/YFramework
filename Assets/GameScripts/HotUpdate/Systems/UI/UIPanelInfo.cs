namespace GameScripts.HotUpdate.Systems.UI
{
    public class UIPanelInfo
    {
        public UIPanelInfo(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string Name { get; }
        public string Path { get; }
    }
}