using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceShips
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] StaticData _staticData;
        [SerializeField] GameUI _gameUI;
        private GameStatus _status;
        private List<Ship> _ships;
        private UIManager _uiManager;
        private BattleModel _battleModel;

        public StaticData Data => _staticData;
        public GameUI UI => _gameUI;
        public GameStatus Status => _status;
        public List<Ship> Ships => _ships;

        public delegate void OnChangeStatus(GameStatus status);
        public OnChangeStatus ChangeStatus;

        private void Awake()
        {
            _gameUI.StartGame.onClick.AddListener(call: () => CreateShip());
            _gameUI.StartGame.onClick.AddListener(call: () => { _status = GameStatus.Battle; ChangeStatus?.Invoke(_status); });
            _gameUI.Restart.onClick.AddListener(call: () => { _status = GameStatus.Prepare; ChangeStatus?.Invoke(_status); });
            _status = GameStatus.Prepare;
            _uiManager = new(this);
            _battleModel = new(this);
        }

        private void FixedUpdate()
        {
            _uiManager.UpdateUI();

            if(_status == GameStatus.Battle)
            {
                _battleModel.Battle();
                foreach(var ship in _ships)
                {
                    if (ship.ShipInfo.CurrentHealth <= 0)
                    {
                        _status = GameStatus.End;
                        ChangeStatus?.Invoke(_status);
                    }
                }
            }
        }

        private void CreateShip()
        {
            _ships = new();

            ShipFabricNoECS fabric = new();
            foreach (var constructor in _gameUI.Constructors)
            {
                _ships.Add(fabric.CreateShip(constructor.SelectModules.Select(x => (ModuleSO)x).ToList(),
                                    constructor.SelectWeapons.Select(x => (WeaponSO)x).ToList(),
                                    constructor.Ship, this));
            }
        }
    }
}
