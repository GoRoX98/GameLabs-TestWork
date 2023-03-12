using Leopotam.Ecs;
using UnityEngine;

namespace SpaceShips 
{
    sealed class ShipRunSystem : IEcsRunSystem 
    {
        readonly EcsWorld _world = null;
        private EcsFilter<ShipInfoComponent> _filterShips;
        private EcsFilter<ShotComponent> _filterShots;
        private EcsFilter<GameStatusComponent> _status;
        private float _shieldCD = 1f;

        public void Run () 
        {
            if (_status.Get1(0).Status == GameStatus.Battle)
            {
                if (_shieldCD > 0)
                    _shieldCD -= Time.deltaTime;
                else
                {
                    _shieldCD = 1f;
                    ShieldRegeneration();
                }

                if (!_filterShots.IsEmpty())
                    CheckShots();
            }
        }

        private void CheckShots()
        {
            foreach (var i in _filterShips)
            {
                if (_filterShips.GetEntity(i).GetInternalId() == _filterShots.Get1(0).TargetId)
                {
                    Damage(_filterShots.Get1(0).Damage, ref _filterShips.Get1(i));
                    _filterShots.GetEntity(0).Destroy();
                }
            }
        }

        private void Damage(float dmg, ref ShipInfoComponent ship)
        {
            if (ship.CurrentShield >= dmg)
            {
                ship.CurrentShield -= dmg;
                return;
            }
            else
            {
                dmg -= ship.CurrentShield;
                ship.CurrentShield = 0;
            }

            if (ship.CurrentHealth > dmg)
            {
                ship.CurrentHealth -= dmg;
            }
            else
            {
                ship.CurrentHealth = 0;
                _status.Get1(0).Status = GameStatus.End;
                EcsEntity changeStatus = _world.NewEntity();
                changeStatus.Get<ChangeStatusComponent>();
            }
        }



        private void ShieldRegeneration()
        {
            foreach (var i in _filterShips)
            {
                ref var ship = ref _filterShips.Get1(i);
                if(ship.CurrentShield < ship.StartShield)
                {
                    ship.CurrentShield += ship.ShieldRegeneration;
                    if (ship.CurrentShield > ship.StartShield)
                        ship.CurrentShield = ship.StartShield;
                }
            }
        }
    }
}