using UnityEngine;

namespace SpaceShips
{
    public class CellElement : MonoBehaviour
    {
        [SerializeField] private ScriptableObject _shipModule;
        public ScriptableObject ShipModule => _shipModule;
    }
}
