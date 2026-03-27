using UnityEngine;
using UnityEngine.UI;

public class ItemsLeft : MonoBehaviour
{
    private int candyLeft;
    private int cookieLeft;

    public Text candyLeftText;
    public Text cookieLeftText;

    void Start()
    {
        candyLeft = 10;
        cookieLeft = 10;

        UpdateCandyLeftText();
        UpdateCookieLeftText();
    }
    public void DecreaseCandy()
    {
        if (candyLeft > 0)
        {
            candyLeft--;
        }
        UpdateCandyLeftText();
    }

    public void DecreaseCookie()
    {
        if (cookieLeft > 0)
        {
            cookieLeft--;
        }

        UpdateCookieLeftText();
    }

    public void DecreaseItem(string item)
    {
        if (item.Equals("Piece of Candy"))
        {
            DecreaseCandy();
        }
        else if (item.Equals("Cookie"))
        {
            DecreaseCookie();
        }
    }

    void UpdateCandyLeftText()
    {
        candyLeftText.text = $"{candyLeft}";
        Debug.Log($"[ITEMSLEFT] Candy left: {candyLeft}");
    }

    void UpdateCookieLeftText()
    {
        cookieLeftText.text = $"{cookieLeft}";
        Debug.Log($"[ITEMSLEFT] Cookies left: {cookieLeft}");
    }

    public void SetCandyLeft(int candyLeft)
    {
        this.candyLeft = candyLeft;
        UpdateCandyLeftText();
    }

    public void SetCookieLeft(int cookieLeft)
    {
        this.cookieLeft = cookieLeft;
        UpdateCookieLeftText();
    }

    public int GetCandyLeft()
    { return candyLeft; }

    public int GetCookieLeft()
    { return cookieLeft; }
}
