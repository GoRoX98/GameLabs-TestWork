using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceShips
{
    public class ShipCell : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdownUI;
        private ScriptableObject _seleñtModule;
        private List<ScriptableObject> _modules;

        public void Init(List<ScriptableObject> modules)
        {
            _dropdownUI = GetComponent<TMP_Dropdown>();
            _modules = modules;

            List<TMP_Dropdown.OptionData> options = new();
            _modules.ForEach(action => options.Add(new TMP_Dropdown.OptionData(action.name)));
            _dropdownUI.ClearOptions();
            _dropdownUI.AddOptions(options);
        }

        public ScriptableObject GetSelectElement()
        {
            _seleñtModule = _modules[_dropdownUI.value];
            return _seleñtModule;
        }
    }
}
