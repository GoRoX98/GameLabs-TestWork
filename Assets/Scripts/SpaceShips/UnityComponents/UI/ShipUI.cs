using UnityEngine.UI;
using UnityEngine;

public class ShipUI : MonoBehaviour
{
    [SerializeField] private Slider _life;
    [SerializeField] private Slider _shield;

    public Slider Life => _life;
    public Slider Shield => _shield;
}
