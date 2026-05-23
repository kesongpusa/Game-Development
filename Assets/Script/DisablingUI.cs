using UnityEngine;
using UnityEngine.UI;

public class DisablingUI : MonoBehaviour
{
    public GameObject shopButton;
    public GameObject closeShopButton;

    public GameObject textItemRequestsAndScore;
    public GameObject textCustomerItemReqst;
    public GameObject textItemLeft;
    public GameObject textTotalItems;

    public GameObject items;
    public GameObject hoverObjects;
    public GameObject cart;

    public GameObject totalItems;
    public GameObject riceLeftItem, soySauceLeftItem, vinegarLeftItem;
    public void DisableBelowUI()
    {
        textCustomerItemReqst.SetActive(false);
        textItemRequestsAndScore.SetActive(false);
        textItemLeft.SetActive(false);
        textTotalItems.SetActive(false);

        items.SetActive(false);
        hoverObjects.SetActive(false);
        cart.SetActive(false);
    }

    public void EnableBelowUI()
    {
        textCustomerItemReqst.SetActive(true);
        textItemRequestsAndScore.SetActive(true);
        textItemLeft.SetActive(true);
        textTotalItems.SetActive(true);

        items.SetActive(true);
        hoverObjects.SetActive(true);
        cart.SetActive(true);
    }

    public void DisableWhileCalcu()
    {
        totalItems.SetActive(false);
        riceLeftItem.SetActive(false);
        soySauceLeftItem.SetActive(false);
        vinegarLeftItem.SetActive(false);
    }

    public void EnableWhileCalcu()
    {
        totalItems.SetActive(true);
        riceLeftItem.SetActive(true);
        soySauceLeftItem.SetActive(true);
        vinegarLeftItem.SetActive(true);
    }
}
