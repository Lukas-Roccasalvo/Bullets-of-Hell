using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_movement : MonoBehaviour
{
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = (Vector2) transform.position + (direction * Time.deltaTime);
        if(transform.position.x > 100f || transform.position.x < -100f ||
            transform.position.y > 50f || transform.position.y < -50f)
        {
            Destroy(gameObject);
        }
        
    }


}
