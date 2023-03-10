using UnityEngine;

namespace SpaceShips
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Game/New Weapon")]
    public class WeaponSO : ScriptableObject, IShipModule
    {
        [SerializeField] private WeaponStruct _weapon;

        public WeaponStruct Weapon => _weapon;
    }
}
