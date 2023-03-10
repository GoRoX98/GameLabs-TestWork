using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace SpaceShips
{
    public class ShipConstructor : MonoBehaviour
    {
        [SerializeField] private ShipCell[] _shipCells;
        [SerializeField] private ScriptableObject _ship;
        [SerializeField] private StaticData _staticData;
        [SerializeField] private List<ScriptableObject> _selectModules;
        [SerializeField] private List<ScriptableObject> _selectWeapons;

        private void Awake()
        {
            _shipCells = transform.GetComponentsInChildren<ShipCell>();

            foreach(var cell in _shipCells)
            {
                if (cell.SelectModule is ModuleSO)
                    _selectModules.Add(cell.SelectModule);
                else
                    _selectWeapons.Add(cell.SelectModule);
            }
        }
    }
}
