using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
    public float zoomSpeed = 2f;
    public float minZoomFOV = 10f;
    public float maxZoomFOV = 100f;

    public float moveSpeed = 0.005f;

    private Camera mainCamera;
    private Vector3 defaultPos;
    private Quaternion defaultRot;
    private float defaultFOV;

    private Vector3 currentPosition = new Vector3();
    private Vector3 newPosition = new Vector3();

    private Vector3 currentRotation = new Vector3();
    private Vector3 newRotation = new Vector3();

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        defaultPos = mainCamera.transform.position;
        defaultRot = mainCamera.transform.rotation;
        defaultFOV = mainCamera.fieldOfView;
    }

    void LateUpdate () 
    {
        getCurrentPosition();
        updateCameraPos();

        getCurrentRotation();
        updateCameraRotation();

        zoomIn();
        zoomOut();

        resetCamera();
	}

    private void getCurrentPosition()
    {
        if (Input.GetMouseButtonDown(2))
        {
            currentPosition.x = Input.mousePosition.x;
            currentPosition.z = Input.mousePosition.y;
        }
    }

    private void updateCameraPos()
    {
        if (Input.GetMouseButton(2))
        {
            newPosition.x = Input.mousePosition.x;
            newPosition.z = Input.mousePosition.y;
            if (newPosition != currentPosition)
            {
                transform.position = transform.position + mainCamera.orthographicSize * 0.006f * (currentPosition - newPosition);
                currentPosition = newPosition;
            }
        }
    }

    private void getCurrentRotation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentRotation.x = Input.mousePosition.y;
            currentRotation.y = Input.mousePosition.x;
        }
    }

    private void updateCameraRotation()
    {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftAlt))
        {
            newRotation.x = Input.mousePosition.y;
            newRotation.y = Input.mousePosition.x;
            
            if (newRotation != currentRotation)
            {
                transform.Rotate((currentRotation - newRotation) / 10, Space.World);
                currentRotation = newRotation;
            }
        }
    }

    private void zoomIn()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mainCamera.fieldOfView -= zoomSpeed;
            if (mainCamera.fieldOfView < minZoomFOV)
                mainCamera.fieldOfView = minZoomFOV;
        }
    }

    private void zoomOut()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mainCamera.fieldOfView += zoomSpeed;
            if (mainCamera.fieldOfView > maxZoomFOV)
                mainCamera.fieldOfView = maxZoomFOV;
        }
    }

    private void resetCamera()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.R))
        {
            mainCamera.transform.position = defaultPos;
            mainCamera.transform.rotation = defaultRot;
            mainCamera.fieldOfView = defaultFOV;
        }
    }
}
