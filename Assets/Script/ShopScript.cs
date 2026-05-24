using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject nextPageButton;
    public GameObject previousPageButton;
    public GameObject pages;

    public Text currentPageNumberText;

    private int currentPage = 1;
    private int pagesCount = 0;

    private void Start()
    {

        for (int i = 0; i < pages.transform.childCount; i++)
        {
            if (pages.transform.GetChild(i).gameObject)
            {
                pagesCount++;
            }
        }
        Debug.Log("[SHOP] Total Pages: " + pagesCount);
        currentPageNumberText.text = $"Page {currentPage.ToString()}/{pagesCount}";
    }

    public void NextPage()
    {
        currentPage++;

        pages.transform.GetChild(pagesCount - currentPage).gameObject.SetActive(false);
        pages.transform.GetChild(pagesCount - currentPage + 1).gameObject.SetActive(true);

        if (currentPage == pagesCount)
        {
            nextPageButton.SetActive(false);
            previousPageButton.SetActive(true);
        }
        else
        {
            nextPageButton.SetActive(true);
            previousPageButton.SetActive(true);
        }

        UpdatePageText();
    }

    public void PreviousPage()
    {
        currentPage--;
        pages.transform.GetChild(pagesCount - currentPage - 1).gameObject.SetActive(true);
        pages.transform.GetChild(pagesCount - currentPage).gameObject.SetActive(false);

        if (currentPage == 1)
        {
            nextPageButton.SetActive(true);
            previousPageButton.SetActive(false);
        }
        else
        {
            nextPageButton.SetActive(true);
            previousPageButton.SetActive(true);
        }

        UpdatePageText();
    }

    private void UpdatePageText()
    {
        currentPageNumberText.text = $"Page {currentPage.ToString()}/{pagesCount}";
    }
}
