using NUnit.Framework.Constraints;
using System;
using TMPro;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2d;
    Transform prevHoverObject, nextHoverObject;
    private Vector3 cameraTargetPos, hitboxesTargetPos;
    public GameObject camera, hitboxes, rightHitbox;
    
    public float speedCam = 0f;
    private bool hasMoved = false;
    public float tolerance = 0.01f;

    public int currentPos;

    private void Start()
    {
        if (currentPos == 1)
        {
            camera.transform.position = new Vector3(0, camera.transform.position.y, camera.transform.position.z);
        }
    }

    void Update()
    {
        mousePosition = Input.mousePosition;

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2d = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        nextHoverObject = raycastHit2d ? raycastHit2d.collider.transform : null;

        Debug.Log($"Current Position: {currentPos}");
        Debug.Log($"Hover Object: {nextHoverObject}");

        // Move the Camera to the Right
        if (currentPos == 1)
        {
            if (nextHoverObject != null && nextHoverObject.name == "RightObject")
            {
                hasMoved = true;
            }

            if (hasMoved)
            {
                rightHitbox.SetActive(false);
                Debug.Log("Right Hitbox has been turn off");

                cameraTargetPos = new Vector3(8.64f, camera.transform.position.y, camera.transform.position.z);
                hitboxesTargetPos = new Vector3(13.41454f, hitboxes.transform.position.y, hitboxes.transform.position.z);

                Debug.Log("Right Hitbox has been turn off");
                
                camera.transform.position =
                    Vector3.MoveTowards(
                        camera.transform.position,
                        cameraTargetPos,
                        speedCam * Time.deltaTime
                    );
                hitboxes.transform.position =
                    Vector3.MoveTowards(
                        hitboxes.transform.position,
                        hitboxesTargetPos,
                        speedCam * Time.deltaTime
                    );

                if (IsElementsAtTarget())
                {
                    Debug.Log("Camera and Hitboxes has reached the target right pane position.");

                    currentPos = 2;
                    Debug.Log($"Current Position at {currentPos}");

                    hasMoved = false;
                }
            }
        }
        // After Disabling the Right Hover, Move the Camera to the Left
        else if (currentPos == 2)
        {
            if (nextHoverObject != null && nextHoverObject.name == "LeftObject")
            {
                hasMoved = true;

                rightHitbox.SetActive(true);
                Debug.Log("Right Hitbox has been turn on");
            }

            if (hasMoved)
            {
                cameraTargetPos = new Vector3(0f, camera.transform.position.y, camera.transform.position.z);
                hitboxesTargetPos = new Vector3(4.77454f, hitboxes.transform.position.y, hitboxes.transform.position.z);

                hitboxes.transform.position =
                    Vector3.MoveTowards(
                        hitboxes.transform.position,
                        hitboxesTargetPos,
                        speedCam * Time.deltaTime
                    );
                camera.transform.position =
                    Vector3.MoveTowards(
                        camera.transform.position,
                        cameraTargetPos,
                        speedCam * Time.deltaTime
                    );

                if (IsElementsAtTarget())
                {
                    Debug.Log("Camera and Hitboxes has reached the original position.");

                    currentPos = 1;
                    Debug.Log($"Current Position at {currentPos}");

                    hasMoved = false;
                }
            }
        }
    }


    bool IsElementsAtTarget()
    {
        return Vector3.Distance(camera.transform.position, cameraTargetPos) < tolerance &&
            Vector3.Distance(hitboxes.transform.position, hitboxesTargetPos) < tolerance;
    }

    bool IsRightObjectActive()
    {

        return false;
    }

}
