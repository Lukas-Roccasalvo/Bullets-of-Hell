using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject bullet;
    public SpawnerScript.Type type;
    public bool randomPosition;

    private float spawnTimeLeft = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (randomPosition)
        {
            transform.position = new Vector2(Random.Range(-50f, 50), Random.Range(-28f, 28));
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeLeft -= Time.deltaTime;
        if(spawnTimeLeft < 0)
        {
            spwawnBullet(type);
        }
    }

    void spwawnBullet(SpawnerScript.Type type)
    {
        GameObject newBullet = Instantiate(bullet, this.transform);
        Vector2 direction = new Vector2();
        switch (type)
        {
            case Type.random_radial:
                direction = new Vector2(Random.value * 10 - 5, Random.value * 10 - 5);
                spawnTimeLeft += 0.5f;
                break;
            case Type.random_left:
                direction = new Vector2(Random.Range(-10f, -5f), 0f);
                newBullet.GetComponent<SpriteRenderer>().color = new Color(0f, 200f, 0f);
                newBullet.GetComponent<TrailRenderer>().startColor = new Color(0f, 200f, 0f, 0.6f);
                newBullet.GetComponent<TrailRenderer>().endColor = new Color(0f, 200f, 0f, 0f);
                spawnTimeLeft += 2f;
                break;
            case Type.random_right:
                direction = new Vector2(Random.Range(10f, 5f), 0f);
                newBullet.GetComponent<SpriteRenderer>().color = new Color(0f, 200f, 0f);
                newBullet.GetComponent<TrailRenderer>().startColor = new Color(0f, 200f, 0f, 0.6f);
                newBullet.GetComponent<TrailRenderer>().endColor = new Color(0f, 200f, 0f, 0f);
                spawnTimeLeft += 2f;
                break;
            case Type.random_up:
                direction = new Vector2(0f, Random.Range(10f, 5f));
                newBullet.GetComponent<SpriteRenderer>().color = new Color(0f, 200f, 0f);
                newBullet.GetComponent<TrailRenderer>().startColor = new Color(0f, 200f, 0f, 0.6f);
                newBullet.GetComponent<TrailRenderer>().endColor = new Color(0f, 200f, 0f, 0f);
                spawnTimeLeft += 2f;
                break;
            case Type.random_down:
                direction = new Vector2(0f, Random.Range(-10f,-5f));
                newBullet.GetComponent<SpriteRenderer>().color = new Color(0f, 200f, 0f);
                newBullet.GetComponent<TrailRenderer>().startColor = new Color(0f, 200f, 0f, 0.6f);
                newBullet.GetComponent<TrailRenderer>().endColor = new Color(0f, 200f, 0f, 0f);
                spawnTimeLeft += 2f;
                break;
            default:
                break;
        }

        newBullet.GetComponent<Bullet_movement>().direction = direction;


    }

    public enum Type
    {
        random_radial,
        random_left,
        random_right,
        random_up,
        random_down
        
    }
}
