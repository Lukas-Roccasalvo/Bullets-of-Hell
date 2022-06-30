using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_bullet : MonoBehaviour
{

    public GameObject player;

    private Vector2 direction = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2) transform.position + direction;
    }

}
