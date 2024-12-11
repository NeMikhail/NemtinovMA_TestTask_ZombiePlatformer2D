using Core.Interface;
using GameCoreModule;
using InputModule;
using Zenject;

namespace Core
{
    public class GameFactory
    {
        private DiContainer _di;
        private Presenters _presenters;

        [Inject]
        public void Construct(DiContainer di, Presenters presenters)
        {
            _di = di;
            _presenters = presenters;
        }

        public void Init()
        {
            InitializeInputModule();
            InitializeGameCoreModule();
        }

        private void InitializePresenter(IPresenter presenter)
        {
            _presenters.Add(presenter);
        }


        private void InitializeInputModule()
        {
            InputPresenter inputPresenter = _di.Resolve<InputPresenter>();
            InitializePresenter(inputPresenter);
        }

        private void InitializeGameCoreModule()
        {
            GameStatePresenter gameStatePresenter = _di.Resolve<GameStatePresenter>();
            InitializePresenter(gameStatePresenter);
            PoolsOperatorPresenter poolsOperator = _di.Resolve<PoolsOperatorPresenter>();
            InitializePresenter(poolsOperator);
            SpawnOperatorPresenter spawnOperator = _di.Resolve<SpawnOperatorPresenter>();
            InitializePresenter(spawnOperator);
        }


    }
}