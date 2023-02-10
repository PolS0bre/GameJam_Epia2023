using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM2 : MonoBehaviour
{
    private Rigidbody2D npcRb;
    public float circleRadius;
    public float Speed;
    public LayerMask groundLayer;
    public GameObject groundCheck;
    public GameObject Enemy;
    public bool facingRight;
    public bool isGrounded;
    private Animation animDeath;

    enum Estados
    {
        Movement,
        Death,
        Deactivate
    }

    Estados estado_actual;

    
    // Start is called before the first frame update
    void Start()
    {
        npcRb = GetComponent<Rigidbody2D>();
        animDeath = gameObject.GetComponent<Animation>();

        estado_actual = Estados.Movement;
    }
    
    private void MoveNPC()
    {
        //Afegir velocitat al enemic
        npcRb.velocity = Vector2.right * Speed * Time.deltaTime;
                
        //Condició per girar si no toca el terra
        if ((!isGrounded && facingRight) || (!isGrounded && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
            Speed = -Speed;
        }

        if (gameObject.tag == "Player")
        {
            estado_actual = Estados.Death;
        }
    }

    private void DeathNPC()
    {
        animDeath.Play("death");
        estado_actual = Estados.Deactivate;
    }

    private void DeactivateNPC()
    {
        Enemy.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //Comprova si toca el terra
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);

        //Metodo enum 
        if (estado_actual == Estados.Movement)
        {
            MoveNPC();
        }
        else if (estado_actual == Estados.Death)
        {
            DeathNPC();
        }
        else if (estado_actual == Estados.Deactivate)
        {
            DeactivateNPC();
        }
    }



}
