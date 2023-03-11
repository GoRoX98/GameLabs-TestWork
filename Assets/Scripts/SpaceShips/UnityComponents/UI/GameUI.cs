using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShips
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Button _startGame;
        [SerializeField] private List<ShipConstructor> _constructors;
        [SerializeField] private List<ShipUI> _shipsUI;

        public Button StartGame => _startGame;
        public List<ShipConstructor> Constructors => _constructors;
        public List<ShipUI> ShipsUI => _shipsUI;
    }
}
