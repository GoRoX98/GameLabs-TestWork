using TMPro;
using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    public class StationsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _startStation;
        [SerializeField] private TMP_Dropdown _endStation;
        [SerializeField] List<StationSO> _allStations;
        private StationSO _startStationSO;
        private StationSO _endStationSO;

        public StationSO StartStationSO => _startStationSO;
        public StationSO EndStationSO => _endStationSO;

        private void Awake()
        {
            _startStation.options.Clear();
            _endStation.options.Clear();

            foreach(var station in _allStations)
            {
                _startStation.options.Add(new(station.Name));
                _endStation.options.Add(new(station.Name));
            }

            UpdateSelectStations();
        }

        public void UpdateSelectStations()
        {
            _startStationSO = _allStations.Find(match => match.Name == _startStation.captionText.text);
            _endStationSO = _allStations.Find(match => match.Name == _endStation.captionText.text);
        }

    }
}