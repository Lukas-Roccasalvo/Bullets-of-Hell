using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_bullet : MonoBehaviour
{

    Transform player;

    public float homingStrenght;
    public float homingRange;
    public float speed;
    private Vector2 direction = Vector2.up;

    private TrailRenderer tr;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 toPlayer = player.position - transform.position;
        if (toPlayer.magnitude < homingRange)
        {
            tr.emitting = true;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(direction, toPlayer), homingStrenght);
        }
        else
        {
            tr.emitting = false;
        }
        transform.position += transform.up * speed * Time.deltaTime;
    }

}
