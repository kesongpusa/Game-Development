using UnityEngine;
using UnityEngine.UI;

public class ItemsLeft : MonoBehaviour
{
    private int goyaCandyLeft;
    private int mentosLeft;

    public Text goyaCandyLeftText;
    public Text mentosLeftText;

    void Start()
    {
        goyaCandyLeft = 10;
        mentosLeft = 10;

        UpdateGoyaCandyLeftText();
        UpdateMentosLeftText();
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

    public int GetGoyaCandyLeft()
    { return goyaCandyLeft; }

    public int GetMentosLeft()
    { return mentosLeft; }
}
