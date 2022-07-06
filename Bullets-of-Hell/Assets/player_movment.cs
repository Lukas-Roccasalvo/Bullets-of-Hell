using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float dashDistance;
    public float dashCooldown;
    private float waitdash = 0f;
    public float blastRadius;
    public float blastCooldown;
    private float waitblast = 0f;
    public InputAction playerControls;
    public Transform youDied;
    public GameObject spawners;
    public ParticleSystem particlesblast;
    public ParticleSystem particlesready;
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
        GetComponent<TrailRenderer>().emitting = false;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {

            if (waitdash < Time.time)
            {
                waitdash = Time.time + dashCooldown;


                GetComponent<TrailRenderer>().emitting = true;

                if (Keyboard.current.wKey.isPressed)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + dashDistance);
                }
                if (Keyboard.current.sKey.isPressed)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - dashDistance);
                }
                if (Keyboard.current.aKey.isPressed)
                {
                    transform.position = new Vector2(transform.position.x - dashDistance, transform.position.y);
                }
                if (Keyboard.current.dKey.isPressed)
                {
                    transform.position = new Vector2(transform.position.x + dashDistance, transform.position.y);
                }

            }
        }
        particlesready.Play();
        if (Keyboard.current.altKey.wasPressedThisFrame)
        {

            if (waitblast < Time.time)
            {
                particlesready.Stop();
                waitblast = Time.time + blastCooldown;
                particlesblast.Play();
                foreach (Transform spawner in spawners.transform)
                {
                    foreach (Transform bullet in spawner.transform)
                    {
                        if (Vector2.Distance(transform.position, bullet.transform.position) < blastRadius)
                        {
                            Destroy(bullet.gameObject);
                        }

                    }
                }
            }

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
