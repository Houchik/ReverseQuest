using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipeController : MonoBehaviour
{
    public float swipeSpeed = 5f; // Speed of camera movement
    public float swipeThreshold = 50f; // Minimum swipe distance to trigger camera movement
    public float minYLimit = 0.4f; // Minimum Y position limit for the camera

    private Vector2 startSwipePosition;
    private bool isSwipeInProgress = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startSwipePosition = touch.position;
                    isSwipeInProgress = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwipeInProgress)
                    {
                        float swipeDistance = touch.position.y - startSwipePosition.y;
                        float cameraMovement = Mathf.Clamp(swipeDistance / swipeThreshold, -1f, 1f) * swipeSpeed * Time.deltaTime;

                        // Calculate the new Y position of the camera
                        float newCameraY = transform.position.y + cameraMovement;
                        newCameraY = Mathf.Clamp(newCameraY, minYLimit, transform.position.y);

                        // Move the camera vertically to the new Y position
                        transform.position = new Vector3(transform.position.x, newCameraY, transform.position.z);
                    }
                    break;

                case TouchPhase.Ended:
                    isSwipeInProgress = false;
                    break;
            }
        }
    }
}
