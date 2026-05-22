using UnityEngine;

public class PlayerIncome : MonoBehaviour
{
    public ChangeScript changeScript;
    public PayingCustomer payingCustomer;
    public PlayerCurrency playerCurrency;

    public void AddIncome()
    {
        float change = changeScript.GetChange();
        float customerMoney = payingCustomer.GetCustomerGiveMoney();

        float income = customerMoney - change;

        Debug.Log($"[INCOME] Customer Money: {customerMoney} - Change: {change}");
        Debug.Log($"[INCOME] Adding income: ₱{income}");

        playerCurrency.SetCurrentCurrency(playerCurrency.GetCurrentCurrency() + income);
    }
}
