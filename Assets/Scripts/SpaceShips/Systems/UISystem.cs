using Leopotam.Ecs;

namespace SpaceShips 
{
    sealed class UISystem : IEcsRunSystem 
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GameUI _gameUI;
        private EcsFilter<GameStatusComponent> _status;
        private EcsFilter<ShipInfoComponent> _filterShips;
        private EcsFilter<ChangeStatusComponent> _filterStatusUpdate;
        
        public void Run() 
        {
            if (_status.Get1(0).Status == GameStatus.Battle)
                UpdateBattleUI();

            if(!_filterStatusUpdate.IsEmpty())
            {
                if (_status.Get1(0).Status == GameStatus.Prepare)
                    UpdateBattleUI(true);
                else if (_status.Get1(0).Status == GameStatus.End)
                {
                    UpdateBattleUI();
                    WinUI();
                }

                _filterStatusUpdate.GetEntity(0).Destroy();
            }
        }

        private void UpdateBattleUI(bool reset = false)
        {
            if (reset)
            {
                for (int i = 0; i < _gameUI.ShipsUI.Count; i++)
                {
                    _gameUI.ShipsUI[i].Life.value = 1;
                    _gameUI.ShipsUI[i].Shield.value = 1;
                }
            }
            else
            {
                for (int i = 0; i < _gameUI.ShipsUI.Count; i++)
                {
                    ShipInfoComponent ship = _filterShips.Get1(i);
                    _gameUI.ShipsUI[i].Life.value = ship.CurrentHealth / ship.StartHealth;
                    _gameUI.ShipsUI[i].Shield.value = ship.CurrentShield / ship.StartShield;
                }
            }
        }

        private void WinUI()
        {
            _gameUI.WinPanel.SetActive(true);
            foreach (var i in _filterShips)
            {
                if (_filterShips.Get1(i).CurrentHealth > 0)
                {
                    _gameUI.Winner.text = $"{_filterShips.Get1(i).ShipName} WIN";
                    return;
                }
            }
        }
    }
}