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

                        //itemsInCart.AddItem("Piece of Candy");
                        //itemsLeft.DecreaseCandy();
                    }
                    else if (clickObject.name == "Cookies")
                    {
                        draggedObject = Instantiate(origObjectCookie, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.015f, 0.015f, 0f);

                        //itemsInCart.AddItem("Cookie");
                        //itemsLeft.DecreaseCookie();
                    }

                    Debug.Log("Started dragging clone of: " + clickObject.name);
                }
            }

            Debug.Log("Clicked on object: " + clickObject.name);
        }

        // While dragging, move the clone with the mouse
        if (Input.GetMouseButton(0) && draggedObject != null)
        {
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

            Debug.Log($"Mouse hold time: {mouseHoldTime:F2} seconds, IsDragging: {isDragging}");

            if (isDragging)
            {
                draggedObject.transform.position = mouseWorldPos;

                Debug.Log($"Hovering over: {(nextHoverObject != null ? nextHoverObject.name : "nothing")}");

                if (nextHoverObject != null)
                {
                    if (nextHoverObject.CompareTag("GiveOrder"))
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


        // Mouse released, stop dragging and check for drop
        if (Input.GetMouseButtonUp(0))
        {
            if (draggedObject != null && nextHoverObject != null && nextHoverObject.CompareTag("GiveOrder"))
            {
                ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                if (cs != null)
                {
                    string cleanDraggedName = draggedObject.name.Replace("(Clone)", "").Trim();
                    Debug.Log($"Dragged Object: {cleanDraggedName}");

                    if (cleanDraggedName.Equals("Piece of Candy"))
                    {
                        itemsLeft.DecreaseCandy();
                        
                        int candyLeft = itemsLeft.candyLeft;

                        if (candyLeft == 0)
                        {
                            candyObject.SetActive(false);
                        }
                    }
                    else if (cleanDraggedName.Equals("Cookie"))
                    {
                        itemsLeft.DecreaseCookie();
                        
                        int cookieLeft = itemsLeft.cookieLeft;

                        if (cookieLeft == 0)
                        {
                            cookiesObject.SetActive(false);
                        }
                    }

                    orderScript.addScoreToOrder();
                    cs.ResetSprite();
                }
            }

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
                draggedObject = null;
                clickObject = null;
            }

            Destroy(draggedObject);
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
