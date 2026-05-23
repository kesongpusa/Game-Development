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

    public Text totalGoyaCandyText, totalMentosText, totalWhiteRabbitText,
        totalRiceText, totalSoySauceText, totalVinegarText;

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

        AddItemsInCart();
    }
    public void AddItemsInCart()
    {
        totalItems++;
        UpdateTotalText();
    }

    public void UpdateTotalText()
    {
        totalItemsText.text = $"Total Items: {totalItems}";
        totalGoyaCandyText.text = $"Goya: {totalGoyaCandy}";
        totalMentosText.text = $"Mentos: {totalMentos}";
        totalWhiteRabbitText.text = $"White Rabbit: {totalWhiteRabbit}";
        totalRiceText.text = $"Rice: {totalRice}";
        totalSoySauceText.text = $"Soy Sauce: {totalSoySauce}";
        totalVinegarText.text = $"Vinegar: {totalVinegar}";
    }

    public void ClearCart()
    {
        cartItems.Clear();

        totalItems = 0;
        totalGoyaCandy = 0;
        totalMentos = 0;
        totalWhiteRabbit = 0;
        totalRice = 0;
        totalSoySauce = 0;
        totalVinegar = 0;

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
}
