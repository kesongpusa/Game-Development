using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemsInCart : MonoBehaviour
{
    private int totalItems = 0;
    public Text totalItemsText;

    private int totalGoyaCandy = 0; 
    private int totalMentos = 0;
    private int totalWhiteRabbit = 0;
    private int totalRice = 0;
    private int totalSoySauce = 0;
    private int totalVinegar = 0;
    private int totalJoy = 0;
    private int totalSurf = 0;
    private int totalPaylessXtraBig = 0;
    private int totalLuckyMe = 0;
    private int totalCupNoodle = 0;

    public Text totalGoyaCandyText, totalMentosText, totalWhiteRabbitText,
        totalRiceText, totalSoySauceText, totalVinegarText,
        totalJoyText, totalSurfText,
        totalPaylessXtraBigText, totalLuckyMeText, totalCupNoodleText;

    private List<string> cartItems = new List<string>();

    public ItemsLeft itemsLeft;
    public void AddItem(string ItemName)
    {
        cartItems.Add(ItemName);
        Debug.Log("Added to cart: " + ItemName);

        if (ItemName.Equals("Goya Candy"))
        { totalGoyaCandy++; Debug.Log($"Added Goya Candy to Cart"); }
        else if (ItemName.Equals("Mentos"))
        { totalMentos++; Debug.Log($"Added Mentos to Cart"); }
        else if (ItemName.Equals("White Rabbit"))
        { totalWhiteRabbit++; Debug.Log($"Added White Rabbit to Cart"); }
        else if (ItemName.Equals("Rice"))
        { totalRice++; Debug.Log($"Added Rice to Cart"); }
        else if (ItemName.Equals("Soy Sauce"))
        { totalSoySauce++; Debug.Log($"Added Soy Sauce to Cart"); }
        else if (ItemName.Equals("Vinegar"))
        { totalVinegar++; Debug.Log($"Added Vinegar to Cart"); }
        else if (ItemName.Equals("Joy"))
        { totalJoy++; Debug.Log($"Added Joy to Cart"); }
        else if (ItemName.Equals("Surf"))
        { totalSurf++; Debug.Log($"Added Surf to Cart"); }
        else if (ItemName.Equals("Payless Xtra Big"))
        { totalPaylessXtraBig++; Debug.Log($"Added Payless Xtra Big to Cart"); }
        else if (ItemName.Equals("Lucky Me"))
        { totalLuckyMe++; Debug.Log($"Added Lucky Me to Cart"); }
        else if (ItemName.Equals("Cup Noodle"))
        { totalCupNoodle++; Debug.Log($"Added Cup Noodle to Cart"); }

        AddItemsInCart();
    }
    public void AddItemsInCart()
    {
        totalItems++;
        UpdateTotalText();
    }

    public void UpdateTotalText()
    {
        if (totalItems >= 0)
        {
            if (totalGoyaCandy > 0)
            { totalGoyaCandyText.enabled = true; }
            else { totalGoyaCandyText.enabled = false; }

            if (totalMentos > 0)
            { totalMentosText.enabled = true; }
            else { totalMentosText.enabled = false; }

            if (totalWhiteRabbit > 0)
            { totalWhiteRabbitText.enabled = true; }
            else { totalWhiteRabbitText.enabled = false; }

            if (totalRice > 0)
            { totalRiceText.enabled = true; }
            else { totalRiceText.enabled = false; }

            if (totalSoySauce > 0)
            { totalSoySauceText.enabled = true; }
            else { totalSoySauceText.enabled = false; }

            if (totalVinegar > 0)
            { totalVinegarText.enabled = true; }
            else { totalVinegarText.enabled = false; }

            if (totalJoy > 0)
            { totalJoyText.enabled = true; }
            else { totalJoyText.enabled = false; }

            if (totalSurf > 0)
            { totalSurfText.enabled = true; }
            else { totalSurfText.enabled = false; }

            if (totalPaylessXtraBig > 0)
            { totalPaylessXtraBigText.enabled = true; }
            else { totalPaylessXtraBigText.enabled = false; }

            if (totalLuckyMe > 0)
            { totalLuckyMeText.enabled = true; }
            else { totalLuckyMeText.enabled = false; }

            if (totalCupNoodle > 0)
            { totalCupNoodleText.enabled = true; }
            else { totalCupNoodleText.enabled = false; }
        }

        totalItemsText.text = $"Total Items: {totalItems}";
        totalGoyaCandyText.text = $"Goya: {totalGoyaCandy}";
        totalMentosText.text = $"Mentos: {totalMentos}";
        totalWhiteRabbitText.text = $"White Rabbit: {totalWhiteRabbit}";
        totalRiceText.text = $"Rice: {totalRice}";
        totalSoySauceText.text = $"Soy Sauce: {totalSoySauce}";
        totalVinegarText.text = $"Vinegar: {totalVinegar}";
        totalJoyText.text = $"Joy: {totalJoy}";
        totalSurfText.text = $"Surf: {totalSurf}";
        totalPaylessXtraBigText.text = $"Payless Xtra Big: {totalPaylessXtraBig}";
        totalLuckyMeText.text = $"Lucky Me: {totalLuckyMe}";
        totalCupNoodleText.text = $"Cup Noodle: {totalCupNoodle}";
    }

    public void ClearCart()
    {
        cartItems.Clear();

        totalItems = 0;
        
        totalGoyaCandy = 0; totalMentos = 0; totalWhiteRabbit = 0;
        
        totalRice = 0; totalSoySauce = 0; totalVinegar = 0;

        totalJoy = 0; totalSurf = 0;

        totalPaylessXtraBig = 0; totalLuckyMe = 0; totalCupNoodle = 0;

        UpdateTotalText();
    }
    public int GetTotalItems()
    { return totalItems; }

    public List<string> GetCartItems()
    { return cartItems; }

    public int GetTotalGoyaCandy()
    { return totalGoyaCandy; }
    public int GetTotalMentos() 
    { return totalMentos; }
    public int GetTotalWhiteRabbit() 
    { return totalWhiteRabbit; }
    public int GetTotalRice() 
    { return totalRice; }
    public int GetTotalSoySauce() 
    { return totalSoySauce; }
    public int GetTotalVinegar() 
    { return totalVinegar; }
    public int GetTotalJoy() 
    { return totalJoy; }
    public int GetTotalSurf() 
    { return totalSurf; }
    public int GetTotalPaylessXtraBig() 
    { return totalPaylessXtraBig; }
    public int GetTotalLuckyMe() 
    { return totalLuckyMe; }
    public int GetTotalCupNoodle() 
    { return totalCupNoodle; }
}
