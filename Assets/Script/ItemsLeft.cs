using UnityEngine;
using UnityEngine.UI;

public class ItemsLeft : MonoBehaviour
{
    private int goyaCandyLeft;
    private int mentosLeft;
    private int whiteRabbitLeft;

    public Text goyaCandyLeftText;
    public Text mentosLeftText;
    public Text whiteRabbitText;

    void Start()
    {
        goyaCandyLeft = 10;
        mentosLeft = 10;
        whiteRabbitLeft = 10;

        UpdateGoyaCandyLeftText();
        UpdateMentosLeftText();
        UpdateWhiteRabbitLeftText();
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
        whiteRabbitText.text = $"{whiteRabbitLeft}";
        Debug.Log($"[ITEMSLEFT] White Rabbit left: {whiteRabbitLeft}");
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

    public int GetGoyaCandyLeft()
    { return goyaCandyLeft; }

    public int GetMentosLeft()
    { return mentosLeft; }

    public int GetWhiteRabbitLeft()
    { return whiteRabbitLeft; }
}
