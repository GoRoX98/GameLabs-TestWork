using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    [CreateAssetMenu(fileName = "Line", menuName = "Metro/New Line")]
    public class LineSO : ScriptableObject
    {
        [SerializeField] private List<StationSO> _stations;
        [SerializeField] private bool _ringLine;

        public List<StationSO> Stations => _stations;
        public bool RingLine => _ringLine;
    }
}