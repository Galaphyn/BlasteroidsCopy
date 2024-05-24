using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] meteors;
    public float spawnMinX;
    public float spawnMaxX;
    public float spawnY;

    public float interval = 2f;
  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteors", 0f, interval);
    }
    void SpawnMeteors()
    {
        int index = Random.Range(0, meteors.Length);
        Vector2 spawnRange = new Vector2(Random.Range(spawnMinX, spawnMaxX), spawnY);

        Instantiate(meteors[index], spawnRange, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
