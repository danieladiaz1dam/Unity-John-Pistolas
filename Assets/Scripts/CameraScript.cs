using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform john;

    void Update()
    {
        if (john != null)
        {
            Vector3 position = transform.position;
            position.x = john.position.x;
            position.y = john.position.y + 0.3f;
            transform.position = position;
        }
    }
}