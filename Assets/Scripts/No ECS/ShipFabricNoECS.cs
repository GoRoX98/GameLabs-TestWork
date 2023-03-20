using System.Collections.Generic;

namespace SpaceShips
{ 
    public class ShipFabricNoECS
    {
        private List<ModuleComponent> _modules;

        public Ship CreateShip(List<ModuleSO> modules, List<WeaponSO> weapons, ShipSO ship, GameManager gm)
        {
            CreateModules(modules);
            List<WeaponComponent> listWC = CreateWeapons(weapons);

            float[] shipStats = CalculateStats(ship.Ship);
            ShipInfoComponent shipInfo = new(ship.name, shipStats[0], shipStats[1], shipStats[2]);

            return new(shipInfo, _modules, listWC, gm);
        }

        private float[] CalculateStats(ShipStruct ship)
        {
            float health = ship.Health;
            float shield = ship.Shield;
            float regeneration = ship.ShieldRegeneration;

            foreach (var module in _modules)
            {
                health += module.Module.Health;
                shield += module.Module.Shield;
                regeneration *= 1 + module.Module.ShieldRegenerationModificator;
            }

            return new float[] { health, shield, regeneration };
        }

        private List<WeaponComponent> CreateWeapons(List<WeaponSO> weapons)
        {
            List<WeaponComponent> listWC = new();

            foreach (var weapon in weapons)
            {
                WeaponComponent weaponC = new(weapon.Weapon, weapon.name);
                foreach (var module in _modules)
                {
                    weaponC.Weapon.RateOfFire *= 1 + module.Module.ReloadModificator;
                }
                listWC.Add(weaponC);
            }

            return listWC;
        }

        private void CreateModules(List<ModuleSO> modules)
        {
            _modules = new();

            foreach (var module in modules)
            {
                _modules.Add(new(module.ShipModule, module.name));
            }
        }
    }
}
