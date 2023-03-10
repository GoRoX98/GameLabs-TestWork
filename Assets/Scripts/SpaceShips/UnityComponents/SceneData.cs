using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShips
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private List<ShipObject> _shipsObject;
        [SerializeField] private List<ShipConstructor> _shipConstructors;
        public List<ShipObject> ShipsObject => _shipsObject;
        public List<ShipConstructor> ShipConstructors => _shipConstructors;
    }
}
