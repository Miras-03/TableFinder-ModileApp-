using UnityEngine;
using TMPro;
using System;

public class PlaceChoose : MonoBehaviour
{
    private InputData inputDataInstance;

    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI fromTimeText;
    [SerializeField] private TextMeshProUGUI beforeTimedateText;
    [SerializeField] private TextMeshProUGUI intervalResult;

    private DateTime localDate;
    private DateTime localFromTime;
    private DateTime localBeforeTime;
    private TimeSpan timeInterval;

    private float minutesInterval;

    void Start()
    {
        inputDataInstance = FindObjectOfType<InputData>();
        localDate = inputDataInstance.date;
        localFromTime = inputDataInstance.fromTime;
        localBeforeTime = inputDataInstance.beforeTime;

        timeInterval = localBeforeTime - localFromTime;
        minutesInterval = (float)timeInterval.TotalMinutes;

        dateText.text = $"In {localDate.ToString("MMMM dd")}";
        fromTimeText.text = $"{localFromTime.ToString("H:mm")}";
        beforeTimedateText.text = $"{localBeforeTime.ToString("H:mm")}";
        intervalResult.text = $"{minutesInterval.ToString()} minutes";
    }
}
