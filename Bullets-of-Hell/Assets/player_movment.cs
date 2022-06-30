using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public InputAction playerControls;
    public Transform youDied;

    private int score = 0;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Singelton.getInstance().running = true;
    }

    // Update is called once per frame
    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");
        //moveDirection = new Vector2(moveX, moveY).normalized;
        moveDirection = playerControls.ReadValue<Vector2>();
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Singelton.getInstance().score = 0;
            Singelton.getInstance().running = false;
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Singelton.getInstance().running)
        {
            return;
        }
            if (collision.transform.tag == "Bullet")
        {
            youDied.gameObject.SetActive(true);
            Singelton.getInstance().running = false;
            GetComponent<AudioSource>().Play();
            moveSpeed /= 2f;
            //youDied.GetComponent<SpriteRenderer>().enabled = true;

        }
        else if (collision.transform.tag == "Checkpont")
        {

                Singelton.getInstance().score++;
                GameObject checkpoint = Instantiate(collision.gameObject);
                checkpoint.transform.position = new Vector2(Random.Range(-50f, 50), Random.Range(-28f, 28));
                Destroy(collision.gameObject);

            

        }
    }

}
