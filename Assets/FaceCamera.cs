using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Transform mainCamera;
    Transform localTransform;
    [SerializeField] float scaleMultiplier = 1.0f;
    [SerializeField] float heightMultiplier = 1.0f;
    [SerializeField] bool updateHight;

    void Start()
    {
        mainCamera = FindAnyObjectByType<Camera>().transform;
        localTransform = GetComponent<Transform>();
    }

   


    void Update()
    {
        if (mainCamera != null)
        {
            localTransform.LookAt(2 * localTransform.position - mainCamera.position);

            float distance = Vector3.Distance(mainCamera.transform.position, transform.position);

            float scale = distance * scaleMultiplier;

            transform.localScale = new Vector3(scale, scale, scale);

            if (updateHight)
            {
                float height = distance * heightMultiplier;

                transform.position = new Vector3(transform.position.x, height, transform.position.z);
            }

            
        }
    }
}
