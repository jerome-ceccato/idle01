using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsTabBarController : MonoBehaviour
{
    public GameObject homeTab;
    public GameObject buildingsTab;
    public GameObject upgradesTab;

    public GameObject homePage;
    public GameObject buildingsPage;
    public GameObject upgradesPage;

    private List<GameObject> allPages;

    void Start()
    {
        homeTab.GetComponent<Button>().onClick.AddListener(() => SelectPage(homePage));
        buildingsTab.GetComponent<Button>().onClick.AddListener(() => SelectPage(buildingsPage));
        upgradesTab.GetComponent<Button>().onClick.AddListener(() => SelectPage(upgradesPage));

        allPages = new List<GameObject>()
        {
            homePage, buildingsPage, upgradesPage
        };
    }

    private void SelectPage(GameObject page)
    {
        foreach (GameObject aPage in allPages)
        {
            aPage.SetActive(aPage == page);
        }
    }
}
