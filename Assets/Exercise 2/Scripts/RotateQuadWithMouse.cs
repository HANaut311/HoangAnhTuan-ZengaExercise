using UnityEngine;

public class RotateQuadWithMouse : MonoBehaviour
{
    private Camera mainCamera;
    private bool isRotating = false;
    private Vector3 lastMousePosition;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseDown();
        }

        if (isRotating && Input.GetMouseButton(0))
        {
            HandleMouseDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            HandleMouseUp();
        }
    }

    private void HandleMouseDown()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }
    }

    private void HandleMouseDrag()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 currentMouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(currentMousePosition.x, currentMousePosition.y, transform.position.z - mainCamera.transform.position.z));
        Vector3 lastMouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(lastMousePosition.x, lastMousePosition.y, transform.position.z - mainCamera.transform.position.z));

        Vector3 directionToMouse = currentMouseWorldPosition - transform.position;
        Vector3 lastDirectionToMouse = lastMouseWorldPosition - transform.position;

        float angle = Vector3.SignedAngle(lastDirectionToMouse, directionToMouse, Vector3.forward);

        transform.Rotate(Vector3.forward, angle);

        lastMousePosition = currentMousePosition;
    }

    private void HandleMouseUp()
    {
        isRotating = false;
    }
}
