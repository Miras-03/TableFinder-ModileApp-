using UnityEngine;
using TMPro;
using System;

public class InputData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateIndicator;
    [SerializeField] private TextMeshProUGUI fromTimeIndicator;
    [SerializeField] private TextMeshProUGUI beforeTimeIndicator;
    public DateTime date;
    public DateTime fromTime;
    public DateTime beforeTime;

    private void Awake()
    {
        date = DateTime.Now;
        fromTime = DateTime.Now;
        beforeTime = DateTime.Now;
    }

    public void OnDateChanged(string dateString)
    {
        if (DateTime.TryParse(dateString, out DateTime newDate))
        {
            date = newDate;
            dateIndicator.text = $"Successfully!";
            dateIndicator.color = Color.green;
        }

        else
        {
            dateIndicator.text = $"Error!";
            dateIndicator.color = Color.red;
        }
    }

    public void OnFromTimeChanged(string timeString)
    {
        if (DateTime.TryParse(timeString, out DateTime newDate))
        {
            fromTime = newDate;
            fromTimeIndicator.text = $"Successfully!";
            fromTimeIndicator.color = Color.green;
        }

        else
        {
            fromTimeIndicator.text = $"Error!";
            fromTimeIndicator.color = Color.red;
        }
    }

    public void OnBeforeTimeChanged(string timeString)
    {
        if (DateTime.TryParse(timeString, out DateTime newDate))
        {
            beforeTime = newDate;
            beforeTimeIndicator.text = $"Successfully!";
            beforeTimeIndicator.color = Color.green;
        }

        else
        {
            beforeTimeIndicator.text = $"Error!";
            beforeTimeIndicator.color = Color.red;
        }
    }
}
