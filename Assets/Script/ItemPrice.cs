using UnityEngine;

public class ItemPrice : MonoBehaviour
{
    public float candyPrice = 0.5f;
    public float cookiePrice = 1.0f;

    private float totalPrice = 0f;

    public float GetPrice(string itemName)
    {
        switch (itemName.ToLower())
        {
            case "piece of candy":
                return candyPrice;
            case "cookie":
                return cookiePrice;
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
