namespace SpaceShips
{
    struct WeaponComponent 
    {
        public string WeaponName;
        public WeaponStruct Weapon;
        public float CoolDown;

        public WeaponComponent(WeaponStruct weapon, string name)
        {
            Weapon = weapon;
            WeaponName = name;
            CoolDown = weapon.RateOfFire;
        }
    }
}