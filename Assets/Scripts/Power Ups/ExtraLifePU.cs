using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePU : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pm;

    private float PowerUpSpeed = 7.5f;

    private void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        transform.position = transform.position + (PowerUpSpeed * (Vector3.left * Time.deltaTime) / 1.25f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pm.ExtraLife = true;
            Destroy(this.gameObject);
        }
    }
}
