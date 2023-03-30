using UnityEngine;
using TMPro;
using System;

public class PlaceChoose : MonoBehaviour
{
    InputData inputDataInstance;

    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI fromTimeText;
    [SerializeField] private TextMeshProUGUI beforeTimedateText;

    private DateTime localDate;
    private DateTime localFromTime;
    private DateTime localBeforeTime;

    void Start()
    {
        inputDataInstance = FindObjectOfType<InputData>();

        localDate = inputDataInstance.date;
        localFromTime = inputDataInstance.fromTime;
        localBeforeTime = inputDataInstance.beforeTime;

        dateText.text = $"In {localDate.ToString("MMMM dd")}";
        fromTimeText.text = $"{localFromTime.ToString("H:mm")}";
        beforeTimedateText.text = $"{localBeforeTime.ToString("H:mm")}";
    }
}
