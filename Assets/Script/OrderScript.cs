using UnityEngine;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour
{
    private int orderQuantity;
    public Text quantityText;

    public GameObject getCandy; 
    public GameObject getCookie;

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
        int roll = Random.Range(0, 2);

        /*
        0 = Candy
        1 = Cookie
        2 = Candy + Cookie
        */

        if (roll == 0)
        { Debug.Log("Random: Candy"); }
        else if (roll == 1)
        { Debug.Log("Random: Cookie"); }
        else
        { Debug.Log("Random: Candy + Cookie"); }

        GetQuantityOrderRandomizer(roll);
    }

    void GetQuantityOrderRandomizer(int roll)
    {
        int quantity = Random.Range(1, 10);

        if (roll == 0)
        {
            Debug.Log($"Quantity (Candy): {quantity}");
        }
        else if (roll == 1)
        {
            Debug.Log($"Quantity (Cookie): {quantity}");
        }
        else
        {
            int[] quantities = new int[2];

            for (int i = 0; i < 2; i++)
            {
                quantities[i] = Random.Range(1, 10);
            }

            Debug.Log($"Quantity (Candy): {quantities[0]}");
            Debug.Log($"Quantity (Cookie): {quantities[1]}");
        }
    }
}
