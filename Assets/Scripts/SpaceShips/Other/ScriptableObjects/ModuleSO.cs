using UnityEngine;

namespace SpaceShips
{
    [CreateAssetMenu(fileName = "Ship Module", menuName = "Game/New Ship Module")]
    public class ModuleSO : ScriptableObject, IShipModule
    {
        [SerializeField] private ModuleStruct _shipModule;

        public ModuleStruct ShipModule => _shipModule;
    }
}
