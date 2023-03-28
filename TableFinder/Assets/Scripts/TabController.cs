using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    [SerializeField] private Button[] tabs;
    [SerializeField] private GameObject[] pages;
    private const int SIZE = 4;

    void Start()
    {
        foreach (var item in pages)
            item.SetActive(false);

        ShowPanel(pages[0]);
    }

    public void ShowPanel(GameObject pageToShow)
    {
        foreach (var item in pages)
            item.SetActive(false);

        pageToShow.SetActive(true);
    }
}