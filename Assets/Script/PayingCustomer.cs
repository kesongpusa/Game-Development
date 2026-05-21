using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayingCustomer : MonoBehaviour
{
    public ItemPrice itemPrice;
    public OrderScript orderScript;
    public PlayerCurrency playerCurrency;

    public Text textPayingCustomer;

    private float paymentAmount = 0f;
    private float totalPrice = 0f;

    private List<string> itemName;
    private List<int> itemQuantities;

    void Start()
    {
        itemName = orderScript.getItemsRequest();
        itemQuantities = orderScript.getQuantitiesRequest();

        for (int i = 0; i < itemName.Count; i++)
        {
            Debug.Log("[PAYINGCUSTOMER] Customer wants to buy: " + itemName[i] + " x" + itemQuantities[i]);

            for (int j = 0; j < itemQuantities[i]; j++)
            {
                PayForItem(itemName[i]);
            }
        }
    }

    public void PayForItem(string itemName)
    {
        paymentAmount = itemPrice.GetPrice(itemName);
        Debug.Log("[PAYINGCUSTOMER] Customer pays: ₱" + paymentAmount);

        itemPrice.SetTotalPrice(paymentAmount);
        Debug.Log("[PAYINGCUSTOMER] Total price updated: ₱" + itemPrice.GetTotalPrice());

        totalPrice = itemPrice.GetTotalPrice();
        Debug.Log("[PAYINGCUSTOMER] Total price: ₱" + itemPrice.GetTotalPrice());
    }

    public void PayForTotalAmount()
    {
        float customerGiveMoney = UnityEngine.Random.Range(itemPrice.GetTotalPrice() + 2f, itemPrice.GetTotalPrice() + 10f);

        customerGiveMoney = (float)Math.Round(customerGiveMoney, 2);
        Debug.Log("[PAYINGCUSTOMER] Customer gives: ₱" + customerGiveMoney);

        float currentCurrency = playerCurrency.GetCurrentCurrency();
        playerCurrency.SetCurrentCurrency(currentCurrency + customerGiveMoney);

        textPayingCustomer.enabled = true;
        textPayingCustomer.text = $"Customer pays: ₱{customerGiveMoney}";
    }
}
