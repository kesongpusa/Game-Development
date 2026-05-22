using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OrderScript : MonoBehaviour
{
    private int orderQuantity;
    public Text quantityText;

    public GameObject getCandy; 
    public GameObject getCookie;

    public Text candyQuantityText;
    public Text cookieQuantityText;

    private int manyItems, whatItemRoll;
    private List<string> itemName;
    private List<int> itemQuantities;

    public DragDropClick dragDropClick;
    public PayingCustomer payingCustomer;

    private void Start()
    {
        GetOrderRandomizer();
    }
    public void addScoreToOrder(int addItemsOrder)
    {
        orderQuantity = orderQuantity + addItemsOrder;
        quantityText.text = $"Cat Ate: {orderQuantity.ToString()}";

        Debug.Log($"[ORDER] Order quantity updated: {orderQuantity}");
    }

    public void GetOrderRandomizer()
    {
        manyItems = Random.Range(1, 3);

        itemName = new List<string>(); 
        itemQuantities = new List<int>();

        /*
        1 = 1 item
        2 = 2 items
        */

        if (manyItems == 1)
        {
            Debug.Log("[ORDER] Items: 1");

            whatItemRoll = Random.Range(0, 2);

            /*
            1 = Candy
            2 = Cookie
            */

            if (whatItemRoll == 0)
            { Debug.Log("[ORDER] Item: Piece of Candy");
                itemName.Add("Piece of Candy");
            }
            else if (whatItemRoll == 1)
            { Debug.Log("[ORDER] Item: Cookie");
                itemName.Add("Cookie");
            }

            GetQuantityOrderRandomizer(manyItems, whatItemRoll);
        }
        else if (manyItems == 2)
        { Debug.Log("[ORDER] Items: 2");
            itemName.Add("Piece of Candy");
            itemName.Add("Cookie");

            GetQuantityOrderRandomizer(manyItems, itemName.Count);
        }

        for (int i = 0; i < itemName.Count; i++)
        {
            Debug.Log($"[ORDER] Item {i + 1}: {itemName[i]}");
        }

        
    }

    private void GetQuantityOrderRandomizer(int randItems, int whatItem)
    {
        int quantity = Random.Range(1, 11);

        if (randItems == 1)
        {
            if (whatItem == 0)
            {
                candyQuantityText.enabled = true;

                Debug.Log($"[ORDER] Quantity (Piece of Candy): {quantity}");
                candyQuantityText.text = $"Candy Req: {quantity}";
            }
            else if (whatItem == 1)
            {
                cookieQuantityText.enabled = true;

                Debug.Log($"[ORDER] Quantity (Cookie): {quantity}");
                cookieQuantityText.text = $"Cookie Req: {quantity}";
            }

            itemQuantities.Add(quantity);
        }
        else if (randItems == itemName.Count)
        {
            for (int i = 0; i < randItems; i++)
            {
                int quantityItems = Random.Range(1, 10);
                Debug.Log($"[ORDER] Quantity for Item {i + 1}: {quantityItems}");

                itemQuantities.Add(quantityItems);
            }

            candyQuantityText.enabled = true;
            cookieQuantityText.enabled = true;

            candyQuantityText.text = $"Candy Req: {itemQuantities[0]}";
            cookieQuantityText.text = $"Cookie Req: {itemQuantities[1]}";
        }
    }

    public void DecreaseItemRequest(string itemName, int itemToGive)
    {
        if (itemName == "Piece of Candy")
        {
            //get current position of Piece of Candy in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                candyQuantityText.text = $"Candy Req: {quantity}";
                Debug.Log($"[ORDER] Decreased Piece of Candy quantity. New quantity: {quantity}");
            }

            if (quantity == 0)
            {
                Debug.Log("[ORDER] Piece of Candy order complete!");
                candyQuantityText.enabled = false;
            }
        }
        else if (itemName == "Cookie")
        {
            //get current position of Cookie in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                cookieQuantityText.text = $"Cookie Req: {quantity}";
                Debug.Log($"[ORDER] Decreased Cookie quantity. New quantity: {quantity}");
            }

            if (quantity == 0)
            {
                Debug.Log("[ORDER] Cookie order complete!");
                cookieQuantityText.enabled = false;
            }
        }

        if (itemQuantities.TrueForAll(q => q == 0))
        { payingCustomer.PayForTotalAmount(); }

        UpdateListFromDragDropClick();

    }

    private void UpdateListFromDragDropClick()
    {
        dragDropClick.setItemsRequest(itemName);
        dragDropClick.setQuantitiesRequest(itemQuantities);

        List<string> items = dragDropClick.getItemsRequest();
        List<int> quantities = dragDropClick.getQuantitiesRequest();

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log($"[ORDER] Updated List from DragDropClick - Item {i + 1}: {items[i]}, Quantity: {quantities[i]}");
        }
    }

    public void ClearItemsList()
    {
        itemName.Clear();
        itemQuantities.Clear();
    }
    public List<string> getItemsRequest() { return itemName; }
    public List<int> getQuantitiesRequest() { return itemQuantities; }
}
