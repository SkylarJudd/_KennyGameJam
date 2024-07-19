using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Sensitivity settings
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float zoomSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Handle panning with the middle mouse button
        if (Input.GetMouseButton(2))
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            Vector3 movement = new Vector3(-h, -v, 0);
            transform.Translate(movement * panSpeed * Time.deltaTime, Space.World);
        }

        // Handle WASD movement
        float horizontal = Input.GetAxis("Horizontal"); // A, D
        float vertical = Input.GetAxis("Vertical");     // W, S
        Vector3 move = new Vector3(horizontal, 0, vertical);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Handle zooming with the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 zoom = transform.forward * scroll * zoomSpeed;
        transform.Translate(zoom, Space.World);
    }
}