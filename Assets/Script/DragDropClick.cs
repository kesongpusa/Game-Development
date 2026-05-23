using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;

public class DragDropClick : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    private GameObject clickObject;
    public GameObject origObjectGoyaCandy;
    public GameObject origObjectMentos;
    public GameObject origObjectWhiteRabbit;
    private GameObject draggedObject;

    public GameObject goyaJarObject, mentosJarObject,
        whiteRabbitJarObject;

    public Texture2D defaultCursor;
    public Texture2D dragCursor;

    public OrderScript orderScript;
    public ItemsLeft itemsLeft;
    public ItemsInCart itemsInCart;

    private float mouseHoldTime;
    public float holdThreshold;
    private bool isDragging = false;

    private List<string> itemsRequest;
    private List<int> quantityItemRequest;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);

        GetItemListRequestAndQuantity();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2D = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        nextHoverObject = raycastHit2D ? raycastHit2D.collider.transform : null;

        // Handle mouse click to start dragging
        if (Input.GetMouseButtonDown(0))
        {            
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

            if (raycastHit2D.collider != null)
            {
                clickObject = raycastHit2D.collider.gameObject;

                if (clickObject.CompareTag("Draggable"))
                {
                    mouseHoldTime = 0f;
                    isDragging = false;

                    if (clickObject.name == "Goya Jar")
                    {
                        draggedObject = Instantiate(origObjectGoyaCandy, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Mentos Jar")
                    {
                        draggedObject = Instantiate(origObjectMentos, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "White Rabbit Jar")
                    {
                        draggedObject = Instantiate(origObjectWhiteRabbit, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }

                    Debug.Log("[MOUSEDOWN] Started dragging clone of: " + clickObject.name);
                }
            }

            if (clickObject != null)
            { Debug.Log("Clicked on object: " + clickObject.name); }
        }

        // While dragging, move the clone with the mouse
        if (Input.GetMouseButton(0) && draggedObject != null)
        {
            string cleanDraggedName = draggedObject.name.Replace("(Clone)", "").Trim();
            Debug.Log($"[HOLDMOUSE] Dragged Object: {cleanDraggedName}");

            if (mouseHoldTime >= holdThreshold)
            {
                isDragging = true;
                draggedObject.SetActive(true);
                Cursor.SetCursor(dragCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                mouseHoldTime += Time.deltaTime;
                isDragging = false;
            }

            Debug.Log($"[HOLDMOUSE] Mouse hold time: {mouseHoldTime:F2} seconds, IsDragging: {isDragging}");

            if (isDragging)
            {
                draggedObject.transform.position = mouseWorldPos;

                Debug.Log($"[HOLDMOUSE] Hovering over: {(nextHoverObject != null ? nextHoverObject.name : "nothing")}");

                if (nextHoverObject != null)
                {
                    int indexOfQuantity = -1;
                    if (itemsRequest.Contains(cleanDraggedName))
                    {
                        int indexOf = itemsRequest.IndexOf(cleanDraggedName);
                        Debug.Log($"[HOLDMOUSE] Position of {cleanDraggedName}: {indexOf}");

                        indexOfQuantity = quantityItemRequest[indexOf];
                    }
                    

                    if (nextHoverObject.CompareTag("GiveOrder") && itemsRequest.Contains(cleanDraggedName) && 
                        indexOfQuantity > 0)
                    {
                        ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                        if (cs != null)
                        {
                            cs.HighlightSprite();
                        }
                    }
                    else
                    {
                        ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                        if (cs != null)
                        {
                            cs.noAcceptItemSprite();
                        }
                    }
                }
                else
                {
                    // If nothing is hovered, reset the previous Cat Eat
                    if (prevHoverObject != null && prevHoverObject.CompareTag("GiveOrder"))
                    {
                        ChangeSprite csPrev = prevHoverObject.GetComponent<ChangeSprite>();
                        if (csPrev != null)
                        {
                            csPrev.ResetSprite();
                        }
                    }
                }
            }
        }


        // Mouse released
        if (Input.GetMouseButtonUp(0))
        {
            // Order to the cat if dropped on the cat
            if (draggedObject != null && nextHoverObject != null && nextHoverObject.CompareTag("GiveOrder"))
            {
                ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                if (cs != null)
                {
                    string cleanDraggedName = draggedObject.name.Replace("(Clone)", "").Trim();
                    Debug.Log($"[MOUSEUP] Dragged Object: {cleanDraggedName}");

                    int indexOfQuantity = -1;
                    if (itemsRequest.Contains(cleanDraggedName))
                    {
                        int indexOf = itemsRequest.IndexOf(cleanDraggedName);
                        Debug.Log($"[HOLDMOUSE] Position of {cleanDraggedName}: {indexOf}");

                        indexOfQuantity = quantityItemRequest[indexOf];
                    }

                    if (itemsRequest.Contains(cleanDraggedName) && indexOfQuantity > 0)
                    {
                        itemsLeft.DecreaseItem(cleanDraggedName);

                        orderScript.DecreaseItemRequest(cleanDraggedName, 1);
                    }
                    
                    cs.ResetSprite();
                }
            }

            // If it was a click (not a drag), add item to cart
            if (!isDragging && (mouseHoldTime < holdThreshold))
            {
                if (clickObject != null)
                {
                    if (clickObject.name.Equals("Goya Jar"))
                    {
                        itemsInCart.AddItem("Goya Candy");
                        itemsLeft.DecreaseGoyaCandy();
                    }
                    else if (clickObject.name.Equals("Mentos Jar"))
                    {
                        itemsInCart.AddItem("Mentos");
                        itemsLeft.DecreaseMentos();
                    }
                    else if (clickObject.name.Equals("White Rabbit Jar"))
                    {
                        itemsInCart.AddItem("White Rabbit");
                        itemsLeft.DecreaseWhiteRabbit();
                    }

                    // If the click was on the cart, give items to cat
                    if (clickObject.CompareTag("Cart"))
                    {
                        GiveItemToCatFromCart();
                        itemsInCart.ClearCart();
                    }
                }
            }

            Destroy(draggedObject);
            draggedObject = null;
            clickObject = null;

            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);

            CheckItemsLeft();
        }
    }

    void CheckItemsLeft()
    {
        int goyaCandyLeft = itemsLeft.GetGoyaCandyLeft();
        int mentosLeft = itemsLeft.GetMentosLeft();
        int whiteRabbitLeft = itemsLeft.GetWhiteRabbitLeft();

        Debug.Log($"[CHECKITEMSLEFT] Goya Candy Left: {goyaCandyLeft}, " +
            $"Mentos Left: {mentosLeft}, White Rabbit Left: {whiteRabbitLeft}");

        if (goyaCandyLeft == 0)
        { goyaJarObject.SetActive(false); }
        else {  goyaJarObject.SetActive(true); }

        if (mentosLeft == 0)
        { mentosJarObject.SetActive(false); }
        else { mentosJarObject.SetActive(true); }

        if (whiteRabbitLeft == 0)
        { whiteRabbitJarObject.SetActive(false); }
        else { whiteRabbitJarObject.SetActive(true); }
    }

    private void GiveItemToCatFromCart()
    {
        int totalItemsInCart = itemsInCart.GetTotalItems();

        List<string> cartItems = itemsInCart.GetCartItems();

        if (cartItems.Any(item => itemsRequest.Contains(item)))
        {
            Debug.Log("[CART] Giving items to cat from cart...");
            int totalGoyaCandy = itemsInCart.GetTotalGoyaCandy();
            int totalMentos = itemsInCart.GetTotalMentos();
            int totalWhiteRabbit = itemsInCart.GetTotalWhiteRabbit();

            if (itemsRequest.Contains("Goya Candy") && totalGoyaCandy > 0)
            {
                int goyaCandyToGive = Mathf.Min(totalGoyaCandy, quantityItemRequest[itemsRequest.IndexOf("Goya Candy")]);
                orderScript.DecreaseItemRequest("Goya Candy", goyaCandyToGive);
                totalItemsInCart -= goyaCandyToGive;
            }

            if (itemsRequest.Contains("Mentos") && totalMentos > 0)
            {
                int mentosToGive = Mathf.Min(totalMentos, quantityItemRequest[itemsRequest.IndexOf("Mentos")]);
                orderScript.DecreaseItemRequest("Mentos", mentosToGive);
                totalItemsInCart -= mentosToGive;
            }

            if (itemsRequest.Contains("White Rabbit") && totalWhiteRabbit > 0)
            {
                int whiteRabbitToGive = Mathf.Min(totalWhiteRabbit, quantityItemRequest[itemsRequest.IndexOf("White Rabbit")]);
                orderScript.DecreaseItemRequest("White Rabbit", whiteRabbitToGive);
                totalItemsInCart -= whiteRabbitToGive;
            }
        }
    }

    public void GetItemListRequestAndQuantity()
    {
        itemsRequest = new List<string>(orderScript.getItemsRequest());
        quantityItemRequest = new List<int>(orderScript.getQuantitiesRequest());

        for (int i = 0; i < itemsRequest.Count; i++)
        {
            Debug.Log($"[DRAGDROPCLICK] Item Request {i + 1}: {itemsRequest[i]}, Quantity: {quantityItemRequest[i]}");
        }
    }

    public void setItemsRequest(List<string> itemsRequest) { this.itemsRequest = itemsRequest; }
    public void setQuantitiesRequest(List<int> quantityItemRequest) { this.quantityItemRequest = quantityItemRequest; }
    public List<string> getItemsRequest() { return itemsRequest; }
    public List<int> getQuantitiesRequest() { return quantityItemRequest; }
}
