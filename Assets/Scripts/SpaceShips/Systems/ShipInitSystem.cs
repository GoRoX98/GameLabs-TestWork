using System.Linq;
using Leopotam.Ecs;

namespace SpaceShips
{
    sealed class ShipInitSystem : IEcsInitSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private StaticData _staticData;
        private SceneData _sceneData;
        private GameUI _gameUI;
        
        public void Init () 
        {
            _gameUI.StartGame.onClick.AddListener(call: () => CreateShip());
        }

        private void CreateShip()
        {
            ShipFabric fabric = new(_world, _staticData, _sceneData);
            foreach(var constructor in _gameUI.Constructors)
            {
                fabric.CreateShip(constructor.SelectModules.Select(x =>(ModuleSO)x).ToList(), constructor.SelectWeapons.Select(x => (WeaponSO)x).ToList(), 
                                    constructor.Ship, constructor.ShipObj);
            }
        }
    }
}