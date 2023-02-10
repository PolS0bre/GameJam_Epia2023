using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerVelocity;
    private Rigidbody2D rig;
    private float jumpForce = 10f;
    private float limitX = 8.1f;
    private float limitY = 4.25f;
    private bool isGrounded;
    public LayerMask GroundLayer;
    //public GameManager gm;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //moviment horitzontal
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        if (Input.GetKey(KeyCode.A))
        {
            if (!isGrounded)
            {
                transform.position = transform.position + (playerVelocity * (Vector3.left * Time.deltaTime)/1.25f);
            }
            else
            {
                transform.position = transform.position + playerVelocity * (Vector3.left * Time.deltaTime);
            }
        }
        //else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        else if (Input.GetKey(KeyCode.D))
        {
            if (!isGrounded)
            {
                transform.position = transform.position + (playerVelocity * (Vector3.right * Time.deltaTime)/ 1.25f);
            }
            else
            {
                transform.position = transform.position + playerVelocity * (Vector3.right * Time.deltaTime);
            }
        }


        //Pausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //Pausar
        }

        //Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            }
        }

        //Saltar cap a baix
        if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            //Baixar plataforma
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
        if (transform.position.y <= -limitY)
        {
            transform.position = new Vector3(transform.position.x, -limitY, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor"){
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor"){
            isGrounded = false;
        }
    }
}
