namespace SpaceShips
{
    public class UIManager
    {
        private GameManager _gameManager;

        public UIManager(GameManager gm)
        {
            _gameManager = gm;
            _gameManager.ChangeStatus += ChangeGameStatus;
        }

        public void UpdateUI()
        {
            if (_gameManager.Status == GameStatus.Battle)
                UpdateBattleUI();
        }

        private void ChangeGameStatus(GameStatus status)
        {
            if(status == GameStatus.Prepare)
                UpdateBattleUI(true);
            else if (status == GameStatus.End)
            {
                UpdateBattleUI();
                WinUI();
            }
        }

        private void UpdateBattleUI(bool reset = false)
        {
            if (reset)
            {
                for (int i = 0; i < _gameManager.UI.ShipsUI.Count; i++)
                {
                    _gameManager.UI.ShipsUI[i].Life.value = 1;
                    _gameManager.UI.ShipsUI[i].Shield.value = 1;
                }
            }
            else
            {
                for (int i = 0; i < _gameManager.UI.ShipsUI.Count; i++)
                {
                    ShipInfoComponent ship = _gameManager.Ships[i].ShipInfo;
                    _gameManager.UI.ShipsUI[i].Life.value = ship.CurrentHealth / ship.StartHealth;
                    _gameManager.UI.ShipsUI[i].Shield.value = ship.CurrentShield / ship.StartShield;
                }
            }
        }

        private void WinUI()
        {
            _gameManager.UI.WinPanel.SetActive(true);
            foreach (var ship in _gameManager.Ships)
            {
                if (ship.ShipInfo.CurrentHealth > 0)
                {
                    _gameManager.UI.Winner.text = $"{ship.ShipInfo.ShipName} WIN";
                    return;
                }
            }
        }
    }
}