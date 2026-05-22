using UnityEngine;

public class RotatingOrder : MonoBehaviour
{
    public OrderScript orderScript;
    public DragDropClick dragDropClick;

    public void StartOrder()
    {
        orderScript.ClearItemsList();
        Debug.Log("[ROTATINGORDER] Starting new order. Cleared items list.");

        orderScript.GetOrderRandomizer();
        Debug.Log("[ROTATINGORDER] Generated new order with random items and quantities.");

        dragDropClick.GetItemListRequestAndQuantity();
        Debug.Log("[ROTATINGORDER] Updated DragDropClick with new order items and quantities.");
    }
}
