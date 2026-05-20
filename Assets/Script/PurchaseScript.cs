using UnityEngine;
using UnityEngine.UI;

public class PurchaseScript : MonoBehaviour
{
    public GameObject shopBuyItems;
    public GameObject purchaseButton;

    public Button candyItem;
    public Button cookieItem;

    public ItemsLeft itemsLeft;
    public PlayerCurrency playerCurrency;

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
        float currentCurrency = playerCurrency.GetCurrentCurrency();
        Debug.Log($"[PURCHASE] Current currency: {currentCurrency}");

        if (cleanedItemName.Equals("Candy"))
        {
            if (currentCurrency >= 50f)
            {
                int currentCandy = itemsLeft.GetCandyLeft();

                itemsLeft.SetCandyLeft(currentCandy + 20);
                Debug.Log($"[PURCHASE] Current Candy: {itemsLeft.GetCandyLeft()}");

                playerCurrency.SetCurrentCurrency(currentCurrency - 50f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Candy.");
            }
        }
        else if (cleanedItemName.Equals("Cookies"))
        {
            if (currentCurrency >= 60f)
            {
                int currentCookie = itemsLeft.GetCookieLeft();

                itemsLeft.SetCookieLeft(currentCookie + 20);
                Debug.Log($"[PURCHASE] Current Cookies: {itemsLeft.GetCookieLeft()}");

                playerCurrency.SetCurrentCurrency(currentCurrency - 60f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Cookies.");
            }
        }
    }
}
