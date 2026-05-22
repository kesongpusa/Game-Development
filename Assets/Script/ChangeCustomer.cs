using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCustomers : MonoBehaviour
{
    public GameObject currectCustomer;

    public Sprite[] lineupCustomers;

    public Text textScore;

    private int rotation = 0;
    private List<string> customerName = new List<string>();

    public void RandomCustomerPicker()
    {
        rotation += 1;

        Sprite currentSprite = currectCustomer.GetComponent<SpriteRenderer>().sprite;
        string currectCustomerName = currentSprite.name;

        Debug.Log($"[CHANGECUSTOMER] Current Customer Name: {currectCustomerName}");

        customerName.Add(currectCustomerName);

        int randomCustomer = Random.Range(0, lineupCustomers.Length);
        currectCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];

        Sprite nextCustomer = currectCustomer.GetComponent<SpriteRenderer>().sprite;
        string nextCustomerName = nextCustomer.name;

        Debug.Log($"[CHANGECUSTOMER] Randomly picked customer index: {randomCustomer}, name: {lineupCustomers[randomCustomer].name}");

        while (isCustomerDone(nextCustomerName))
        {
            randomCustomer = Random.Range(0, lineupCustomers.Length);
            currectCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];

            nextCustomer = currectCustomer.GetComponent<SpriteRenderer>().sprite;
            nextCustomerName = nextCustomer.name;
            Debug.Log($"[CHANGECUSTOMER] Customer {nextCustomerName} is already done. " +
                $"Picking another customer index: {randomCustomer}");
        }

        SetTextScore();
    }

    public void SetTextScore()
    {
        textScore.text = $"Customers Served: {rotation.ToString()}";
        Debug.Log($"[CHANGECUSTOMER] Updated score text: Customers Served: {rotation}");
    }

    private bool isCustomerDone(string name)
    {
        if (customerName.Contains(name))
        {
            Debug.Log($"[CHANGECUSTOMER] Customer {name} is already done.");
            return true;
        }
        
        return false;
    }
}
