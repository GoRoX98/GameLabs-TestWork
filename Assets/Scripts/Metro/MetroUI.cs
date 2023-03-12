using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Metro
{
    public class MetroUI : MonoBehaviour
    {
        [SerializeField] private StationsUI _stationsUI;
        [SerializeField] private Button _calculate;
        [SerializeField] private TextMeshProUGUI _result;

        public StationsUI StationsUI => _stationsUI;
        public Button Calculate => _calculate;

        public void Result(Path path)
        {
            _result.text = $"Кратчайший путь \nПромежуточный станций: {path.Steps - 1} \nПересадок: {path.TransferCount}";
        }
    }
}