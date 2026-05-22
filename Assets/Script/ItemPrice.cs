using UnityEngine;

public class ItemPrice : MonoBehaviour
{
    public float goyaCandyPrice = 2.00f;
    public float mentosPrice = 5.0f;
    public float ricePrice = 13.00f;
    public float soySaucePrice = 3.00f;
    public float vinegarPrice = 2.50f;

    private float totalPrice = 0f;

    public float GetPrice(string itemName)
    {
        switch (itemName.ToLower())
        {
            case "goya candy":
                return goyaCandyPrice;
            case "mentos":
                return mentosPrice;
            case "rice":
                return ricePrice;
            case "soy sauce":
                return soySaucePrice;
            case "vinegar":
                return vinegarPrice;
            default:
                Debug.LogWarning("Unknown item: " + itemName);
                return 0f;
        }
    }

    public void SetTotalPrice(float price)
    {
        totalPrice += price;
        Debug.Log("[ITEMPRICE] Total price set to: ₱" + totalPrice);
    }

    public void ResetTotalPrice()
    {
        totalPrice = 0f;
        Debug.Log("[ITEMPRICE] Total price reset to: ₱" + totalPrice);
    }

    public float GetTotalPrice()
    {
        Debug.Log("[ITEMPRICE] Total price: ₱" + totalPrice);
        return totalPrice;
    }
}
