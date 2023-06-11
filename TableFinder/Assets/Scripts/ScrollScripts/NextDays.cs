using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NextDays : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] displayText;
    [SerializeField] private Button[] dayButtons;
    [SerializeField] private GameObject[] buttonBelong;
    [SerializeField] private GameObject[] contentDays;
    [SerializeField] private GameObject[] tablePanels;

    private DateTime currentDateTime;
    private DateTime choosenDate;

    private byte sizeOfWeek = 7;
    private byte index;

    private bool flagOfTable = false;

    private void Start()
    {
        currentDateTime = DateTime.Today;
    }

    public void SetCurrentDateTime(string inputText)
    {
        if (DateTime.TryParse(inputText, out DateTime newText))
        {
            choosenDate = newText;
            DateTime buttonDateTime = currentDateTime;

            for (byte i = 0; i < sizeOfWeek; i++)
            {
                dayButtons[i].interactable = true;
                string buttonDateString = buttonDateTime.ToString("MMMM dd");

                if (buttonDateString == choosenDate.ToString("MMMM dd"))
                {
                    contentDays[i].SetActive(true);
                    dayButtons[i].interactable = false;
                    dayButtons[i].Select();
                }
                buttonDateTime = currentDateTime.AddDays(i + 1);
            }

            for (byte i = 0; i < sizeOfWeek; i++)
            {
                DateTime nextDay = currentDateTime.AddDays(i);
                string nextDays = nextDay.ToString("dddd, MMMM dd");
                displayText[i].text = nextDays;
            }
        }
    }

    public void OnPlaceTabSelected(int theIndex)
    {
        for (byte i = 0; i < sizeOfWeek; i++)
        {
            dayButtons[i].interactable = true;
            contentDays[i].SetActive(false);
        }

        dayButtons[theIndex].interactable = false;
        contentDays[theIndex].SetActive(true);
    }

    public void BackButton()
    {
        if (flagOfTable)
        {
            tablePanels[index].SetActive(false);
            flagOfTable = false;
        }
        else
        {
            foreach (GameObject item in buttonBelong)
                item.SetActive(false);
        }
    }
    public void SetIndexForButton(int index)
    {
        this.index = (byte)index;
        flagOfTable = true;
    }
}
