using System.Data.Common;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    private GameObject clickObject;
    public GameObject origObject;
    private GameObject draggedObject;

    public Texture2D defaultCursor;
    public Texture2D dragCursor;

    private bool isMouseDown = false;
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
            isMouseDown = true;
            
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

            if (raycastHit2D.collider != null)
            {
                clickObject = raycastHit2D.collider.gameObject;

                if (clickObject.CompareTag("Draggable"))
                {
                    draggedObject = Instantiate(origObject, mouseWorldPos, Quaternion.identity);

                    draggedObject.SetActive(true);
                    draggedObject.transform.localScale = new Vector3(0.12f, 0.12f, -0.40f);

                    Cursor.SetCursor(dragCursor, Vector2.zero, CursorMode.Auto);                    

                    Debug.Log("Started dragging clone of: " + clickObject.name);
                }
            }

            Debug.Log("Clicked on object: " + clickObject.name);
        }

        // While dragging, move the clone with the mouse
        if (Input.GetMouseButton(0) && draggedObject != null)
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


        // Mouse released, stop dragging and check for drop
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;

            clickObject = null;

            if (draggedObject != null && nextHoverObject != null && nextHoverObject.CompareTag("GiveOrder"))
            {
                ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                if (cs != null)
                {
                    cs.ResetSprite(); // reset when dropped
                }
            }

            Destroy(draggedObject);
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
