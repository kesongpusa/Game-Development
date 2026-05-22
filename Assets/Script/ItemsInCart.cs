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

    public Text totalGoyaCandyText, totalMentosText;

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
    }

    public void ClearCart()
    {
        cartItems.Clear();

        totalItems = 0;
        totalGoyaCandy = 0;
        totalMentos = 0;

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
}
