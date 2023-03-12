using UnityEngine;

namespace Metro
{
    [CreateAssetMenu(fileName = "Station", menuName = "Metro/New Station")]
    public class StationSO : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;
    }
}