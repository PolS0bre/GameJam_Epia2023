using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAllPU : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playMan;
    [SerializeField]
    private GameObject[] Enemies;

    private float PowerUpSpeed = 7.5f;

    private void Start()
    {
        playMan = GameObject.Find("Game Manager").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        transform.position = transform.position + (PowerUpSpeed * (Vector3.left * Time.deltaTime) / 1.25f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //Play Particles
            for (int i = 0; i < Enemies.Length; i++)
            {
                Destroy(Enemies[i]);
            }
            System.Array.Resize(ref Enemies, 0);
            playMan.Points += 200;
            Destroy(this.gameObject);
        }
    }
}
