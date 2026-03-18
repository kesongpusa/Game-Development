using UnityEngine;
using UnityEngine.UI;

public class ItemsLeft : MonoBehaviour
{
    public int candyLeft = 10;
    public int cookieLeft = 10;

    public Text candyLeftText;
    public Text cookieLeftText;

    void Start()
    {
        UpdateCandyText();
        UpdateCookieText();
    }
    public void DecreaseCandy()
    {
        if (candyLeft > 0)
        {
            candyLeft--;
            UpdateCandyText();
        }
    }

    public void DecreaseCookie()
    {
        if (cookieLeft > 0)
        {
            cookieLeft--;
            UpdateCookieText();
        }
    }

    void UpdateCandyText()
    {
        candyLeftText.text = $"{candyLeft}";
    }

    void UpdateCookieText()
    {
        cookieLeftText.text = $"{cookieLeft}";
    }
}
