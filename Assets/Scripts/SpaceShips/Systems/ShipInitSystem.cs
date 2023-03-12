using System.Linq;
using Leopotam.Ecs;

namespace SpaceShips
{
    sealed class ShipInitSystem : IEcsInitSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GameUI _gameUI;
        private EcsFilter<ShipInfoComponent> _filterShips;
        private EcsFilter<ModuleComponent> _filterModules;
        private EcsFilter<WeaponComponent> _filterWeapons;
        
        public void Init () 
        {
            _gameUI.StartGame.onClick.AddListener(call: () => CreateShip());
        }

        private void CreateShip()
        {
            if(!_filterShips.IsEmpty())
            {
                foreach (var i in _filterShips)
                    _filterShips.GetEntity(i).Destroy();
                foreach (var i in _filterModules)
                    _filterModules.GetEntity(i).Destroy();
                foreach (var i in _filterWeapons)
                    _filterWeapons.GetEntity(i).Destroy();
            }

            ShipFabric fabric = new(_world);
            foreach(var constructor in _gameUI.Constructors)
            {
                fabric.CreateShip(constructor.SelectModules.Select(x =>(ModuleSO)x).ToList(), 
                                    constructor.SelectWeapons.Select(x => (WeaponSO)x).ToList(), 
                                    constructor.Ship, constructor.ShipObj);
            }
        }
    }
}