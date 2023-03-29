using UnityEngine;
using UnityEngine.UI;
using System;

public class InputData : MonoBehaviour
{
    [SerializeField] InputData inputData;
    private DateTime date;
    private string dateString;

    private void Awake()
    {
        date = DateTime.Now;
        dateString = date.ToString("MM-dd");
    }

    public void OnDateChanged(string dateString)
    {
        if (DateTime.TryParse(dateString, out DateTime newDate))
        {
            date = newDate;
            Debug.Log(date);
        }

        else
            Debug.LogError("Invalid date format");
    }
}
