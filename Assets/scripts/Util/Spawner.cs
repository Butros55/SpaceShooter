using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour

{
    public GameObject meteoridePrefab;
    public float timer;
    private float counter = 5;

    // Update is called once per frame
    void Update()
    {
        if (TimerFinished())
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-29, 29), 18, 0);
            Instantiate(meteoridePrefab, spawnPosition, meteoridePrefab.transform.rotation);
        }
    }

    bool TimerFinished()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            counter = timer;
            return true;
        }
        
        return false;
    }
}
