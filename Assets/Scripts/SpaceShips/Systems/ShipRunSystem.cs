using Leopotam.Ecs;

namespace SpaceShips 
{
    sealed class ShipRunSystem : IEcsRunSystem 
    {
        readonly EcsWorld _world = null;
        private GameUI _gameUI;
        private EcsFilter<ShipInfoComponent> _ships;
        private EcsFilter<OwnerComponent, WeaponComponent> _weapons;

        public void Run () 
        {

            UpdateUI();
        }

        private void UpdateUI()
        {
            for (int i = 0; i < _gameUI.ShipsUI.Count; i++)
            {
                ShipInfoComponent ship = _ships.Get1(i);
                _gameUI.ShipsUI[i].Life.value = ship.CurrentHealth / ship.StartHealth;
                _gameUI.ShipsUI[i].Shield.value = ship.CurrentShield / ship.StartShield;
            }
        }
    }
}