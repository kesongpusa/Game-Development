using UnityEngine;

public class LimitingCustomers : MonoBehaviour
{
    public ChangeCustomers changeCustomers;

    private int maxCustomers;

    private void Start()
    {
        int maxCustomerCount = changeCustomers.GetMaxCustomers();

        int randomMaxCustomers = Random.Range(1, maxCustomerCount - 3);

        maxCustomers = randomMaxCustomers;
        Debug.Log("[LIMITINGCUSTOMERS] Limiting customers to: " + maxCustomers);
    }
    public int GetMaxCustomers()
    {
        Debug.Log("[LIMITINGCUSTOMERS] Maximum customers allowed: " + maxCustomers);
        return maxCustomers;
    }
}
