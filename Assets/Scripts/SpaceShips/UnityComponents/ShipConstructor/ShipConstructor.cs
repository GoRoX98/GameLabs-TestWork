using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShips
{
    public class ShipConstructor : MonoBehaviour
    {
        [SerializeField] private ShipCell[] _shipCells;
        [SerializeField] private ShipSO _ship;
        [SerializeField] private ShipObject _shipObj;
        [SerializeField] private StaticData _staticData;
        private List<ScriptableObject> _selectModules;
        private List<ScriptableObject> _selectWeapons;

        public ShipSO Ship => _ship;
        public ShipObject ShipObj => _shipObj;
        public List<ScriptableObject> SelectModules => _selectModules;
        public List<ScriptableObject> SelectWeapons => _selectWeapons;

        private void Awake()
        {
            _shipCells = transform.GetComponentsInChildren<ShipCell>();
            SetElements();
        }

        private void SetElements()
        {
            int countM = 0;
            int countW = 0;

            for (int i = 0; i < _shipCells.Length; i++)
            {
                if(countM < _ship.Ship.ModulesCount)
                {
                    
                    _shipCells[i].Init(_staticData.Modules.ToList<ScriptableObject>());
                    countM += 1;
                }
                else
                {
                    _shipCells[i].Init(_staticData.Weapons.ToList<ScriptableObject>());
                    countW += 1;
                }
            }
        }

        public void ConstructShip()
        {
            _selectModules = new List<ScriptableObject>();
            _selectWeapons = new List<ScriptableObject>();

            foreach (var cell in _shipCells)
            {
                if (cell.GetSelectElement() is ModuleSO)
                    _selectModules.Add(cell.GetSelectElement());
                else
                    _selectWeapons.Add(cell.GetSelectElement());
            }
        }


    }
}
