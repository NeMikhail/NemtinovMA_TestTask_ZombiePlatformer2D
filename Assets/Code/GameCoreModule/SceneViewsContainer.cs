using Extention;
using Core.Interface;
using PlayerModule;
using Zenject;
using SO;

namespace GameCoreModule
{
    public class SceneViewsContainer
    {
        private PrefabsContainer _prefabsContainer;
        private int _currentIndex = 0;
        private SerializableDictionary<string, IView> _viewsDict;

        [Inject]
        public void Construct(PrefabsContainer prefabsContainer)
        {
            _prefabsContainer = prefabsContainer;
        }

        public SceneViewsContainer()
        {
            _viewsDict = new SerializableDictionary<string, IView>();
        }

        public void AddView(IView view)
        {
            string id = GenerateID(view);
            view.ViewID = id;
            _viewsDict.Add(id, view);
            _currentIndex++;
        }

        private string GenerateID(IView view)
        {
            string id = $"{view.Object.name}";
            return id;
        }

        public IView GetView(string id)
        {
            return _viewsDict.GetValue(id);
        }

        public PlayerView GetPlayerView()
        {
            PlayerView playerView = null;
            
            string viewID = _prefabsContainer.PrefabsDict.GetValue(PrefabID.PlayerPrefab).name;
            playerView = (PlayerView)_viewsDict.GetValue(viewID);
            return playerView;
        }
    }
}
