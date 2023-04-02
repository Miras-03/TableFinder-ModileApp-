using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScrollbar : MonoBehaviour
{
    public TMP_Text timeText;
    public Image fillImage;
    public Color freeTableColor;
    public Color bookedTableColor;

    private float startTime = 8f;
    private float endTime = 12f;
    private float timeRange = 4f;
    private float tableAvailability = 0.5f;

    private Scrollbar scrollbar;

    void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    void Update()
    {
        // Calculate the selected time based on the scrollbar value
        float selectedTime = Mathf.Lerp(startTime, endTime, scrollbar.value);

        // Update the time text
        timeText.text = selectedTime.ToString("00") + ":00";

        // Calculate the fill amount of the scrollbar based on the selected time
        float fillAmount = (selectedTime - startTime) / timeRange;
        fillImage.fillAmount = fillAmount;

        // Check the availability of tables at the selected time
        bool freeTables = (Random.value < tableAvailability);

        // Set the color of the fill image based on the availability of tables
        fillImage.color = freeTables ? freeTableColor : bookedTableColor;
    }
}
