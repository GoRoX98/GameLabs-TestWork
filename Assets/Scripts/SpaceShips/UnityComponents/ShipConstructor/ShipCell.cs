using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceShips
{
    public class ShipCell : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdownUI;
        [SerializeField] private List<CellElement> _elements;
        private ScriptableObject _seleñtModule;
        public ScriptableObject SelectModule => _seleñtModule;

        private void Awake()
        {
            _seleñtModule = _dropdownUI.template.GetChild(1).GetComponent<CellElement>().ShipModule;
        }
    }
}
