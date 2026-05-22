using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCustomers : MonoBehaviour
{
    public LimitingCustomers limitCustomers;

    public GameObject currentCustomer;
    public GameObject restartButton;

    public Sprite[] lineupCustomers;

    public Text textScore;

    private int maxCustomers;
    private int countCustomers;
    private int rotation = 0;
    private List<string> customerName = new List<string>();

    private void Start()
    {
        countCustomers = lineupCustomers.Length;

        Debug.Log($"[CHANGECUSTOMER] Total number of customers in lineup: {countCustomers}");
    }
    public void RandomCustomerPicker()
    {
        rotation += 1;
        SetTextScore();

        maxCustomers = limitCustomers.GetMaxCustomers();

        if (rotation == maxCustomers)
        {
            currentCustomer.SetActive(false);
            restartButton.SetActive(true);

            Debug.Log($"[CHANGECUSTOMER] Player Win");
            return;
        }
        else { Debug.Log($"[CHANGECUSTOMER] Is winning? Score: {rotation} "); }
       
        Sprite currentSprite = currentCustomer.GetComponent<SpriteRenderer>().sprite;
        string currectCustomerName = currentSprite.name;

        Debug.Log($"[CHANGECUSTOMER] Current Customer Name: {currectCustomerName}");

        customerName.Add(currectCustomerName);

        int randomCustomer = Random.Range(0, maxCustomers);
        currentCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];

        Sprite nextCustomer = currentCustomer.GetComponent<SpriteRenderer>().sprite;
        string nextCustomerName = nextCustomer.name;

        Debug.Log($"[CHANGECUSTOMER] Randomly picked customer index: {randomCustomer}, name: {lineupCustomers[randomCustomer].name}");

        while (isCustomerDone(nextCustomerName))
        {
            randomCustomer = Random.Range(0, maxCustomers);
            currentCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];

            nextCustomer = currentCustomer.GetComponent<SpriteRenderer>().sprite;
            nextCustomerName = nextCustomer.name;
            Debug.Log($"[CHANGECUSTOMER] Customer {nextCustomerName} is already done. " +
                $"Picking another customer index: {randomCustomer}");
        }        
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

    public int GetMaxCustomers()
    { return countCustomers; }
}
