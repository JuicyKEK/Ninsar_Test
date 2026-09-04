using Game.Scripts.CubeMechanics;
using Game.Scripts.CubeMechanics.Controllers;
using Game.Scripts.CubeMechanics.Services;
using Game.Scripts.CubeMechanics.Services.Interfaces;
using Game.Scripts.CubeMechanics.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.DI
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private GameCubeController _gameCubeController;
        [SerializeField] private CubeViewController _сubeViewController;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<IDataLoader, DataLoader>(Lifetime.Singleton);
            
            builder.RegisterComponent(_gameCubeController)
                .As<IGameCubeController>();
            builder.RegisterComponent(_сubeViewController)
                .As<ICubeViewController>();
        }
    }
}
