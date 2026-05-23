using UnityEngine;
using UnityEngine.UI;

public class ItemsLeft : MonoBehaviour
{
    private int goyaCandyLeft;
    private int mentosLeft;
    private int whiteRabbitLeft;
    private int riceLeft;
    private int soySauceLeft;
    private int vinegarLeft;
    private int joyLeft;
    private int surfLeft;

    public GameObject joyItem;
    public GameObject surfItem;

    public Text goyaCandyLeftText;
    public Text mentosLeftText;
    public Text whiteRabbitLeftText;
    public Text riceLeftText;
    public Text soySauceLeftText;
    public Text vinegarLeftText;
    public Text joyLeftText;
    public Text surfLeftText;

    void Start()
    {
        goyaCandyLeft = 10;
        mentosLeft = 10;
        whiteRabbitLeft = 10;
        riceLeft = 10;
        soySauceLeft = 10;
        vinegarLeft = 10;
        joyLeft = 10;
        surfLeft = 10;

        UpdateGoyaCandyLeftText();
        UpdateMentosLeftText();
        UpdateWhiteRabbitLeftText();
        UpdateRiceLeftText();
        UpdateSoySauceLeftText();
        UpdateVinegarLeftText();
        UpdateSurfLeftText();
        UpdateJoyLeftText();
    }
    public void DecreaseGoyaCandy()
    {
        if (goyaCandyLeft > 0)
        {
            goyaCandyLeft--;
        }
        UpdateGoyaCandyLeftText();
    }
    public void DecreaseMentos()
    {
        if (mentosLeft > 0)
        {
            mentosLeft--;
        }

        UpdateMentosLeftText();
    }
    public void DecreaseWhiteRabbit()
    {
        if (whiteRabbitLeft > 0)
        {
            whiteRabbitLeft--;
        }
        UpdateWhiteRabbitLeftText();
    }
    public void DecreaseRice()
    {
        if (riceLeft > 0)
        {
            riceLeft--;
        }
        UpdateRiceLeftText();
    }
    public void DecreaseSoySauce()
    {
        if (soySauceLeft > 0)
        {
            soySauceLeft--;
        }
        UpdateSoySauceLeftText();
    }
    public void DecreaseVinegar()
    {
        if (vinegarLeft > 0)
        {
            vinegarLeft--;
        }
        UpdateVinegarLeftText();
    }
    public void DecreaseJoy()
    {
        if (joyLeft > 0)
        {
            joyLeft--;
        }

        int joyChildCount = joyItem.transform.childCount;
        //Debug.Log($"[ITEMSLEFT] Joy item child count: {joyChildCount}");

        if (joyLeft <= joyChildCount)
        {
            if (joyLeft == 2)
            {
                joyItem.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (joyLeft == 1)
            {
                joyItem.transform.GetChild(0).gameObject.SetActive(false);
            }
            Debug.Log($"[ITEMSLEFT] Deactivating Joy item. Remaining: {joyLeft}");
        }

        UpdateJoyLeftText();
    }
    public void DecreaseSurf()
    {
        if (surfLeft > 0)
        {
            surfLeft--;
        }

        int surfChildCount = surfItem.transform.childCount;

        if (surfLeft <= surfChildCount)
        {
            if (surfLeft == 2)
            {
                surfItem.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (surfLeft == 1)
            {
                surfItem.transform.GetChild(0).gameObject.SetActive(false);
            }
            Debug.Log($"[ITEMSLEFT] Deactivating Surf item. Remaining: {surfLeft}");
        }
        UpdateSurfLeftText();
    }
    public void DecreaseItem(string item)
    {
        if (item.Equals("Goya Candy"))
        {
            DecreaseGoyaCandy();
        }
        else if (item.Equals("Mentos"))
        {
            DecreaseMentos();
        }
        else if (item.Equals("White Rabbit"))
        {
            DecreaseWhiteRabbit();
        }
        else if (item.Equals("Rice"))
        {
            DecreaseRice();
        }
        else if (item.Equals("Soy Sauce"))
        {
            DecreaseSoySauce();
        }
        else if (item.Equals("Vinegar"))
        {
            DecreaseVinegar();
        }
        else if (item.Equals("Joy"))
        {
            DecreaseJoy();
        }
        else if (item.Equals("Surf"))
        {
            DecreaseSurf();
        }
    }

    void UpdateGoyaCandyLeftText()
    {
        goyaCandyLeftText.text = $"{goyaCandyLeft}";
        Debug.Log($"[ITEMSLEFT] Goya Candy left: {goyaCandyLeft}");
    }
    void UpdateMentosLeftText()
    {
        mentosLeftText.text = $"{mentosLeft}";
        Debug.Log($"[ITEMSLEFT] Mentos left: {mentosLeft}");
    }
    void UpdateWhiteRabbitLeftText()
    {
        whiteRabbitLeftText.text = $"{whiteRabbitLeft}";
        Debug.Log($"[ITEMSLEFT] White Rabbit left: {whiteRabbitLeft}");
    }
    void UpdateRiceLeftText()
    {
        riceLeftText.text = $"{riceLeft}";
        Debug.Log($"[ITEMSLEFT] Rice left: {riceLeft}");
    }
    void UpdateSoySauceLeftText()
    {
        soySauceLeftText.text = $"{soySauceLeft}";
        Debug.Log($"[ITEMSLEFT] Soy Sauce left: {soySauceLeft}");
    }
    void UpdateVinegarLeftText()
    {
        vinegarLeftText.text = $"{vinegarLeft}";
        Debug.Log($"[ITEMSLEFT] Vinegar left: {vinegarLeft}");
    }
    void UpdateJoyLeftText()
    {
        joyLeftText.text = $"{joyLeft}";
        Debug.Log($"[ITEMSLEFT] Joy left: {joyLeft}");
    }
    void UpdateSurfLeftText()
    {
        surfLeftText.text = $"{surfLeft}";
        Debug.Log($"[ITEMSLEFT] Surf left: {surfLeft}");
    }

    public void SetGoyaCandyLeft(int goyaCandyLeft)
    {
        this.goyaCandyLeft = goyaCandyLeft;
        UpdateGoyaCandyLeftText();
    }
    public void SetMentosLeft(int mentosLeft)
    {
        this.mentosLeft = mentosLeft;
        UpdateMentosLeftText();
    }
    public void SetWhiteRabbitLeft(int whiteRabbitLeft)
    {
        this.whiteRabbitLeft = whiteRabbitLeft;
        UpdateWhiteRabbitLeftText();
    }
    public void SetRiceLeft(int riceLeft)
    {
        this.riceLeft = riceLeft;
        UpdateRiceLeftText();
    }
    public void SetSoySauceLeft(int soySauceLeft)
    {
        this.soySauceLeft = soySauceLeft;
        UpdateSoySauceLeftText();
    }
    public void SetVinegarLeft(int vinegarLeft)
    {
        this.vinegarLeft = vinegarLeft;
        UpdateVinegarLeftText();
    }
    public void SetJoyLeft(int joyLeft)
    {
        this.joyLeft = joyLeft;
        UpdateJoyLeftText();
    }
    public void SetSurfLeft(int surfLeft)
    {
        this.surfLeft = surfLeft;
        UpdateSurfLeftText();
    }
    public int GetGoyaCandyLeft()
    { return goyaCandyLeft; }

    public int GetMentosLeft()
    { return mentosLeft; }

    public int GetWhiteRabbitLeft()
    { return whiteRabbitLeft; }

    public int GetRiceLeft() 
    { return riceLeft; }
    public int GetSoySauceLeft() 
    { return soySauceLeft; }
    public int GetVinegarLeft() 
    { return vinegarLeft; }
    public int GetJoyLeft() 
    { return joyLeft; }
    public int GetSurfLeft() 
    { return surfLeft; }
}
