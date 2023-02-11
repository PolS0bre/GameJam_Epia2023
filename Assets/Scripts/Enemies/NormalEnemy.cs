using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.5f;

    private PlayerManager pmg;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            pmg = GameObject.Find("Game Manager").GetComponent<PlayerManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (moveSpeed * (Vector3.left * Time.deltaTime) / 1.25f);

        if(transform.position.x < -10)
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
