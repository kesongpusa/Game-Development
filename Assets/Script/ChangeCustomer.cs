using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCustomers : MonoBehaviour
{
    public GameObject currectCustomer;

    public Sprite[] lineupCustomers;

    private int rotation = 0;
    private List<string> customerName = new List<string>();

    public void RandomCustomerPicker()
    {
        rotation++;

        string currectCustomerName = currectCustomer.name;
        Debug.Log($"[CHANGECUSTOMER] Current Customer Name: {currectCustomerName}");

        customerName.Add(currectCustomerName);

        int randomCustomer = Random.Range(0, lineupCustomers.Length);
        currectCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];
        Debug.Log($"[CHANGECUSTOMER] Randomly picked customer index: {randomCustomer}, name: {lineupCustomers[randomCustomer].name}");

        while (!isCustomerDone(customerName))
        {
            randomCustomer = Random.Range(0, lineupCustomers.Length);
            currectCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];
            Debug.Log($"[CHANGECUSTOMER] Customer {lineupCustomers[randomCustomer].name} is already done. " +
                $"Picking another customer index: {randomCustomer}");
        }

    }

    private bool isCustomerDone(List<string> customerName)
    {
        foreach (string name in customerName)
        {
            if (name == currectCustomer.name)
            {
                Debug.Log($"[CHANGECUSTOMER] Customer {name} is already done.");
                return true;
            }
        }

        return false;
    }
}
