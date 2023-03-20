using UnityEngine;

namespace SpaceShips 
{
    public struct ShipInfoComponent 
    {
        public string ShipName;
        public float StartHealth;
        public float StartShield;
        public float CurrentHealth;
        public float CurrentShield;
        public float ShieldRegeneration;

        public ShipInfoComponent(string name, float health, float shield, float regeneration)
        {
            ShipName = name;
            StartHealth = health;
            StartShield = shield;
            CurrentHealth = health;
            CurrentShield = shield;
            ShieldRegeneration = regeneration;
        }
    }
}