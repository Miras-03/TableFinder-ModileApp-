using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    [SerializeField] private Button[] tabs;
    [SerializeField] private GameObject[] pages;
    [SerializeField] private Button orderingButton;

    [SerializeField] private Image[] image;
    [SerializeField] private Color selectedTabColor;
    [SerializeField] private Color unselectedTabColor;

    void Start()
    {
        foreach (var page in pages)
            page.SetActive(false);
        ShowPanel(pages[0]);

        foreach (var tab in image)
            tab.GetComponent<Image>().color = unselectedTabColor;
        image[0].GetComponent<Image>().color = selectedTabColor;
    }

    public void ShowPanel(GameObject pageToShow)
    {
        foreach (var item in pages)
            item.SetActive(false);

        pageToShow.SetActive(true);
    }

    public void OnTabSelected(Image selectedTab)
    {
        foreach (var tab in image)
            tab.GetComponent<Image>().color = unselectedTabColor;
        selectedTab.GetComponent<Image>().color = selectedTabColor;
    }
}