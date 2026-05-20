using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public float currentCurrency = 1000f;
    public Text textCurrency;

    void Start()
    {
        UpdateCurrencyText();
    }

    public void UpdateCurrencyText()
    {
        textCurrency.text = $"Currency: ₱{currentCurrency}";
    }

    public void SetCurrentCurrency(float updatedCurrency)
    {
        this.currentCurrency = updatedCurrency;
        UpdateCurrencyText();
    }

    public float GetCurrentCurrency()
    {
        Debug.Log($"[CURRENCY] Current currency: {currentCurrency}");
        return currentCurrency;
    }
}
