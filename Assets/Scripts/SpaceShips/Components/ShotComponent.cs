namespace SpaceShips 
{
    struct ShotComponent 
    {
        public float Damage;
        public int TargetId;

        public ShotComponent(float dmg, int targetId)
        {
            Damage = dmg;
            TargetId = targetId;
        }
    }
}