using UnityEngine;

namespace SpaceShips 
{
    struct ShipInfoComponent 
    {
        public float StartHealth;
        public float StartShield;
        public float CurrentHealth;
        public float CurrentShield;
        public float ShieldRegeneration;

        public ShipInfoComponent(float health, float shield, float regeneration)
        {
            StartHealth = health;
            StartShield = shield;
            CurrentHealth = health;
            CurrentShield = shield;
            ShieldRegeneration = regeneration;
        }
    }
}