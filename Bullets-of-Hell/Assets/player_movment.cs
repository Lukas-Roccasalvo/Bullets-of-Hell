using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float dashDistance = 10f;
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
            Singelton.getInstance().health = 3;
            Singelton.getInstance().score = 0;
            Singelton.getInstance().running = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            moveSpeed /= 2;
        }
        if (Keyboard.current.shiftKey.wasReleasedThisFrame)
        {
            moveSpeed *= 2;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            
                transform.position = new Vector2(transform.position.x, transform.position.y + dashDistance);
           



        }
    }

    private void FixedUpdate()
    {
        
        if(Singelton.getInstance().running)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Singelton.getInstance().running)
        {
            return;
        }
        if (collision.transform.tag == "Bullet")
        {
            Singelton.getInstance().health--;
            Destroy(collision.gameObject);
            switch (Singelton.getInstance().health)
            {
                case 2:
                    GetComponent<SpriteRenderer>().color = new Color(0f, 185f, 255f);
                    GetComponent<TrailRenderer>().startColor = new Color(0f, 185f, 255f);
                    GetComponent<TrailRenderer>().endColor = new Color(0f, 185f, 255f);
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().color = new Color(182f, 235f, 255f);
                    GetComponent<TrailRenderer>().startColor = new Color(182f, 235f, 255f);
                    GetComponent<TrailRenderer>().endColor = new Color(182f, 235f, 255f);
                    break;
                default:
                    break;
            }
            if (Singelton.getInstance().health <= 0)
            {
                youDied.gameObject.SetActive(true);
                Singelton.getInstance().running = false;
                GetComponent<AudioSource>().Play();
                //youDied.GetComponent<SpriteRenderer>().enabled = true;
            }

        }
        else if (collision.transform.tag == "Checkpont")
        {

                Singelton.getInstance().score++;
                GameObject checkpoint = Instantiate(collision.gameObject);
                checkpoint.transform.position = new Vector2(Random.Range(-50f, 50), Random.Range(-28f, 28));
                Destroy(collision.gameObject, 2f);
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<AudioSource>().Play();

            

        }
    }
    

}
