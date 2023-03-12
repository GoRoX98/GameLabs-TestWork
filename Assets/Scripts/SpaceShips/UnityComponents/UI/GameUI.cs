using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShips
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Button _startGame;
        [SerializeField] private Button _restart;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private TextMeshProUGUI _winner;
        [SerializeField] private List<ShipConstructor> _constructors;
        [SerializeField] private List<ShipUI> _shipsUI;

        public Button StartGame => _startGame;
        public Button Restart => _restart;
        public GameObject WinPanel => _winPanel;
        public TextMeshProUGUI Winner => _winner;
        public List<ShipConstructor> Constructors => _constructors;
        public List<ShipUI> ShipsUI => _shipsUI;
    }
}
