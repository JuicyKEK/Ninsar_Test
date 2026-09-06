using Game.Scripts.CubeMechanics.Controllers;
using Game.Scripts.CubeMechanics.Controllers.View;
using Game.Scripts.CubeMechanics.Data;
using Game.Scripts.CubeMechanics.Services;
using Game.Scripts.CubeMechanics.View;
using Game.Scripts.InputController;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.DI
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private GameCubeController _gameCubeController;
        [SerializeField] private CubeViewController _сubeViewController;
        [SerializeField] private CustomInputController _inputController;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<IDataLoader, DataLoader>(Lifetime.Singleton);
            
            builder.RegisterComponent(_gameCubeController)
                .As<IGameCubeController>();
            builder.RegisterComponent(_сubeViewController);
            builder.RegisterComponent(_inputController)
                .As<ICubeInputController>();
        }
    }
}
