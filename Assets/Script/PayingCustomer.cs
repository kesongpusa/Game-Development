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

    private float finalCustomerGiveMoney = 0f;
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
        float minGiveMoney = itemPrice.GetTotalPrice() + 2f;
        float maxGiveMoney = itemPrice.GetTotalPrice() + 10f;
        float step = 0.05f;

        int minSteps = Mathf.RoundToInt(minGiveMoney / step);
        int maxSteps = Mathf.RoundToInt(maxGiveMoney / step);

        int customerGiveMoney = UnityEngine.Random.Range(minSteps, maxSteps);

        finalCustomerGiveMoney = customerGiveMoney * step;

        Debug.Log("[PAYINGCUSTOMER] Customer gives: ₱" + finalCustomerGiveMoney);

        totalPrice = (float)Math.Round(totalPrice, 2);

        /*float currentCurrency = playerCurrency.GetCurrentCurrency();
        playerCurrency.SetCurrentCurrency(currentCurrency + finalCustomerGiveMoney);*/

        textPayingCustomer.enabled = true;
        textPayingCustomer.text = $"Customer pays: ₱{finalCustomerGiveMoney}";

        changeScript.CalculateChange();
    }

    public float GetTotalPrice()
    { return totalPrice; }

    public float GetFinalCustomerGiveMoney()
    { return finalCustomerGiveMoney; }
}
