using System.Collections.Generic;
using UnityEngine;

namespace SpaceShips
{
    public class Ship
    {
        private ShipInfoComponent _ship;
        private List<ModuleComponent> _modules;
        private List<WeaponComponent> _weapons;
        private float _shieldCD = 1f;
        private GameManager _gameManager;

        public ShipInfoComponent ShipInfo => _ship;
        public List<WeaponComponent> Weapons => _weapons;
        public List<ModuleComponent> Modules => _modules;

        public Ship(ShipInfoComponent ship, List<ModuleComponent> modules, List<WeaponComponent> weapons, GameManager gm)
        {
            _ship = ship;
            _modules = modules;
            _weapons = weapons;
            _gameManager = gm;
            Shot += Damage;
        }

        public delegate void OnShot(Ship owner, float dmg);
        public OnShot Shot;

        public void UpdateShip()
        {
            if (_gameManager.Status == GameStatus.Battle)
            {
                if (_shieldCD > 0)
                    _shieldCD -= Time.deltaTime;
                else
                {
                    _shieldCD = 1f;
                    ShieldRegeneration();
                }
            }
        }

        private void Damage(Ship owner, float dmg)
        {
            if (owner == this)
                return;

            if (_ship.CurrentShield >= dmg)
            {
                _ship.CurrentShield -= dmg;
                return;
            }
            else
            {
                dmg -= _ship.CurrentShield;
                _ship.CurrentShield = 0;
            }

            if (_ship.CurrentHealth > dmg)
            {
                _ship.CurrentHealth -= dmg;
            }
            else
            {
                _ship.CurrentHealth = 0;
            }
        }

        private void ShieldRegeneration()
        {
            if (_ship.CurrentShield < _ship.StartShield)
            {
                _ship.CurrentShield += _ship.ShieldRegeneration;
                if (_ship.CurrentShield > _ship.StartShield)
                    _ship.CurrentShield = _ship.StartShield;
            }
        }
    }
}
