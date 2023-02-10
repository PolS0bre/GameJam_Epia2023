using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{ 
    private Rigidbody2D npcRb;
    public float circleRadius;
    public Transform Player;
    public float DistanceCheck;
    float distPlayer;
    public GameObject Enemy;
    public LayerMask groundLayer;
    public GameObject groundCheck;
    public bool isGrounded;
    private Animation animDeath;

    enum Estados
    {
        Idle,
        Run,
        Death,
        Deactivate
    }

    Estados estado_actual;
    
    // Start is called before the first frame update
    void Start()
    {
        npcRb = GetComponent<Rigidbody2D>();
        animDeath = gameObject.GetComponent<Animation>();

        estado_actual = Estados.Idle;
    }

    private void IdleNPC()
    {
        //Comprovar distancia per activar estat
        if ((distPlayer < DistanceCheck) && (isGrounded))
        {
            estado_actual = Estados.Run;
        }
    }

    private void RunNPC()
    {

        //Comprovar distancia per activar estat
        if ((distPlayer > DistanceCheck) || (!isGrounded))
        {
            estado_actual = Estados.Idle;
        }
        else if (transform.position.x < Player.position.x)
        {
            //Enemic a l'esquerra del jugador, orientar al enemic
            npcRb.velocity = new Vector2(-2.0f, 0.0f);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            //Enemic a la dreta del jugador, orientar al enemic
            npcRb.velocity = new Vector2(2.0f, 0.0f);
            transform.localScale = new Vector2(1, 1);
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
        //Despres de morir es desactiva
        Enemy.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //Distancia jugador
        distPlayer = Vector2.Distance(transform.position, Player.position);

        //Comprova si esta tocant el terra
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);


        //Metodo enum 
        if (estado_actual == Estados.Idle)
        {
            IdleNPC();
        }
        else if (estado_actual == Estados.Run)
        {
            RunNPC();
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
