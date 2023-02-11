using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiagonalEnemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.5f;

    private bool movingDown = false;
    private PlayerManager pmg;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            pmg = GameObject.Find("Game Manager").GetComponent<PlayerManager>();
        }
    }
    private void Update()
    {
        //Constant lateral move
        transform.position = transform.position + moveSpeed * (Vector3.left * Time.deltaTime);

        if(movingDown)
        {
            transform.position = transform.position + moveSpeed * (Vector3.down * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position + moveSpeed * (Vector3.up * Time.deltaTime);
        }

        if(transform.position.y < -4.2f)
        {
            movingDown = false;
        }
        else if(transform.position.y > 4.2f)
        {
            movingDown = true;
        }

        if (transform.position.x < -15)
        {
            Destroy(gameObject);

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
            {
                if (pmg.isDead == false)
                {
                    pmg.Points += 20;
                }
            }
        }
    }
}
