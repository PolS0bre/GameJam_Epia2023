using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclesList;

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
        float isPowerUp = Random.Range(0, 100);
        int index;
        //Percentage of power ups vs enemies
        if (isPowerUp > 80)
        {
            index = Random.Range(3, 6);
        }
        else
        {
            index = Random.Range(0, 3);
        }
        //Generate enemy/power
        Instantiate(obstaclesList[index], new Vector3(15, newY, 0), Quaternion.identity);
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
