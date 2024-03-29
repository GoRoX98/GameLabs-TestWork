using System.Collections.Generic;
using UnityEngine;

namespace SpaceShips
{
    [CreateAssetMenu(fileName = "Static Data", menuName = "Game/New Static Data")]
    public class StaticData : ScriptableObject
    {
        [SerializeField] private List<ShipSO> _ships;
        [SerializeField] private List<WeaponSO> _weapons;
        [SerializeField] private List<ModuleSO> _modules;

        public List<ShipSO> Ships => _ships;
        public List<WeaponSO> Weapons => _weapons;
        public List<ModuleSO> Modules => _modules;
    }
}
