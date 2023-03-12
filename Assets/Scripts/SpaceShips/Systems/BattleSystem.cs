using Leopotam.Ecs;
using UnityEngine;

namespace SpaceShips 
{
    sealed class BattleSystem : IEcsRunSystem 
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private EcsFilter<ShipInfoComponent> _ships;
        private EcsFilter<WeaponComponent, OwnerComponent> _weapons;
        private EcsFilter<GameStatusComponent> _status;

        public void Run () 
        {
            if(_status.Get1(0).Status == GameStatus.Battle)
                CoolDown();
        }

        private void CoolDown()
        {
            foreach(var i in _weapons)
            {
                _weapons.Get1(i).CoolDown -= Time.deltaTime;
                if(_weapons.Get1(i).CoolDown <= 0)
                {
                    Shot(i);
                    _weapons.Get1(i).CoolDown = _weapons.Get1(i).Weapon.RateOfFire;
                }
            }
        }

        private void Shot(int weaponIndex)
        {
            int owner = _weapons.Get2(weaponIndex).EntityId;

            foreach(var i in _ships)
            {
                if (_ships.GetEntity(i).GetInternalId() != owner)
                {
                    int target = _ships.GetEntity(i).GetInternalId();
                    EcsEntity shot = _world.NewEntity();
                    shot.Get<ShotComponent>() = new(_weapons.Get1(weaponIndex).Weapon.Damage, target);
                    return;
                }
            }
        }
    }
}