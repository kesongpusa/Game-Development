using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayingCustomer : MonoBehaviour
{
    public ItemPrice itemPrice;
    public OrderScript orderScript;
    public PlayerCurrency playerCurrency;
    public CalculatorScript calculatorScript;
    public ChangeScript changeScript;

    public Text textPayingCustomer;

    private float customerGiveMoney = 0f;
    private float paymentAmount = 0f;
    private float totalPrice = 0f;

    private List<string> itemName;
    private List<int> itemQuantities;

    void Start()
    {
        StartCounting();
    }

    public void StartCounting()
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

        totalPrice = (float)Math.Round(itemPrice.GetTotalPrice(), 2);
        Debug.Log("[PAYINGCUSTOMER] Total price: ₱" + itemPrice.GetTotalPrice());
    }

    public void PayForTotalAmount()
    {
        float minGiveMoney = itemPrice.GetTotalPrice() + 2f;
        float maxGiveMoney = itemPrice.GetTotalPrice() + 5f;

        customerGiveMoney = UnityEngine.Random.Range(minGiveMoney, maxGiveMoney);
        customerGiveMoney = RoundToNearestFive(customerGiveMoney);

        Debug.Log("[PAYINGCUSTOMER] Customer gives: ₱" + customerGiveMoney);

        textPayingCustomer.enabled = true;
        textPayingCustomer.text = $"Customer pays: ₱{customerGiveMoney.ToString("F2")}";

        changeScript.CalculateChange();
    }
    private float RoundToNearestFive(float value)
    { return Mathf.Round(value / 5f) * 5f; }
    public float GetTotalPrice()
    { return totalPrice; }

    public float GetCustomerGiveMoney()
    { return customerGiveMoney; }
}
