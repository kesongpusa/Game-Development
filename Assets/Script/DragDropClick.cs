using System.Data.Common;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
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

    void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        int roll = orderScript.getRoll();
        Debug.Log($"[DRAGDROPCLICK] Current Roll: {roll}");

        string itemRequest = orderScript.getItemRequest(roll);
        int quantityItemRequest = orderScript.getQuantityItemRequest(roll);

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

                if (clickObject.CompareTag("Cart"))
                { 
                    GiveItemToCatFromCart();
                    itemsInCart.ClearCart();
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
                    if (nextHoverObject.CompareTag("GiveOrder") && cleanDraggedName.Equals(itemRequest))
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

                    /*
                    if (cleanDraggedName.Equals("Piece of Candy"))
                    {
                        itemsLeft.DecreaseCandy();
                    }
                    else if (cleanDraggedName.Equals("Cookie"))
                    {
                        itemsLeft.DecreaseCookie();
                    }

                    orderScript.addScoreToOrder(1);
                    cs.ResetSprite();
                    */

                    if (cleanDraggedName.Equals(itemRequest))
                    {
                        itemsLeft.DecreaseItem(itemRequest);

                        orderScript.DecreaseItemRequest(roll, quantityItemRequest);

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

        if (totalItemsInCart > 0)
        {
            orderScript.addScoreToOrder(totalItemsInCart);
            itemsInCart.ClearCart();
        }
    }
}
