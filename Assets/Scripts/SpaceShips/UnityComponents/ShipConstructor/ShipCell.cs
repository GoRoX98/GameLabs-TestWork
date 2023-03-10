using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceShips
{
    public class ShipCell : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdownUI;
        [SerializeField] private List<CellElement> _elements;
        private ScriptableObject _sele�tModule;
        public ScriptableObject SelectModule => _sele�tModule;

        private void Awake()
        {
            _sele�tModule = _dropdownUI.template.GetChild(1).GetComponent<CellElement>().ShipModule;
        }
    }
}
