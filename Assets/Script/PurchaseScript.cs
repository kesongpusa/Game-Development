using UnityEngine;
using UnityEngine.UI;

public class PurchaseScript : MonoBehaviour
{
    public GameObject shopBuyItems;
    public GameObject purchaseButton;

    public Button candyItem;
    public Button cookieItem;

    public ItemsLeft itemsLeft;

    public void ShowPurchaseItems()
    {
        shopBuyItems.SetActive(true);
        purchaseButton.SetActive(false);
    }

    public void CloseInventoryShop()
    {
        shopBuyItems.SetActive(false);
        purchaseButton.SetActive(true);
    }
    public void PurchaseItem(Button buttonText)
    {
        string itemName = buttonText.GetComponentInChildren<Text>().text;
        Debug.Log($"[PURCHASE] Attempting to purchase: {itemName}");

        string cleanedItemName = itemName.Substring(4);

        if (cleanedItemName.Equals("Candy"))
        {
            int currentCandy = itemsLeft.GetCandyLeft();

            itemsLeft.SetCandyLeft(currentCandy + 20);
            Debug.Log($"[PURCHASE] Current Candy: {itemsLeft.GetCandyLeft()}");
        }
        else if (cleanedItemName.Equals("Cookies"))
        {
            int currentCookie = itemsLeft.GetCookieLeft();

            itemsLeft.SetCookieLeft(currentCookie + 20);
            Debug.Log($"[PURCHASE] Current Cookies: {itemsLeft.GetCookieLeft()}");
        }
    }
}
