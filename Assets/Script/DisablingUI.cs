using UnityEngine;
using UnityEngine.UI;

public class DisablingUI : MonoBehaviour
{
    public GameObject shopButton;
    public GameObject closeShopButton;

    public GameObject textItemRequestsAndScore;
    public GameObject textItemLeft;
    public GameObject textTotalItems;

    public GameObject items;
    public GameObject hoverObjects;
    public GameObject cart;
    public void DisableBelowUI()
    {
        textItemRequestsAndScore.SetActive(false);
        textItemLeft.SetActive(false);
        textTotalItems.SetActive(false);

        items.SetActive(false);
        hoverObjects.SetActive(false);
        cart.SetActive(false);
    }

    public void EnableBelowUI()
    {
        textItemRequestsAndScore.SetActive(true);
        textItemLeft.SetActive(true);
        textTotalItems.SetActive(true);

        items.SetActive(true);
        hoverObjects.SetActive(true);
        cart.SetActive(true);
    }
}
