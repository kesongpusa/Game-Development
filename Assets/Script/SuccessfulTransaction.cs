using UnityEngine;
using UnityEngine.UI;

public class SuccessfulTransaction : MonoBehaviour
{
    public GameObject customer;
    public RestartGameScript restartGameScript;

    public Text textCustomerPay;
    public void Success()
    {
        customer.SetActive(false);

        restartGameScript.ShowRestartButton();

        textCustomerPay.text = $"Customer is Paid";
        Debug.Log("[TRANSACTION] Transaction successful! Playing success sound.");
        Debug.Log("[TRANSACTION] Order complete! Customer is happy!");
        // You can add code here to play a sound effect or show a visual effect for a successful transaction.
    }
}
