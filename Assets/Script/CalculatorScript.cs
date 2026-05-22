using System;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorScript : MonoBehaviour
{
    public ChangeScript changeScript;
    public PlayerCurrency playerCurrency;
    public PlayerIncome playerIncome;
    public SuccessfulTransaction successfulTransaction;

    public GameObject calculator;

    public Text textCalcu;

    private float currentValue = 0.00f;

    private void Start()
    {
        textCalcu.text = currentValue.ToString("F2");
    }
    public void Press1PesoCalcu()
    {
        currentValue += 1f;

        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 1 Peso button pressed.");
    }
    public void Press5PesoCalcu()
    {
        currentValue += 5f;

        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 5 Peso button pressed.");
    }
    public void Press10PesoCalcu()
    {
        currentValue += 10f;

        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 10 Peso button pressed.");
    }
    public void Press20PesoCalcu()
    {
        currentValue += 20f;

        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 20 Peso button pressed.");
    }
    public void Press50PesoCalcu()
    {
        currentValue += 50f;

        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 50 Peso button pressed.");
    }
    public void Press5CentCalcu()
    {
        currentValue += 0.05f;
        
        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 5 Cent button pressed.");
    }
    public void Press10CentCalcu()
    {
        currentValue += 0.10f;
        
        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 10 Cent button pressed.");
    }
    public void Press25CentCalcu()
    {
        currentValue += 0.25f;
        
        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] 25 Cent button pressed.");
    }
    public void PressClearCalcu()
    {
        currentValue = 0.00f;
            
        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] Clear button pressed. Current value reset to 0.");
    }
    public void PressSumbit()
    {
        if (CheckIfChangeAmountIsExact())
        {
            Debug.Log("[CALCULATOR] Change amount is exact. Proceeding with transaction.");
            playerIncome.AddIncome();

            PressClearCalcu();
            calculator.SetActive(false);
            
            successfulTransaction.Success();
        }
        else
        {
            Debug.Log("[CALCULATOR] Change amount is not exact. Please adjust the amount.");
        }
    }

    public bool CheckIfChangeAmountIsExact()
    {
        float change = changeScript.GetChange();
        float roundedCurrentValue = (float)Math.Round(currentValue, 2);

        if (change == roundedCurrentValue)
        { return true; }
        else
        { return false; }
    }
}
