using UnityEngine;
using UnityEngine.UI;

public class CalculatorScript : MonoBehaviour
{
    public Text textCalcu;

    public Button cent5;


    private float currentValue = 0f;

    private void Start()
    {
        textCalcu.text = currentValue.ToString("F2");
    }
    public void Press1PesoCalcu()
    {
        currentValue += 1f;

        textCalcu.text = currentValue.ToString();
        Debug.Log("[CALCULATOR] 1 Peso button pressed.");
    }

    public void Press5PesoCalcu()
    {
        currentValue += 5f;

        textCalcu.text = currentValue.ToString();
        Debug.Log("[CALCULATOR] 5 Peso button pressed.");
    }

    public void Press10PesoCalcu()
    {
        currentValue += 10f;
       
        textCalcu.text = currentValue.ToString();
        Debug.Log("[CALCULATOR] 10 Peso button pressed.");
    }

    public void Press20PesoCalcu()
    {
        currentValue += 20f;
        
        textCalcu.text = currentValue.ToString();
        Debug.Log("[CALCULATOR] 20 Peso button pressed.");
    }

    public void Press50PesoCalcu()
    {
        currentValue += 50f;
        
        textCalcu.text = currentValue.ToString();
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
        currentValue = 0f;
            
        textCalcu.text = currentValue.ToString("F2");
        Debug.Log("[CALCULATOR] Clear button pressed. Current value reset to 0.");
    }
}
