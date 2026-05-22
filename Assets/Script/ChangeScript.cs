using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScript : MonoBehaviour
{
    public CalculatorScript calculatorScript;
    public PayingCustomer payingCustomer;

    private float change;

    public Text textChange;

    public GameObject calculator;

    public void CalculateChange()
    {
        float totalprice = payingCustomer.GetTotalPrice();
        float customerGiveMoney = payingCustomer.GetFinalCustomerGiveMoney();

        change = customerGiveMoney - totalprice;

        change = (float)Math.Round(change, 2);

        Debug.Log($"[CHANGE] Change to give: ₱{change}");
        SetTextChange();

        calculator.SetActive(true);
    }

    private void SetTextChange()
    {
        textChange.enabled = true;
        textChange.text = $"Change: ₱{change.ToString("F2")}";
    }

    public float GetChange()
    { return change; }
}
