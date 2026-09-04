using Game.Scripts.CubeMechanics;
using Game.Scripts.CubeMechanics.Controllers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.DI
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private GameCubeController _gameCubeController;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            builder.RegisterComponent(_gameCubeController)
                .As<IGameCubeController>();
        }
    }
}
