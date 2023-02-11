using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclesList;
    public float time = 5;
    private PlayerManager pMan;

    private void Start()
    {
        pMan = GameObject.Find("Game Manager").GetComponent<PlayerManager>();
        StartCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy()
    {
        float newY = Random.Range(-4.4f, 4.4f);
        Instantiate(obstaclesList[0], new Vector3(15, newY, 0), Quaternion.identity);
        new WaitForSeconds(time);
        yield return new WaitForSeconds(time);

        if (time > 0.8f)
        {
            time -= 0.2f;
        }

        if(pMan.isDead == false)
        {
            StartCoroutine(GenerateEnemy());
        }
    }
}
