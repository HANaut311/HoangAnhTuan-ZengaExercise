using UnityEngine;

public class CameraRotation: MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    private Vector3 initialMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float deltaX = initialMousePosition.x - currentMousePosition.x ;
            // Sử dụng Vector3.SignedAngle để tính góc quay
            float rotationY = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);
            rotationY += deltaX * rotationSpeed;

            // Giới hạn góc quay để tránh quay quá 45 độ lên hoặc xuống
            rotationY = Mathf.Clamp(rotationY, -45f, 45f);

            transform.rotation = Quaternion.Euler(0, rotationY, 0);

            initialMousePosition = currentMousePosition;
        }
    }
}
