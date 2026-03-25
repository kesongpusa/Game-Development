using UnityEngine;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour
{
    private int orderQuantity;
    public Text quantityText;

    public GameObject getCandy; 
    public GameObject getCookie;

    public Text candyQuantityText;
    public Text cookieQuantityText;

    private int roll, quantity;
    private int[] quantities;

    public GameObject customer;

    private void Start()
    {
        GetOrderRandomizer();
    }
    public void addScoreToOrder(int addItemsOrder)
    {
        orderQuantity = orderQuantity + addItemsOrder;
        quantityText.text = $"Cat Ate: {orderQuantity.ToString()}";

        Debug.Log($"Order quantity updated: {orderQuantity}");
    }

    void GetOrderRandomizer()
    {
        roll = Random.Range(0, 2);

        /*
        0 = Candy
        1 = Cookie
        2 = Candy + Cookie
        */

        if (roll == 0)
        { Debug.Log("Random: Piece of Candy"); }
        else if (roll == 1)
        { Debug.Log("Random: Cookie"); }
        else
        { Debug.Log("Random: Candy + Cookie"); }

        GetQuantityOrderRandomizer(roll);
    }

    void GetQuantityOrderRandomizer(int roll)
    {
        quantity = Random.Range(1, 10);

        if (roll == 0)
        {
            candyQuantityText.enabled = true;

            Debug.Log($"Quantity (Piece of Candy): {quantity}");
            candyQuantityText.text = $"Candy Req: {quantity}";
        }
        else if (roll == 1)
        {
            cookieQuantityText.enabled = true;

            Debug.Log($"Quantity (Cookie): {quantity}");
            cookieQuantityText.text = $"Cookie Req: {quantity}";
        }
        else
        {
            quantities = new int[2];

            for (int i = 0; i < 2; i++)
            {
                quantities[i] = Random.Range(1, 10);
            }

            candyQuantityText.enabled = true;
            cookieQuantityText.enabled = true;

            Debug.Log($"Quantity (Candy): {quantities[0]}");
            Debug.Log($"Quantity (Cookie): {quantities[1]}");

            candyQuantityText.text = $"Candy Req: {quantity}";
            cookieQuantityText.text = $"Candy Req: {quantity}";
        }
    }

    public void DecreaseItemRequest(int roll, int quantityReq)
    {
        if (roll == 0)
        { //"Piece of Candy";
            if (quantityReq >= 0)
            {
                quantity--;
                quantityReq--;
                candyQuantityText.text = $"Candy Req: {quantity}";
                Debug.Log("[ORDER] Decreased Candy Req!");

                if (quantity == 0)
                {
                    customer.SetActive(false);
                    Debug.Log("[ORDER] Cat is full!");
                }
            }

            
        }
        else if (roll == 1)
        { //"Cookie";
            if (quantityReq >= 0)
            {
                quantity--;
                quantityReq--;
                cookieQuantityText.text = $"Cookie Req: {quantity}";
                Debug.Log("[ORDER] Decreased Cookie Req!");

                if (quantity == 0)
                {
                    customer.SetActive(false);
                    Debug.Log("[ORDER] Cat is full!");
                }
            }
        }
        else
        { //"Candy + Cookie";
        
        }
    }

    public string getItemRequest(int roll) 
    { 
        if (roll == 0)
        { return "Piece of Candy"; }
        else if (roll == 1)
        { return "Cookie"; }
        else
        { return "Candy + Cookie"; }
    }

    public int getQuantityItemRequest(int roll)
    {
        if (roll == 0 || roll == 1)
        { return quantity; }
        else
        { return quantities[0] + quantities[1]; }
    }

    public int getRoll()
    { return roll; }
}
