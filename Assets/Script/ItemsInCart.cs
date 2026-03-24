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

    private List<string> cartItems = new List<string>();

    public ItemsLeft itemsLeft;
    public void AddItem(string ItemName)
    {
        cartItems.Add(ItemName);
        Debug.Log("Added to cart: " + ItemName);

        if (ItemName.Equals("Piece of Candy"))
        { totalCandy++; }
        else if (ItemName.Equals("Cookie"))
        { totalCookie++; }

        AddItemsInCart();
    }
    public void AddItemsInCart()
    {
        totalItems++;
        UpdateTotalItemsText();
    }
    void UpdateTotalItemsText()
    {
        totalItemsText.text = $"Total Items: {totalItems}";
    }

    public void OnClick()
    {
        //itemsLeft.candyLeft = 10;
        //itemsLeft.cookieLeft = 10;

        totalCandy = 0;
        totalCookie = 0;

        totalItems = 0;
        UpdateTotalItemsText();
    }
}
