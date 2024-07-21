using UnityEngine;
using System.Collections;

public class LanchRocket : MonoBehaviour
{
    float speed;

    IEnumerator LanchRocketLoop()
    {
        while (true)
        {
            //gameObject.transform.Translate(Vector3.up)* ime.deltaTime* speed;
            yield return new WaitForFixedUpdate();
        }
        

    }
}
