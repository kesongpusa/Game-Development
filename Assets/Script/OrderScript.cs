using UnityEngine;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour
{
    private int orderQuantity;
    public Text quantityText;

    public void addScoreToOrder()
    {
        orderQuantity = orderQuantity + 1;
        quantityText.text = $"Cat Ate: {orderQuantity.ToString()}";

        Debug.Log($"Order quantity updated: {orderQuantity}");
    }
}
