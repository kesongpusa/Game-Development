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

    public Text goyaCandyLeftText;
    public Text mentosLeftText;
    public Text whiteRabbitLeftText;
    public Text riceLeftText;
    public Text soySauceLeftText;
    public Text vinegarLeftText;

    void Start()
    {
        goyaCandyLeft = 10;
        mentosLeft = 10;
        whiteRabbitLeft = 10;
        riceLeft = 10;
        soySauceLeft = 10;
        vinegarLeft = 10;

        UpdateGoyaCandyLeftText();
        UpdateMentosLeftText();
        UpdateWhiteRabbitLeftText();
        UpdateRiceLeftText();
        UpdateSoySauceLeftText();
        UpdateVinegarLeftText();
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
}
