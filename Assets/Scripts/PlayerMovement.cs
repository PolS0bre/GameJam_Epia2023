using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private float playerVelocity = 6.5f;
    [SerializeField]
    private float jumpForce = 8f;
    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private AudioClip audioCrash;
    [SerializeField]
    private AudioSource AudioChanged;

    //Power ups bools
    public bool isInvencible = false;
    private SpriteRenderer InvencibleEffect;
    public bool ExtraLife = false;

    public GameObject OutOfRange;

    private Rigidbody2D rig;
    private float limitX = 8.1f;
    private GameObject gameManager;
    private PlayerManager pMan;

    private bool isMoving = false;
    private float horMoveAnim = 0;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager");
        pMan = gameManager.GetComponent<PlayerManager>();
        InvencibleEffect = GameObject.Find("InvencibleFX").GetComponent<SpriteRenderer>();
        AudioChanged = GameObject.Find("Bg Engine").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //moviment horitzontal
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            if (!isGrounded)
            {
                transform.position = transform.position + (playerVelocity * (Vector3.left * Time.deltaTime)/1.25f);
            }
            else
            {
                transform.position = transform.position + playerVelocity * (Vector3.left * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            if (!isGrounded)
            {
                transform.position = transform.position + (playerVelocity * (Vector3.right * Time.deltaTime)/ 1.25f);
            }
            else
            {
                transform.position = transform.position + playerVelocity * (Vector3.right * Time.deltaTime);
            }
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            horMoveAnim = 10f;
        }
        else
        {
            horMoveAnim = 0f;
        }

        animator.SetFloat("velocidad", Mathf.Abs(horMoveAnim));

        //Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            }
        }

        //Colision check
        if (transform.position.x <= -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, 0);
        }
        else if (transform.position.x >= limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, 0);
        }

        if(transform.position.y <= -5.8f)
        {
            if (ExtraLife == false)
            {
                AudioChanged.PlayOneShot(audioCrash);
                pMan.isDead = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 7, 0);
                ExtraLife = false;
            }
        }

        if(transform.position.y > 4.9f)
        {
            OutOfRange.GetComponent<SpriteRenderer>().enabled = true;
            OutOfRange.transform.position = new Vector3(transform.position.x, OutOfRange.transform.position.y, OutOfRange.transform.position.z);
        }
        else
        {
            OutOfRange.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (isInvencible)
        {
            InvencibleEffect.enabled = true;
        }
        else
        {
            InvencibleEffect.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor"){
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isInvencible == false)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (ExtraLife == false)
                {
                    AudioChanged.PlayOneShot(audioCrash);
                    pMan.isDead = true;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, 7, 0);
                    ExtraLife = false;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor"){
            isGrounded = false;
        }
    }
}
