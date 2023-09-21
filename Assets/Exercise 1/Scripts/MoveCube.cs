using UnityEngine;
using DG.Tweening;

public class MoveCube : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Transform quadTransform;

    void Start()
    {
        quadTransform = GameObject.Find("Quad").transform; 
    }

    void Update()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }

        if (isDragging)
        {
            UpdateCubePosition();
        }
    }

    void StartDragging()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            offset = transform.position - hit.point;
            isDragging = true;
        }
    }

    void StopDragging()
    {
        isDragging = false;
    }

    void UpdateCubePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == quadTransform.gameObject)
        {
            Vector3 targetPosition = hit.point + offset;

            // Sử dụng DOTween để di chuyển cube mượt mà đến vị trí chuột
            MoveCubeSmoothly(targetPosition);
        }
    }

    void MoveCubeSmoothly(Vector3 targetPosition)
    {
        transform.DOMove(new Vector3(targetPosition.x, transform.position.y, targetPosition.z), 0.1f);
    }
}
