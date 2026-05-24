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

    private int[] choiceCustomerGiveMoney = new int[8] { 5, 10, 20, 50, 70, 100, 150, 200 };

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
    private float CustomerGenerateMoney(float minRequiredAmount)
    {
        float minRequiredAmountRounded = (float)Math.Round(minRequiredAmount, 2);
        Debug.Log($"[PAYINGCUSTOMER] Minimum required amount: ₱{minRequiredAmountRounded}");

        // Find all bills that are greater than the minimum required amount
        List<int> validBills = new List<int>();
        foreach (int bill in choiceCustomerGiveMoney)
        {
            if (bill > totalPrice)
            {
                validBills.Add(bill);
            }
        }

        // If no single bill is enough, pick the largest bill and add random extra bills
        if (validBills.Count == 0)
        {
            float randomMoney = choiceCustomerGiveMoney[choiceCustomerGiveMoney.Length - 1];

            while (randomMoney <= minRequiredAmountRounded)
            {
                int randomBillIndex = UnityEngine.Random.Range(0, choiceCustomerGiveMoney.Length);
                randomMoney += choiceCustomerGiveMoney[randomBillIndex];
            }

            Debug.Log($"[PAYINGCUSTOMER] Customer generates multiple bills: ₱{randomMoney}");
            return randomMoney;
        }

        // Pick a random valid bill from the list
        int selectedIndex = UnityEngine.Random.Range(0, validBills.Count);
        float selectedBill = validBills[selectedIndex];

        Debug.Log($"[PAYINGCUSTOMER] Customer generates: ₱{selectedBill}");
        return selectedBill;
    }
    private void PayForItem(string itemName)
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
        
        int generateMoreMoneyChance = UnityEngine.Random.Range(1, 101);

        if (generateMoreMoneyChance <= 100 && generateMoreMoneyChance >= 30)
        { customerGiveMoney = CustomerGenerateMoney((float)UnityEngine.Random.Range(customerGiveMoney, 2)); }
        else if (generateMoreMoneyChance <= 30 && generateMoreMoneyChance >= 1)
        { customerGiveMoney = totalPrice; }

        Debug.Log("[PAYINGCUSTOMER] Customer gives: ₱" + customerGiveMoney);

        textPayingCustomer.enabled = true;
        textPayingCustomer.text = $"Customer pays: ₱{customerGiveMoney.ToString("F2")}";

        changeScript.CalculateChange();
    }
    public float GetTotalPrice()
    { return totalPrice; }

    public float GetCustomerGiveMoney()
    { return customerGiveMoney; }
}
