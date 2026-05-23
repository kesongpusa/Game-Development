using UnityEngine;

public class ItemPrice : MonoBehaviour
{
    public float goyaCandyPrice = 2.00f;
    public float mentosPrice = 5.0f;
    public float ricePrice = 13.00f;
    public float soySaucePrice = 3.00f;
    public float vinegarPrice = 2.50f;
    public float whiteRabbitPrice = 0.25f;
    public float surfPrice = 2.00f;
    public float joyPrice = 2.00f;
    public float paylessXtraBigPrice = 6.00f;
    public float luckyMePrice = 5.00f;
    public float cupNoodlePrice = 12.00f;
    public float colgatePrice = 3.00f;
    public float rexonaPrice = 15.00f;
    public float sunsilkPrice = 2.00f;

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
            case "white rabbit":
                return whiteRabbitPrice;
            case "joy":
                return joyPrice;
            case "surf":
                return surfPrice;
            case "payless xtra big":
                return paylessXtraBigPrice;
            case "lucky me":
                return luckyMePrice;
            case "cup noodle":
                return cupNoodlePrice;
            case "colgate":
                return colgatePrice;
            case "rexona":
                return rexonaPrice;
            case "sunsilk":
                return sunsilkPrice;
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
