using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject bullet;
    public SpawnerScript.Type type;
    private float spawnIntervall = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnIntervall -= Time.deltaTime;
        if(spawnIntervall < 0)
        {
            spawnIntervall += 0.5f;
            spwawnBullet(type);
        }
    }

    void spwawnBullet(SpawnerScript.Type type)
    {
        Instantiate(bullet, this.transform);
    }

    public enum Type
    {
        random_radial,
        
    }
}
