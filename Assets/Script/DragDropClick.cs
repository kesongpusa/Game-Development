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

    public GameObject 
        riceObject, soySauceObject, vinegarObject,
        joyObject, surfObject,
        paylessXtraBigObject, luckyMeObject, cupNoodleObject,
        colgateObject, rexonaObject, sunsilkObject,
        chippyObject, novaObject, piattosObject;

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
                    else if (clickObject.name == "Rice")
                    {
                        draggedObject = Instantiate(riceObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Soy Sauce")
                    {
                        draggedObject = Instantiate(soySauceObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Vinegar")
                    {
                        draggedObject = Instantiate(vinegarObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Joy")
                    {
                        draggedObject = Instantiate(joyObject, mouseWorldPos, Quaternion.identity);
                        foreach (Transform child in draggedObject.transform)
                        {
                            Destroy(child.gameObject);
                        }
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Surf")
                    {
                        draggedObject = Instantiate(surfObject, mouseWorldPos, Quaternion.identity);
                        foreach (Transform child in draggedObject.transform)
                        {
                            Destroy(child.gameObject);
                        }
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Payless Xtra Big")
                    {
                        draggedObject = Instantiate(paylessXtraBigObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Lucky Me")
                    {
                        draggedObject = Instantiate(luckyMeObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Cup Noodle")
                    {
                        draggedObject = Instantiate(cupNoodleObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Colgate")
                    {
                        draggedObject = Instantiate(colgateObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Rexona")
                    {
                        draggedObject = Instantiate(rexonaObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Sunsilk")
                    {
                        draggedObject = Instantiate(sunsilkObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Chippy")
                    {
                        draggedObject = Instantiate(chippyObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Nova")
                    {
                        draggedObject = Instantiate(novaObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    else if (clickObject.name == "Piattos")
                    {
                        draggedObject = Instantiate(piattosObject, mouseWorldPos, Quaternion.identity);
                        draggedObject.transform.localScale = new Vector3(0.08f, 0.08f, 0f);
                    }
                    draggedObject.SetActive(false);

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
                draggedObject.SetActive(true);
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
                    else if (clickObject.name.Equals("Rice"))
                    {
                        itemsInCart.AddItem("Rice");
                        itemsLeft.DecreaseRice();
                    }
                    else if (clickObject.name.Equals("Soy Sauce"))
                    {
                        itemsInCart.AddItem("Soy Sauce");
                        itemsLeft.DecreaseSoySauce();
                    }
                    else if (clickObject.name.Equals("Vinegar"))
                    {
                        itemsInCart.AddItem("Vinegar");
                        itemsLeft.DecreaseVinegar();
                    }
                    else if (clickObject.name.Equals("Joy"))
                    {
                        itemsInCart.AddItem("Joy");
                        itemsLeft.DecreaseJoy();
                    }
                    else if (clickObject.name.Equals("Surf"))
                    {
                        itemsInCart.AddItem("Surf");
                        itemsLeft.DecreaseSurf();
                    }
                    else if (clickObject.name.Equals("Payless Xtra Big"))
                    {
                        itemsInCart.AddItem("Payless Xtra Big");
                        itemsLeft.DecreasePaylessXtraBig();
                    }
                    else if (clickObject.name.Equals("Lucky Me"))
                    {
                        itemsInCart.AddItem("Lucky Me");
                        itemsLeft.DecreaseLuckyMe();
                    }
                    else if (clickObject.name.Equals("Cup Noodle"))
                    {
                        itemsInCart.AddItem("Cup Noodle");
                        itemsLeft.DecreaseCupNoodle();
                    }
                    else if (clickObject.name.Equals("Colgate"))
                    {
                        itemsInCart.AddItem("Colgate");
                        itemsLeft.DecreaseColgate();
                    }
                    else if (clickObject.name.Equals("Rexona"))
                    {
                        itemsInCart.AddItem("Rexona");
                        itemsLeft.DecreaseRexona();
                    }
                    else if (clickObject.name.Equals("Sunsilk"))
                    {
                        itemsInCart.AddItem("Sunsilk");
                        itemsLeft.DecreaseSunsilk();
                    }
                    else if (clickObject.name.Equals("Chippy"))
                    {
                        itemsInCart.AddItem("Chippy");
                        itemsLeft.DecreaseChippy();
                    }
                    else if (clickObject.name.Equals("Nova"))
                    {
                        itemsInCart.AddItem("Nova");
                        itemsLeft.DecreaseNova();
                    }
                    else if (clickObject.name.Equals("Piattos"))
                    {
                        itemsInCart.AddItem("Piattos");
                        itemsLeft.DecreasePiattos();
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
        int riceLeft = itemsLeft.GetRiceLeft();
        int soySauceLeft = itemsLeft.GetSoySauceLeft();
        int vinegarLeft = itemsLeft.GetVinegarLeft();
        int joyLeft = itemsLeft.GetJoyLeft();
        int surfLeft = itemsLeft.GetSurfLeft();
        int paylessXtraBigLeft = itemsLeft.GetPaylessXtraBigLeft();
        int luckyMeLeft = itemsLeft.GetLuckyMeLeft();
        int cupNoodleLeft = itemsLeft.GetCupNoodleLeft();
        int colgateLeft = itemsLeft.GetColgateLeft();
        int rexonaLeft = itemsLeft.GetRexonaLeft();
        int sunsilkLeft = itemsLeft.GetSunsilkLeft();
        int chippyLeft = itemsLeft.GetChippyLeft();
        int novaLeft = itemsLeft.GetNovaLeft();
        int piattosLeft = itemsLeft.GetPiattosLeft();

        Debug.Log($"[CHECKITEMSLEFT] Goya Candy Left: {goyaCandyLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Mentos Left: {mentosLeft}");
        Debug.Log($"[CHECKITEMSLEFT] White Rabbit Left: {whiteRabbitLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Rice Left: {riceLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Soy Sauce Left: {soySauceLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Vinegar Left: {vinegarLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Joy Left: {joyLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Surf Left: {surfLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Payless Xtra Big Left: {paylessXtraBigLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Lucky Me Left: {luckyMeLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Cup Noodle Left: {cupNoodleLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Colgate Left: {colgateLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Rexona Left: {rexonaLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Sunsilk Left: {sunsilkLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Chippy Left: {chippyLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Nova Left: {novaLeft}");
        Debug.Log($"[CHECKITEMSLEFT] Piattos Left: {piattosLeft}");

        if (goyaCandyLeft == 0)
        { goyaJarObject.SetActive(false); }
        else {  goyaJarObject.SetActive(true); }

        if (mentosLeft == 0)
        { mentosJarObject.SetActive(false); }
        else { mentosJarObject.SetActive(true); }

        if (whiteRabbitLeft == 0)
        { whiteRabbitJarObject.SetActive(false); }
        else { whiteRabbitJarObject.SetActive(true); }

        if (riceLeft == 0)
        { riceObject.SetActive(false); }
        else { riceObject.SetActive(true); }

        if (soySauceLeft == 0)
        { soySauceObject.SetActive(false); }
        else { soySauceObject.SetActive(true); }

        if (vinegarLeft == 0)
        { vinegarObject.SetActive(false); }
        else { vinegarObject.SetActive(true); }

        if (joyLeft == 0)
        { joyObject.SetActive(false); }
        else 
        {
            if (joyLeft == 2)
            {
                joyObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (joyLeft == 1)
            {
                joyObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                joyObject.SetActive(true);
                joyObject.transform.GetChild(0).gameObject.SetActive(true);
                joyObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (surfLeft == 0)
        { surfObject.SetActive(false); }
        else 
        {
            if (surfLeft == 2)
            { surfObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (surfLeft == 1)
            { surfObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                surfObject.SetActive(true);
                surfObject.transform.GetChild(0).gameObject.SetActive(true);
                surfObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (paylessXtraBigLeft == 0)
        { paylessXtraBigObject.SetActive(false); }
        else { paylessXtraBigObject.SetActive(true); }

        if (luckyMeLeft == 0)
        { luckyMeObject.SetActive(false); }
        else { luckyMeObject.SetActive(true); }

        if (cupNoodleLeft == 0)
        { cupNoodleObject.SetActive(false); }
        else { cupNoodleObject.SetActive(true); }

        if (colgateLeft == 0)
        { colgateObject.SetActive(false); }
        else { colgateObject.SetActive(true); }

        if (rexonaLeft == 0)
        { rexonaObject.SetActive(false); }
        else { rexonaObject.SetActive(true); }

        if (sunsilkLeft == 0)
        { sunsilkObject.SetActive(false); }
        else { sunsilkObject.SetActive(true); }

        if (chippyLeft == 0)
        { chippyObject.SetActive(false); }
        else { chippyObject.SetActive(true); }

        if (novaLeft == 0)
        { novaObject.SetActive(false); }
        else { novaObject.SetActive(true); }

        if (piattosLeft == 0)
        { piattosObject.SetActive(false); }
        else { piattosObject.SetActive(true); }
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
            int totalRice = itemsInCart.GetTotalRice();
            int totalSoySauce = itemsInCart.GetTotalSoySauce();
            int totalVinegar = itemsInCart.GetTotalVinegar();
            int totalJoy = itemsInCart.GetTotalJoy();
            int totalSurf = itemsInCart.GetTotalSurf();
            int totalPaylessXtraBig = itemsInCart.GetTotalPaylessXtraBig();
            int totalLuckyMe = itemsInCart.GetTotalLuckyMe();
            int totalCupNoodle = itemsInCart.GetTotalCupNoodle();
            int totalColgate = itemsInCart.GetTotalColgate();
            int totalRexona = itemsInCart.GetTotalRexona();
            int totalSunsilk = itemsInCart.GetTotalSunsilk();
            int totalChippy = itemsInCart.GetTotalChippy();
            int totalNova = itemsInCart.GetTotalNova();
            int totalPiattos = itemsInCart.GetTotalPiattos();

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

            if (itemsRequest.Contains("Rice") && totalRice > 0)
            {
                int riceToGive = Mathf.Min(totalRice, quantityItemRequest[itemsRequest.IndexOf("Rice")]);
                orderScript.DecreaseItemRequest("Rice", riceToGive);
                totalItemsInCart -= riceToGive;
            }

            if (itemsRequest.Contains("Soy Sauce") && totalSoySauce > 0)
            {
                int soySauceToGive = Mathf.Min(totalSoySauce, quantityItemRequest[itemsRequest.IndexOf("Soy Sauce")]);
                orderScript.DecreaseItemRequest("Soy Sauce", soySauceToGive);
                totalItemsInCart -= soySauceToGive;
            }

            if (itemsRequest.Contains("Vinegar") && totalVinegar > 0)
            {
                int vinegarToGive = Mathf.Min(totalVinegar, quantityItemRequest[itemsRequest.IndexOf("Vinegar")]);
                orderScript.DecreaseItemRequest("Vinegar", vinegarToGive);
                totalItemsInCart -= vinegarToGive;
            }

            if (itemsRequest.Contains("Joy") && totalJoy > 0)
            {
                int joyToGive = Mathf.Min(totalJoy, quantityItemRequest[itemsRequest.IndexOf("Joy")]);
                orderScript.DecreaseItemRequest("Joy", joyToGive);
                totalItemsInCart -= joyToGive;
            }

            if (itemsRequest.Contains("Surf") && totalSurf > 0)
            {
                int surfToGive = Mathf.Min(totalSurf, quantityItemRequest[itemsRequest.IndexOf("Surf")]);
                orderScript.DecreaseItemRequest("Surf", surfToGive);
                totalItemsInCart -= surfToGive;
            }

            if (itemsRequest.Contains("Payless Xtra Big") && totalPaylessXtraBig > 0)
            {
                int paylessXtraBigToGive = Mathf.Min(totalPaylessXtraBig, quantityItemRequest[itemsRequest.IndexOf("Payless Xtra Big")]);
                orderScript.DecreaseItemRequest("Payless Xtra Big", paylessXtraBigToGive);
                totalItemsInCart -= paylessXtraBigToGive;
            }

            if (itemsRequest.Contains("Lucky Me") && totalLuckyMe > 0)
            {
                int luckyMeToGive = Mathf.Min(totalLuckyMe, quantityItemRequest[itemsRequest.IndexOf("Lucky Me")]);
                orderScript.DecreaseItemRequest("Lucky Me", luckyMeToGive);
                totalItemsInCart -= luckyMeToGive;
            }

            if (itemsRequest.Contains("Cup Noodle") && totalCupNoodle > 0)
            {
                int cupNoodleToGive = Mathf.Min(totalCupNoodle, quantityItemRequest[itemsRequest.IndexOf("Cup Noodle")]);
                orderScript.DecreaseItemRequest("Cup Noodle", cupNoodleToGive);
                totalItemsInCart -= cupNoodleToGive;
            }

            if (itemsRequest.Contains("Colgate") && totalColgate > 0)
            {
                int colgateToGive = Mathf.Min(totalColgate, quantityItemRequest[itemsRequest.IndexOf("Colgate")]);
                orderScript.DecreaseItemRequest("Colgate", colgateToGive);
                totalItemsInCart -= colgateToGive;
            }

            if (itemsRequest.Contains("Rexona") && totalRexona > 0)
            {
                int rexonaToGive = Mathf.Min(totalRexona, quantityItemRequest[itemsRequest.IndexOf("Rexona")]);
                orderScript.DecreaseItemRequest("Rexona", rexonaToGive);
                totalItemsInCart -= rexonaToGive;
            }

            if (itemsRequest.Contains("Sunsilk") && totalSunsilk > 0)
            {
                int sunsilkToGive = Mathf.Min(totalSunsilk, quantityItemRequest[itemsRequest.IndexOf("Sunsilk")]);
                orderScript.DecreaseItemRequest("Sunsilk", sunsilkToGive);
                totalItemsInCart -= sunsilkToGive;
            }

            if (itemsRequest.Contains("Chippy") && totalChippy > 0)
            {
                int chippyToGive = Mathf.Min(totalChippy, quantityItemRequest[itemsRequest.IndexOf("Chippy")]);
                orderScript.DecreaseItemRequest("Chippy", chippyToGive);
                totalItemsInCart -= chippyToGive;
            }

            if (itemsRequest.Contains("Nova") && totalNova > 0)
            {
                int novaToGive = Mathf.Min(totalNova, quantityItemRequest[itemsRequest.IndexOf("Nova")]);
                orderScript.DecreaseItemRequest("Nova", novaToGive);
                totalItemsInCart -= novaToGive;
            }

            if (itemsRequest.Contains("Piattos") && totalPiattos > 0)
            {
                int piattosToGive = Mathf.Min(totalPiattos, quantityItemRequest[itemsRequest.IndexOf("Piattos")]);
                orderScript.DecreaseItemRequest("Piattos", piattosToGive);
                totalItemsInCart -= piattosToGive;
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
