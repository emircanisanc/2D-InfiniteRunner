using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform[] SpawnableCactuses;

    void Start()
    {
        if(SpawnableCactuses.Length > 0)
        {
            int randomIndex = Random.Range(0,SpawnableCactuses.Length-1);
            GetComponentInChildren<TriggerPlayer>().worldObject = SpawnableCactuses[randomIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerManager playerManager = other.GetComponent<PlayerManager>();
        if(playerManager != null)
        {
            playerManager.applyDamage();
        }
    }
}
