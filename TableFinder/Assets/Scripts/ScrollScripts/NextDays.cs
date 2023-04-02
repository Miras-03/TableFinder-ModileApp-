using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NextDays : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] displayText;
    [SerializeField] private Button[] dayButtons;
    [SerializeField] private TMP_InputField inputField;

    private DateTime currentDateTime;

    private byte sizeOfWeek = 7;

    private void Start()
    {
        SetCurrentDateTime();
    }

    public void SetCurrentDateTime()
    {
        DateTime.TryParse(inputField.text, out currentDateTime);

        if (currentDateTime == DateTime.MinValue)
            currentDateTime = DateTime.Today;

        DateTime buttonDateTime = currentDateTime;

        for (int i = 0; i < sizeOfWeek; i++)
        {
            dayButtons[i].interactable = true;

            if (buttonDateTime.ToString("dddd, MMMM dd") == inputField.text)
                dayButtons[i].interactable = false;

            buttonDateTime = currentDateTime.AddDays(i);
        }

        /*int selectedIndex = (int)(currentDateTime - currentDateTime.Date).TotalDays;
        dayButtons[selectedIndex].Select();*/

        for (int i = 0; i < sizeOfWeek; i++)
        {
            DateTime nextDay = currentDateTime.AddDays(i);
            string nextDays = nextDay.ToString("dddd, MMMM dd");
            displayText[i].text = nextDays;
        }
    }
}