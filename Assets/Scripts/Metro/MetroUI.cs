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
            string pathString = "";
            for (int i = 0; i < path.PathStory.Count; i++)
            {
                if (i < path.PathStory.Count - 1 && path.PathStory.Count > 1)
                    pathString += path.PathStory[i].Name + "-->";
                else
                    pathString += path.PathStory[i].Name;
            }
            _result.text = $"Кратчайший путь \nПромежуточный станций: {path.Steps} \nПересадок: {path.TransferCount} \nПуть: {pathString}";
        }
    }
}