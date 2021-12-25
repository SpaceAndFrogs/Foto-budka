using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionScript : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] float zoomSensitive;
    [SerializeField] float rotationSensitive;
    bool mouseDown = false;
    Vector2 lastPositionOfMouse;
    Transform objectToRotate;

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - zoomSensitive * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z + zoomSensitive * Time.deltaTime);
        }

        if(mouseDown)
        {
            float deltaX = Input.mousePosition.y - lastPositionOfMouse.y;
            float deltaY = Input.mousePosition.x - lastPositionOfMouse.x;
            Vector3 rotation = new Vector3(-deltaX * rotationSensitive * Time.deltaTime, -deltaY * rotationSensitive * Time.deltaTime, 0);

            objectToRotate.Rotate(rotation,Space.World);

            lastPositionOfMouse = Input.mousePosition;
        }
    }

    private void OnMouseDown()
    {
        mouseDown = true;
        lastPositionOfMouse = Input.mousePosition;
        objectToRotate = transform.GetChild(0);
    }

    private void OnMouseUp()
    {
        mouseDown = false;
    }
}
