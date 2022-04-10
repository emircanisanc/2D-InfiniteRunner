using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject;

    private float deltaX;
    void Start()
    {
        deltaX = (transform.position.x - targetObject.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetObject.position.x + deltaX, transform.position.y, transform.position.z);
    }
}
