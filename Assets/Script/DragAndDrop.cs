using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
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

                    draggedObject.transform.localScale = new Vector3(0.12f, 0.12f, 0.40f);

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
        }


        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;

            clickObject = null;

            if (draggedObject != null)
            {
                Destroy(draggedObject); // remove the clone when dropped
                draggedObject = null;
            }

            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
