using UnityEngine;
using TMPro;

public class InputData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI indicator;
    private Time startTime;

    public void Time(Time startTime)
    {
        this.startTime = startTime;
        indicator.text = $"{startTime}";
    }
}
