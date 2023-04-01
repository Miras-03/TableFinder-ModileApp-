using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InputData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateIndicator;
    [SerializeField] private TextMeshProUGUI fromTimeIndicator;
    [SerializeField] private TextMeshProUGUI beforeTimeIndicator;
    [SerializeField] private TextMeshProUGUI hint;

    [SerializeField] private TMP_InputField dateInput;
    [SerializeField] private TMP_InputField fromTimeInput;
    [SerializeField] private TMP_InputField beforeTimeInput;

    [SerializeField] private Button orderButton;

    public DateTime date;
    public DateTime fromTime;
    public DateTime beforeTime;

    private bool checkDate = false;
    private bool checkFromTime = false;
    private bool checkBeforeTime = false;

    private void Awake()
    {
        date = DateTime.Now;
        fromTime = DateTime.Now;
        beforeTime = DateTime.Now;
    }

    private void Update()
    {
        if (checkDate && checkFromTime && checkBeforeTime)
            orderButton.interactable = true;
        else
            orderButton.interactable = false;
    }

    public void OnDateChanged(string dateString)
    {
        if (DateTime.TryParse(dateString, out DateTime newDate))
        {
            date = newDate;

            if (date >= DateTime.Today)
            {
                dateIndicator.text = "Successfully!";
                hint.enabled = false;
                dateIndicator.color = Color.green;
                checkDate = true;
            }
            else
            {
                dateIndicator.text = "Error";
                hint.enabled = true;
                hint.text = "Make sure you have written the date correctly";
                dateIndicator.color = Color.red;
                checkDate = false;
            }
        }
    }

    public void OnFromTimeChanged(string timeString)
    {
        if (DateTime.TryParse(timeString, out DateTime newFromTime))
        {
            fromTime = newFromTime;

            if (fromTime >= DateTime.Now)
            {
                fromTimeIndicator.text = "Successfully!";
                fromTimeIndicator.color = Color.green;
                hint.enabled = false;
                checkFromTime = true;

                // Check if the beforeTime is greater than fromTime
                if (beforeTime > fromTime)
                {
                    beforeTimeIndicator.text = "Successfully!";
                    beforeTimeIndicator.color = Color.green;
                }
                else
                {
                    beforeTimeIndicator.text = "Error";
                    hint.text = "Before time must be greater than from time";
                    beforeTimeIndicator.color = Color.red;
                    checkBeforeTime = false;
                }
            }
            else
            {
                fromTimeIndicator.text = "Error!";
                fromTimeIndicator.color = Color.red;
                hint.enabled = true;
                hint.text = "You made a mistake with the timing!";
                checkFromTime = false;
            }
        }
    }

    public void OnBeforeTimeChanged(string timeString)
    {
        if (DateTime.TryParse(timeString, out DateTime newBefore))
        {
            beforeTime = newBefore;

            if (beforeTime > fromTime)
            {
                beforeTimeIndicator.text = "Successfully!";
                beforeTimeIndicator.color = Color.green;
                checkBeforeTime = true;
                hint.enabled = false;
            }
            else
            {
                beforeTimeIndicator.text = "Error";
                hint.enabled = true;
                hint.text = "Before time must be greater than from time";
                beforeTimeIndicator.color = Color.red;
                checkBeforeTime = false;
            }
        }
    }
}