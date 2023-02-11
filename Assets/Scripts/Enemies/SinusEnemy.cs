using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinusEnemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;

    private float freq = 1f;
    private float amplitud = 2.5f;
    private float cycleSpd = 1f;

    private Vector3 positionEn;
    private Vector3 axis;

    private PlayerManager pmg;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            pmg = GameObject.Find("Game Manager").GetComponent<PlayerManager>();
        }
        positionEn = transform.position;
        axis = transform.up;
    }
    private void Update()
    {
        //Moviment lateral
        transform.position = transform.position + moveSpeed * (Vector3.right * Time.deltaTime);

        //Moviment vertical sinus
        positionEn += Vector3.left * Time.deltaTime * cycleSpd;
        transform.position = positionEn + axis * Mathf.Sin(Time.time * freq) * amplitud;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
            {
                if (pmg.isDead == false)
                {
                    pmg.Points += 30;
                }
            }
        }
    }
}
