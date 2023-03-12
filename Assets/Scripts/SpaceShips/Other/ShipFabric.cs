using Leopotam.Ecs;
using System.Collections.Generic;

namespace SpaceShips
{
    public class ShipFabric
    {
        private EcsWorld _world;
        private int _shipId;
        private List<ModuleComponent> _modules;

        public ShipFabric(EcsWorld world)
        {
            _world = world;
        }

        public void CreateShip(List<ModuleSO> modules, List<WeaponSO> weapons, ShipSO ship, ShipObject shipObj)
        {
            EcsEntity shipEntity = _world.NewEntity();
            _shipId = shipEntity.GetInternalId();
            shipEntity.Get<ShipComponent>() = new(shipObj, ship.Ship);

            
            CreateModules(modules);
            CreateWeapons(weapons);

            float[] shipStats = CalculateStats(ship.Ship);
            shipEntity.Get<ShipInfoComponent>() = new(ship.name, shipStats[0], shipStats[1], shipStats[2]);
        }

        private float[] CalculateStats(ShipStruct ship)
        {
            float health = ship.Health;
            float shield = ship.Shield;
            float regeneration = ship.ShieldRegeneration;

            foreach(var module in _modules)
            {
                health += module.Module.Health;
                shield += module.Module.Shield;
                regeneration *= 1 + module.Module.ShieldRegenerationModificator;
            }

            return new float[] {health, shield, regeneration};
        }

        private void CreateWeapons(List<WeaponSO> weapons)
        {
            foreach (var weapon in weapons)
            {
                EcsEntity weaponEntity = _world.NewEntity();
                weaponEntity.Get<OwnerComponent>() = new(_shipId);
                weaponEntity.Get<WeaponComponent>() = new(weapon.Weapon, weapon.name);
                ref WeaponComponent weaponComponent = ref weaponEntity.Get<WeaponComponent>();
                foreach(var module in _modules)
                {
                    weaponComponent.Weapon.RateOfFire *= 1 + module.Module.ReloadModificator;
                }
            }
        }

        private void CreateModules(List<ModuleSO> modules)
        {
            _modules = new List<ModuleComponent>();
            foreach (var module in modules)
            {
                EcsEntity moduleEntity = _world.NewEntity();
                moduleEntity.Get<OwnerComponent>() = new(_shipId);
                _modules.Add(moduleEntity.Get<ModuleComponent>() = new(module.ShipModule, module.name));
            }
        }
    }
}
