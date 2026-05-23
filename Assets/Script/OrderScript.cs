using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OrderScript : MonoBehaviour
{
    public GameObject requestItem;
    public GameObject item1;
    public GameObject item2;

    private Vector3 item1OriginalScale;
    private Vector3 item2OriginalScale;

    public Sprite[] items;

    public Text oneItemRequest;

    public Text item1QuantityText;
    public Text item2QuantityText;

    private int manyItems, whatItemRoll;
    private List<string> itemName;
    private List<int> itemQuantities;

    public DragDropClick dragDropClick;
    public PayingCustomer payingCustomer;
    public DisablingUI disableUI;

    private void Start()
    {
        item1OriginalScale = item1.transform.localScale;
        item2OriginalScale = item2.transform.localScale;

        GetOrderRandomizer();

    }

    public void GetOrderRandomizer()
    {
        int countItems = items.Length;

        requestItem.SetActive(true);
        manyItems = Random.Range(1, 3);

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

            whatItemRoll = Random.Range(0, countItems);

            /*
            1 = Goya Candy
            2 = Mentos
            3 = Rice
            4 = Soy Sauce
            5 = Vinegar
            6 = White Rabbit
            7 = Joy
            8 = Surf
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
            else if (whatItemRoll == 6) 
            {                 
                Debug.Log("[ORDER] Item: Joy");
                itemName.Add("Joy");

                item1.GetComponent<SpriteRenderer>().sprite = items[6];
            }
            else if (whatItemRoll == 7)
            {
                Debug.Log("[ORDER] Item: Surf");
                itemName.Add("Surf");
                item1.GetComponent<SpriteRenderer>().sprite = items[7];
            }
             NormalizeSpriteScale(item1, items[whatItemRoll], item1OriginalScale);
            GetQuantityOrderRandomizer(manyItems, whatItemRoll);
        }
        else if (manyItems == 2)
        { Debug.Log("[ORDER] Items: 2");

            int whatItemRoll1 = Random.Range(0, countItems);
            int whatItemRoll2 = Random.Range(0, countItems);

            while (whatItemRoll1 == whatItemRoll2)
            {
                whatItemRoll2 = Random.Range(0, countItems);
            }

            item1.SetActive(true);
            item2.SetActive(true);

            itemName.Add(items[whatItemRoll1].name);
            itemName.Add(items[whatItemRoll2].name);

            item1.GetComponent<SpriteRenderer>().sprite = items[whatItemRoll1];
            item2.GetComponent<SpriteRenderer>().sprite = items[whatItemRoll2];

            NormalizeSpriteScale(item1, items[whatItemRoll1], item1OriginalScale);
            NormalizeSpriteScale(item2, items[whatItemRoll2], item2OriginalScale);

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
            Sprite sprite;
            string spriteName;

            for (int i = 0; i < randItems; i++)
            {
                sprite = items[i];
                spriteName = sprite.name;

                int quantityItems = Random.Range(1, 10);
                Debug.Log($"[ORDER] Quantity for Item {i + 1} ({spriteName}): {quantityItems}");

                itemQuantities.Add(quantityItems);
            }

            item1QuantityText.enabled = true;
            item2QuantityText.enabled = true;

            item1QuantityText.text = $"{itemQuantities[0]}";
            item2QuantityText.text = $"{itemQuantities[1]}";
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

                Debug.Log($"[ORDER] Value of manyItems: {manyItems}");

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                    }
                }
            }

            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Goya Candy order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                }
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

                Debug.Log($"[ORDER] Value of manyItems: {manyItems}");

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                    }
                }
            }

            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Mentos order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                }
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

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                    }
                }
            }

            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] White Rabbit order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                }
            }
        }
        else if (itemName == "Rice")
        {
            //get current position of Rice in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                    }
                }
            }

            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Rice order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                }
            }
        }
        else if (itemName == "Soy Sauce")
        {
            //get current position of Soy Sauce in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                    }
                }
            }

            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Soy Sauce order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                }
            }
        }
        else if (itemName == "Vinegar")
        {
            //get current position of Vinegar in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                    }
                }
            }

            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Vinegar order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                }
            }
        }
        else if (itemName == "Joy")
        {
            //get current position of Joy in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                    }
                }
            }
            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Joy order complete!");
                oneItemRequest.enabled = false;
            }
            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                }
            }
        }
        else if (itemName == "Surf")
        {
            //get current position of Surf in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Surf quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Surf quantity. New quantity: {quantity}");
                    }
                }
            }
        }

        if (itemQuantities.TrueForAll(q => q == 0))
        {
            payingCustomer.PayForTotalAmount();
            requestItem.SetActive(false);

            item1.SetActive(false);
            item2.SetActive(false);

            disableUI.DisableWhileCalcu();
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

    private void NormalizeSpriteScale(GameObject itemGameObject, Sprite sprite, Vector3 originalScale)
    {
        if (sprite != null)
        { itemGameObject.transform.localScale = originalScale; }
    }
    public void ClearItemsList()
    {
        itemName.Clear();
        itemQuantities.Clear();
    }
    public List<string> getItemsRequest() { return itemName; }
    public List<int> getQuantitiesRequest() { return itemQuantities; }
}
