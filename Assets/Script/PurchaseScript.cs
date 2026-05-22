using UnityEngine;
using UnityEngine.UI;

public class PurchaseScript : MonoBehaviour
{
    public GameObject shopBuyItems;
    public GameObject purchaseButton;

    public Button goyaCandyItem;
    public Button mentosItem;

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

        if (cleanedItemName.Equals("Goya Candy"))
        {
            if (currentCurrency >= 62.50f)
            {
                int currentGoyaCandy = itemsLeft.GetGoyaCandyLeft();

                itemsLeft.SetGoyaCandyLeft(currentGoyaCandy + 50);
                Debug.Log($"[PURCHASE] Current Candy: {itemsLeft.GetGoyaCandyLeft()}");

                playerCurrency.SetCurrentCurrency(currentCurrency - 62.50f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Goya Candy.");
            }
        }
        else if (cleanedItemName.Equals("Mentos"))
        {
            if (currentCurrency >= 84f)
            {
                int currentMentos = itemsLeft.GetMentosLeft();

                itemsLeft.SetMentosLeft(currentMentos + 24);
                Debug.Log($"[PURCHASE] Current Mentos: {itemsLeft.GetMentosLeft()}");

                playerCurrency.SetCurrentCurrency(currentCurrency - 84f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Mentos.");
            }
        }
    }
}
