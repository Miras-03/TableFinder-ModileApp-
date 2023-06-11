using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static RealTime;

public class InputData : MonoBehaviour, ITimeObserver
{
    [SerializeField] private TextMeshProUGUI dateIndicator;
    [SerializeField] private TextMeshProUGUI fromTimeIndicator;
    [SerializeField] private TextMeshProUGUI beforeTimeIndicator;
    [SerializeField] private TextMeshProUGUI hint;

    [SerializeField] private TMP_InputField dateInput;
    [SerializeField] private TMP_InputField fromTimeInput;
    [SerializeField] private TMP_InputField beforeTimeInput;

    [SerializeField] private Button orderButton;

    private DateTime inputDate;
    public DateTime inputFromTime;

    public DateTime date;
    public DateTime fromTime;
    public DateTime beforeTime;

    private bool checkDate = false;
    private bool checkFromTime = false;
    private bool checkBeforeTime = false;

    private void Awake()
    {
        RealTime realTime = FindObjectOfType<RealTime>();
        realTime.SubscribeObserver(this);
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
            inputDate = newDate;
            if (date <= inputDate)
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
            inputFromTime = newFromTime;
            if (date == inputDate)
            {
                if (fromTime.AddMinutes(29) <= inputFromTime)
                {
                    fromTimeIndicator.text = "Successfully!";
                    fromTimeIndicator.color = Color.green;
                    hint.enabled = false;
                    checkFromTime = true;
                }

                else
                {
                    fromTimeIndicator.text = "Error!";
                    fromTimeIndicator.color = Color.red;
                    hint.enabled = true;
                    hint.text = "It isn't possible to order a table less than 30 minutes";
                    checkFromTime = false;
                }
            }
            
            else if(date > inputDate)
            {
                fromTimeIndicator.text = "Successfully!";
                fromTimeIndicator.color = Color.green;
                checkFromTime = true;
            }

            else
            {
                fromTimeIndicator.text = "Error!";
                fromTimeIndicator.color = Color.red;
                hint.enabled = true;
                hint.text = "You made a mistake with the date!";
                checkDate = false;
            }
        }
    }

    public void OnBeforeTimeChanged(string timeString)
    {
        if (DateTime.TryParse(timeString, out DateTime newBefore))
        {
            beforeTime = newBefore;
            if (beforeTime > inputFromTime.AddMinutes(14))
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
                hint.text = "We can't order a table less than 15 minutes";
                beforeTimeIndicator.color = Color.red;
                checkBeforeTime = false;
            }
        }
    }

    public void OnTimeUpdated(DateTime newTime)
    {
        date = newTime.Date;
        fromTime = newTime;
    }
}