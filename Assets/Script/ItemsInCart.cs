using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemsInCart : MonoBehaviour
{
    private int totalItems = 0;
    public Text totalItemsText;

    private int totalCandy = 0; 
    private int totalCookie = 0;

    public Text totalCandyText, totalCookieText;

    private List<string> cartItems = new List<string>();

    public ItemsLeft itemsLeft;
    public void AddItem(string ItemName)
    {
        cartItems.Add(ItemName);
        Debug.Log("Added to cart: " + ItemName);

        if (ItemName.Equals("Piece of Candy"))
        { totalCandy++; Debug.Log($"Added Candy to Cart"); }
        else if (ItemName.Equals("Cookie"))
        { totalCookie++; Debug.Log($"Added Cookie to Cart"); }

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
        totalCandyText.text = $"Candy: {totalCandy}";
        totalCookieText.text = $"Cookie: {totalCookie}";
    }

    public void ClearCart()
    {
        cartItems.Clear();

        totalItems = 0;
        totalCandy = 0;
        totalCookie = 0;

        UpdateTotalText();
    }
    public int GetTotalItems()
    { return totalItems; }

    public List<string> GetCartItems()
    { return cartItems; }

    public int GetTotalCandy()
    { return totalCandy; }
    public int GetTotalCookie() 
    { return totalCookie; }
}
