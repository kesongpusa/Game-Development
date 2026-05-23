using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OrderScript : MonoBehaviour
{
    private int orderQuantity;

    public GameObject getGoyaCandy; 
    public GameObject getMentos;
    public GameObject getWhiteRabbit;

    public GameObject requestItem;
    public GameObject item1;
    public GameObject item2;

    public Sprite[] items;

    public Text oneItemRequest;

    public Text goyaCandyQuantityText;
    public Text mentosQuantityText;
    public Text whiteRabbitQuantityText;

    private int manyItems, whatItemRoll;
    private List<string> itemName;
    private List<int> itemQuantities;

    public DragDropClick dragDropClick;
    public PayingCustomer payingCustomer;

    private void Start()
    {
        GetOrderRandomizer();
    }

    public void GetOrderRandomizer()
    {
        requestItem.SetActive(true);
        //manyItems = Random.Range(1, 3);

        manyItems = 1;

        itemName = new List<string>(); 
        itemQuantities = new List<int>();

        /*
        1 = 1 item
        2 = 2 items
        */

        if (manyItems == 1)
        {
            item1.SetActive(true);
            Debug.Log("[ORDER] Items: 1");

            //whatItemRoll = Random.Range(0, 6);
            whatItemRoll = 5;

            /*
            1 = Goya Candy
            2 = Mentos
            3 = Rice
            4 = Soy Sauce
            5 = Vinegar
            6 = White Rabbit
            */

            if (whatItemRoll == 0)
            {
                Debug.Log("[ORDER] Item: Goya Candy");
                itemName.Add("Goya Candy");

                item1.GetComponent<SpriteRenderer>().sprite = items[0];
            }
            else if (whatItemRoll == 1)
            {
                Debug.Log("[ORDER] Item: Mentos");
                itemName.Add("Mentos");

                item1.GetComponent<SpriteRenderer>().sprite = items[1];
            }
            else if (whatItemRoll == 2)
            {
                Debug.Log("[ORDER] Item: Rice");
                itemName.Add("Rice");

                item1.GetComponent<SpriteRenderer>().sprite = items[2];
            }
            else if (whatItemRoll == 3)
            {
                Debug.Log("[ORDER] Item: Soy Sauce");
                itemName.Add("Soy Sauce");

                item1.GetComponent<SpriteRenderer>().sprite = items[3];
            }
            else if (whatItemRoll == 4)
            {
                Debug.Log("[ORDER] Item: Vinegar");
                itemName.Add("Vinegar");

                item1.GetComponent<SpriteRenderer>().sprite = items[4];
            }
            else if (whatItemRoll == 5)
            {
                Debug.Log("[ORDER] Item: White Rabbit");
                itemName.Add("White Rabbit");

                item1.GetComponent<SpriteRenderer>().sprite = items[5];
            }
            GetQuantityOrderRandomizer(manyItems, whatItemRoll);
        }
        else if (manyItems == 2)
        { Debug.Log("[ORDER] Items: 2");

            int whatItemRoll1 = Random.Range(0, 5);
            int whatItemRoll2 = Random.Range(0, 5);

            while (whatItemRoll1 == whatItemRoll2)
            {
                whatItemRoll2 = Random.Range(0, 5);
            }

            item1.SetActive(true);
            item2.SetActive(true);

            itemName.Add(items[whatItemRoll1].name);
            itemName.Add(items[whatItemRoll2].name);

            item1.GetComponent<SpriteRenderer>().sprite = items[whatItemRoll1];
            item2.GetComponent<SpriteRenderer>().sprite = items[whatItemRoll2];

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
            if (whatItem >= 0)
            {
                oneItemRequest.enabled = true;

                Debug.Log($"[ORDER] One Item Req: {quantity}");
                oneItemRequest.text = $"{quantity}";
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

            goyaCandyQuantityText.enabled = true;
            mentosQuantityText.enabled = true;

            goyaCandyQuantityText.text = $"{itemQuantities[0]}";
            mentosQuantityText.text = $"{itemQuantities[1]}";
        }
    }

    public void DecreaseItemRequest(string itemName, int itemToGive)
    {
        if (itemName == "Goya Candy")
        {
            //get current position of Goya Candy in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                goyaCandyQuantityText.text = $"{quantity}";
                Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
            }

            if (manyItems == 1)
            {
                Debug.Log("[ORDER] White Rabbit order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                Debug.Log("[ORDER] Goya Candy order complete!");
                goyaCandyQuantityText.enabled = false;
            }
        }
        else if (itemName == "Mentos")
        {
            //get current position of Mentos in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                mentosQuantityText.text = $"{quantity}";
                Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
            }

            if (manyItems == 1)
            {
                Debug.Log("[ORDER] Mentos order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                Debug.Log("[ORDER] Mentos order complete!");
                mentosQuantityText.enabled = false;
            }
        }
        else if (itemName == "White Rabbit")
        {
            //get current position of White Rabbit in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                mentosQuantityText.text = $"{quantity}";
                Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
            }

            if (manyItems == 1)
            {
                Debug.Log("[ORDER] White Rabbit order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                Debug.Log("[ORDER] White Rabbit order complete!");
                whiteRabbitQuantityText.enabled = false;
            }
        }

        if (itemQuantities.TrueForAll(q => q == 0))
        {
            payingCustomer.PayForTotalAmount();
            requestItem.SetActive(false);

            item1.SetActive(false);
            item2.SetActive(false);
        }

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
