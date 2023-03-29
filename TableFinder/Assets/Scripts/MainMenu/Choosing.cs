using UnityEngine;
using UnityEngine.UI;

public class Choosing : MonoBehaviour
{
    [SerializeField] private Button orderingButton;
    [SerializeField] private Button restaurantButton;

    [SerializeField] private GameObject orderingPanel;
    [SerializeField] private GameObject restaurantPanel;

    void Start()
    {
        ShowRestaurantPanel();
    }

    public void ShowOrderingPanel()
    {
        orderingButton.interactable = false;
        restaurantButton.interactable = true;
        orderingPanel.SetActive(true);
        restaurantPanel.SetActive(false);
    }

    public void ShowRestaurantPanel()
    {
        restaurantButton.interactable = false;
        orderingButton.interactable = true;
        restaurantPanel.SetActive(true);
        orderingPanel.SetActive(false);
    }
}
