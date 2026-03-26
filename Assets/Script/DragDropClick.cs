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
    public GameObject origObjectCandy;
    public GameObject origObjectCookie;
    private GameObject draggedObject;

    public GameObject candyObject, cookiesObject;

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
    private int copyList = 0;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (copyList == 0)
        {
            GetItemListRequestAndQuantity();
            copyList++;
        }

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

                    if (clickObject.name == "Candy")
                    {
                        draggedObject = Instantiate(origObjectCandy, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.12f, 0.12f, 0f);
                    }
                    else if (clickObject.name == "Cookies")
                    {
                        draggedObject = Instantiate(origObjectCookie, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.015f, 0.015f, 0f);
                    }

                    Debug.Log("[MOUSEDOWN] Started dragging clone of: " + clickObject.name);
                }
            }

            Debug.Log("Clicked on object: " + clickObject.name);
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

                        orderScript.addScoreToOrder(1);
                    }
                    
                    cs.ResetSprite();
                }
            }

            // If it was a click (not a drag), add item to cart
            if (!isDragging && (mouseHoldTime < holdThreshold))
            {
                if (clickObject.name.Equals("Candy"))
                {
                    itemsInCart.AddItem("Piece of Candy");
                    itemsLeft.DecreaseCandy();
                }
                else if (clickObject.name.Equals("Cookies"))
                {
                    itemsInCart.AddItem("Cookie");
                    itemsLeft.DecreaseCookie();
                }

                // If the click was on the cart, give items to cat
                if (clickObject.CompareTag("Cart"))
                {
                    GiveItemToCatFromCart();
                    itemsInCart.ClearCart();
                }
            }

            Destroy(draggedObject);
            draggedObject = null;
            clickObject = null;

            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }

        CheckItemsLeft();
    }

    void CheckItemsLeft()
    {
        if (itemsLeft.candyLeft == 0)
        { candyObject.SetActive(false); }
    
        if (itemsLeft.cookieLeft == 0)
        { cookiesObject.SetActive(false); }
    }

    void GiveItemToCatFromCart()
    {
        int totalItemsInCart = itemsInCart.GetTotalItems();

        List<string> cartItems = itemsInCart.GetCartItems();

        if (cartItems.Any(item => itemsRequest.Contains(item)))
        {
            Debug.Log("[CART] Giving items to cat from cart...");
            int totalCandy = itemsInCart.GetTotalCandy();
            int totalCookie = itemsInCart.GetTotalCookie();

            if (itemsRequest.Contains("Piece of Candy") && totalCandy > 0)
            {
                int candyToGive = Mathf.Min(totalCandy, quantityItemRequest[itemsRequest.IndexOf("Piece of Candy")]);
                orderScript.DecreaseItemRequest("Piece of Candy", candyToGive);
                orderScript.addScoreToOrder(candyToGive);
                totalItemsInCart -= candyToGive;
            }

            if (itemsRequest.Contains("Cookie") && totalCookie > 0)
            {
                int cookieToGive = Mathf.Min(totalCookie, quantityItemRequest[itemsRequest.IndexOf("Cookie")]);
                orderScript.DecreaseItemRequest("Cookie", cookieToGive);
                orderScript.addScoreToOrder(cookieToGive);
                totalItemsInCart -= cookieToGive;
            }
        }
    }

    void GetItemListRequestAndQuantity()
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
