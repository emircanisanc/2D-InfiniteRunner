using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    public Transform worldObject;

    [SerializeField]
    private Vector3 distanceBetweenObjects;

    [SerializeField]
    private Transform parentObjectTransform;
    public GameObject ownSpawner;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
              
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Transform spawnedObject = Instantiate(worldObject, distanceBetweenObjects + parentObjectTransform.position, worldObject.transform.rotation);
            spawnedObject.GetComponentInChildren<TriggerPlayer>().ownSpawner = parentObjectTransform.gameObject;
            if(ownSpawner != null)
            {
                Destroy(ownSpawner);
            }
        }
    }
}
