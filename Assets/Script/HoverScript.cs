using NUnit.Framework.Constraints;
using System;
using TMPro;
using UnityEditor.Toolbars;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2d;
    Transform prevHoverObject, nextHoverObject;
    private Vector3 cameraTargetPos;

    public GameObject mainCamera, hitboxes, 
        rightHitbox, leftHitbox;

    public GameObject middlePaneRemainItemsText, leftPanelRemainItemsText, rightPanelRemainItemsText;
    public GameObject itemRequestText;

    public float speedCam = 11;
    private float speedCamToLeft = 17;
    private bool hasMoved = false;
    public float tolerance = 0.01f;

    public int currentPos = 1;
    public int toPosition = 1;

    private void Start()
    {
        if (currentPos == 1)
        {
            mainCamera.transform.position = new Vector3(0, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }

    void Update()
    {
        mousePosition = Input.mousePosition;

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2d = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        nextHoverObject = raycastHit2d ? raycastHit2d.collider.transform : null;

        // Move the Camera to the Right
        if (currentPos == 1)
        {
            if (!hasMoved && nextHoverObject != null && nextHoverObject.name == "RightObject")
            {
                hasMoved = true;
                toPosition = 2;

                DisableHoverObjects();
            }
            else if (!hasMoved && nextHoverObject != null && nextHoverObject.name == "LeftObject")
            {
                hasMoved = true;
                toPosition = 0;

                DisableHoverObjects();
            }

            if (hasMoved && toPosition == 2)
            {
                cameraTargetPos = new Vector3(8.64f, mainCamera.transform.position.y, mainCamera.transform.position.z);

                mainCamera.transform.position =
                    Vector3.MoveTowards(
                        mainCamera.transform.position,
                        cameraTargetPos,
                        speedCam * Time.deltaTime
                    );

                middlePaneRemainItemsText.SetActive(false);
                leftPanelRemainItemsText.SetActive(false);
                rightPanelRemainItemsText.SetActive(true);
                itemRequestText.SetActive(false);

                if (isCameraAtClosePosition())
                {
                    mainCamera.transform.position = cameraTargetPos;
                    leftHitbox.SetActive(true);
                    currentPos = 2;
                    hasMoved = false;
                }
            }
            else if (hasMoved && toPosition == 0)
            {
                cameraTargetPos = new Vector3(-17.64f, mainCamera.transform.position.y, mainCamera.transform.position.z);

                mainCamera.transform.position =
                    Vector3.MoveTowards(
                        mainCamera.transform.position,
                        cameraTargetPos,
                        speedCamToLeft * Time.deltaTime
                    );

                middlePaneRemainItemsText.SetActive(false);
                leftPanelRemainItemsText.SetActive(true);
                rightPanelRemainItemsText.SetActive(false);
                itemRequestText.SetActive(false);

                if (isCameraAtClosePosition())
                {
                    mainCamera.transform.position = cameraTargetPos;
                    rightHitbox.SetActive(true);
                    currentPos = 0;
                    hasMoved = false;
                }
            }
        }
        else if (currentPos == 0)
        {
            if (!hasMoved && nextHoverObject != null && nextHoverObject.name == "RightObject")
            {
                hasMoved = true;
                toPosition = 1;

                DisableHoverObjects();
            }

            if (hasMoved && toPosition == 1)
            {
                cameraTargetPos = new Vector3(0f, mainCamera.transform.position.y, mainCamera.transform.position.z);

                mainCamera.transform.position =
                    Vector3.MoveTowards(
                        mainCamera.transform.position,
                        cameraTargetPos,
                        speedCamToLeft * Time.deltaTime
                    );

                middlePaneRemainItemsText.SetActive(true);
                leftPanelRemainItemsText.SetActive(false);
                rightPanelRemainItemsText.SetActive(false);
                itemRequestText.SetActive(true);

                if (isCameraAtClosePosition())
                {
                    mainCamera.transform.position = cameraTargetPos;
                    EnableHoverObjects();
                    currentPos = 1;
                    hasMoved = false;
                }
            }
        }
        else if (currentPos == 2)
        {
            if (!hasMoved && nextHoverObject != null && nextHoverObject.name == "LeftObject")
            {
                hasMoved = true;
                toPosition = 1;

                DisableHoverObjects();
            }

            if (hasMoved && toPosition == 1)
            {
                cameraTargetPos = new Vector3(0f, mainCamera.transform.position.y, mainCamera.transform.position.z);

                mainCamera.transform.position =
                    Vector3.MoveTowards(
                        mainCamera.transform.position,
                        cameraTargetPos,
                        speedCam * Time.deltaTime
                    );

                middlePaneRemainItemsText.SetActive(true);
                leftPanelRemainItemsText.SetActive(false);
                rightPanelRemainItemsText.SetActive(false);
                itemRequestText.SetActive(true);

                if (isCameraAtClosePosition())
                {
                    mainCamera.transform.position = cameraTargetPos;
                    EnableHoverObjects();
                    currentPos = 1;
                    hasMoved = false;
                }
            }
        }
    }

    private void DisableHoverObjects()
    {
        leftHitbox.SetActive(false);
        rightHitbox.SetActive(false);
    }

    private void EnableHoverObjects()
    {
        leftHitbox.SetActive(true);
        rightHitbox.SetActive(true);
    }

    bool isCameraAtClosePosition()
    { return Vector3.Distance(mainCamera.transform.position, cameraTargetPos) < tolerance; }

    bool isCameraAtExactPosition()
    { return mainCamera.transform.position == cameraTargetPos; }
}
