using UnityEngine;

namespace SpaceShips
{
    [CreateAssetMenu(fileName = "Ship", menuName = "Game/New Ship")]
    public class ShipSO : ScriptableObject
    {
        [SerializeField] private ShipStruct _ship;

        public ShipStruct Ship => _ship;
    }
}
