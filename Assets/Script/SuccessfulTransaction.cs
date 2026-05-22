using UnityEngine;
using UnityEngine.UI;

public class SuccessfulTransaction : MonoBehaviour
{
    public GameObject customer;
    public RestartGameScript restartGameScript;
    public ChangeCustomers changeCustomers;

    public Text textCustomerPay;
    public void Success()
    {
        //restartGameScript.ShowRestartButton();

        textCustomerPay.text = $"Customer is Paid";
        Debug.Log("[TRANSACTION] Transaction successful! Playing success sound.");
        Debug.Log("[TRANSACTION] Order complete! Customer is happy!");

        changeCustomers.RandomCustomerPicker();
    }
}
