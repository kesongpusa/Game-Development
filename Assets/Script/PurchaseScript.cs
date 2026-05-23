using UnityEngine;
using UnityEngine.UI;

public class PurchaseScript : MonoBehaviour
{
    public GameObject shopBuyItems;
    public GameObject purchaseButton;

    public Button goyaCandyItem;
    public Button mentosItem;
    public Button whiteRabbitItem;
    public Button riceItem;
    public Button soySauceItem;
    public Button vinegarItem;
    public Button surfItem;
    public Button joyItem;
    public Button paylessXtraBigItem;
    public Button luckyMeItem;
    public Button cupNoodleItem;
    public Button colgateItem;
    public Button rexonaItem;
    public Button sunsilkItem;

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
        else if (cleanedItemName.Equals("White Rabbit"))
        {
            if (currentCurrency >= 20f)
            {
                int currentWhiteRabbit = itemsLeft.GetWhiteRabbitLeft();
                itemsLeft.SetWhiteRabbitLeft(currentWhiteRabbit + 10);
                Debug.Log($"[PURCHASE] Current White Rabbit: {itemsLeft.GetWhiteRabbitLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 20f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase White Rabbit.");
            }
        }
        else if (cleanedItemName.Equals("Rice"))
        {
            if (currentCurrency >= 300f)
            {
                int currentRice = itemsLeft.GetRiceLeft();
                itemsLeft.SetRiceLeft(currentRice + 25);
                Debug.Log($"[PURCHASE] Current Rice: {itemsLeft.GetRiceLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 300f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Rice.");
            }
        }
        else if (cleanedItemName.Equals("Soy Sauce"))
        {
            if (currentCurrency >= 24f)
            {
                int currentSoySauce = itemsLeft.GetSoySauceLeft();
                itemsLeft.SetSoySauceLeft(currentSoySauce + 12);
                Debug.Log($"[PURCHASE] Current Soy Sauce: {itemsLeft.GetSoySauceLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 24f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Soy Sauce.");
            }
        }
        else if (cleanedItemName.Equals("Vinegar"))
        {
            if (currentCurrency >= 21f)
            {
                int currentVinegar = itemsLeft.GetVinegarLeft();
                itemsLeft.SetVinegarLeft(currentVinegar + 12);
                Debug.Log($"[PURCHASE] Current Vinegar: {itemsLeft.GetVinegarLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 21f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Vinegar.");
            }
        }
        else if (cleanedItemName.Equals("Joy"))
        {
            if (currentCurrency >= 31.25f)
            {
                int currentJoy = itemsLeft.GetJoyLeft();
                itemsLeft.SetJoyLeft(currentJoy + 25);
                Debug.Log($"[PURCHASE] Current Joy: {itemsLeft.GetJoyLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 31.25f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Joy.");
            }
        }
        else if (cleanedItemName.Equals("Surf"))
        {
            if (currentCurrency >= 31.25f)
            {
                int currentSurf = itemsLeft.GetSurfLeft();
                itemsLeft.SetSurfLeft(currentSurf + 25);
                Debug.Log($"[PURCHASE] Current Surf: {itemsLeft.GetSurfLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 31.25f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Surf.");
            }
        }
        else if (cleanedItemName.Equals("Payless Xtra Big"))
        {
            if (currentCurrency >= 54f)
            {
                int currentPaylessXtraBig = itemsLeft.GetPaylessXtraBigLeft();
                itemsLeft.SetPaylessXtraBigLeft(currentPaylessXtraBig + 12);
                Debug.Log($"[PURCHASE] Current Payless Xtrabig: {itemsLeft.GetPaylessXtraBigLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 54f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Payless Xtra Big.");
            }
        }
        else if (cleanedItemName.Equals("Lucky Me"))
        {
            if (currentCurrency >= 84f)
            {
                int currentLuckyMe = itemsLeft.GetLuckyMeLeft();
                itemsLeft.SetLuckyMeLeft(currentLuckyMe + 24);
                Debug.Log($"[PURCHASE] Current Lucky Me: {itemsLeft.GetLuckyMeLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 84f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Lucky Me.");
            }
        }
        else if (cleanedItemName.Equals("Cup Noodle"))
        {
            if (currentCurrency >= 108f)
            {
                int currentCupNoodle = itemsLeft.GetCupNoodleLeft();
                itemsLeft.SetCupNoodleLeft(currentCupNoodle + 12);
                Debug.Log($"[PURCHASE] Current Cup Noodle: {itemsLeft.GetCupNoodleLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 108f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Cup Noodle.");
            }
        }
        else if (cleanedItemName.Equals("Colgate"))
        {
            if (currentCurrency >= 48f)
            {
                int currentColgate = itemsLeft.GetColgateLeft();
                itemsLeft.SetColgateLeft(currentColgate + 24);
                Debug.Log($"[PURCHASE] Current Colgate: {itemsLeft.GetColgateLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 48f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Colgate.");
            }
        }
        else if (cleanedItemName.Equals("Rexona"))
        {
            if (currentCurrency >= 144f)
            {
                int currentRexona = itemsLeft.GetRexonaLeft();
                itemsLeft.SetRexonaLeft(currentRexona + 12);
                Debug.Log($"[PURCHASE] Current Rexona: {itemsLeft.GetRexonaLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 144f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Rexona.");
            }
        }
        else if (cleanedItemName.Equals("Sunsilk"))
        {
            if (currentCurrency >= 30f)
            {
                int currentSunsilk = itemsLeft.GetSunsilkLeft();
                itemsLeft.SetSunsilkLeft(currentSunsilk + 24);
                Debug.Log($"[PURCHASE] Current Sunsilk: {itemsLeft.GetSunsilkLeft()}");
                playerCurrency.SetCurrentCurrency(currentCurrency - 30f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Sunsilk.");
            }
        }
        else
        {
            Debug.LogWarning($"[PURCHASE] Unknown item: {cleanedItemName}");
        }
    }
}
