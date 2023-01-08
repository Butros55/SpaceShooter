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
            Vector2 spawnPosition = new Vector2(Random.Range(-8.5f, 8.5f), 6);
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
