using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_linear_bullet_movement : MonoBehaviour
{
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.value * 10 - 5, Random.value * 10 - 5);


    }

    // Update is called once per frame
    void Update()
    {

        transform.position = (Vector2) transform.position + (direction * Time.deltaTime);
    }

   
}
