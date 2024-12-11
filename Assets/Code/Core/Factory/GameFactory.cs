using Core.Interface;
using InputModule;
using System;
using UnityEngine;
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


    }
}