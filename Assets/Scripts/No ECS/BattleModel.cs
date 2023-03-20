using UnityEngine;

namespace SpaceShips
{
    public class BattleModel
    {
        private GameManager _gameManager;

        public BattleModel(GameManager gm)
        {
            _gameManager = gm;
        }

        public void Battle()
        {
            CoolDown();
        }

        private void CoolDown()
        {
            foreach (var ship in _gameManager.Ships)
            {
                ship.UpdateShip();
                for (int i = 0; i < ship.Weapons.Count; i++)
                {
                    WeaponComponent newWC = ship.Weapons[i];
                    newWC.CoolDown -= Time.deltaTime;

                    if (newWC.CoolDown <= 0)
                    {
                        Shot(ship, newWC);
                        newWC.CoolDown = ship.Weapons[i].Weapon.RateOfFire;
                    }
                    
                    ship.Weapons[i] = newWC;
                }
            }
        }

        private void Shot(Ship ship, WeaponComponent weapon)
        {
            foreach (var target in _gameManager.Ships)
            {
                target.Shot?.Invoke(ship, weapon.Weapon.Damage);
            }
        }
    }
}