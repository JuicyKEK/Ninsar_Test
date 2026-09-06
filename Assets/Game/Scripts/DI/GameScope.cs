using Game.Scripts.CubeMechanics.Controllers;
using Game.Scripts.CubeMechanics.Controllers.Controllers;
using Game.Scripts.CubeMechanics.Controllers.Data;
using Game.Scripts.CubeMechanics.Controllers.View;
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
            builder.RegisterComponent(_сubeViewController)
                .As<ICubeViewController>();
            builder.RegisterComponent(_inputController)
                .As<ICubeInputController>();
        }
    }
}
