using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM3 : MonoBehaviour
{
    public float Speed;
    public Transform player;
    public GameObject Enemy;
    public float lineSite;
    float distancePlayer;
    private Animation animDeath;

    enum Estados
    {
        Idle,
        Follow,
        Death,
        Deactivate
    }

    Estados estado_actual;


        // Start is called before the first frame update
    void Start()
    {
        animDeath = gameObject.GetComponent<Animation>();

        estado_actual = Estados.Idle;
    }

    private void IdleNPC()
    {
        //Comprovar distancia entre jugador i enemic
        if (distancePlayer < lineSite)
        {
            estado_actual = Estados.Follow;
        }
    }

    private void FollowNPC()
    {
        //Comprovar distancia entre jugador i enemic
        if (distancePlayer > lineSite)
        {
            estado_actual = Estados.Idle;
        }

        //Seguir al jugador
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);

        if (transform.position.x < player.position.x)
        {
            //Enemic a l'esquerra del jugador, orientar al enemic 
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            //Enemic a la dreta del jugador, orientar al enemic
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

        if (!animDeath.IsPlaying("death"))
        {


            estado_actual = Estados.Deactivate;
        }
    }

    private void DeactivateNPC()
    {
        Enemy.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        distancePlayer = Vector2.Distance(player.position, transform.position);
        
        //Metodo enum 
        if (estado_actual == Estados.Idle)
        {
            IdleNPC();
        }
        else if (estado_actual == Estados.Follow)
        {
            FollowNPC();
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
