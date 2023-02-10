using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclesList;
    private float time = 5;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GenerateEnemy(time));
    }

    IEnumerator GenerateEnemy(float timeWait)
    {
        float newY = Random.Range(-4, 4);
        Instantiate(obstaclesList[0], new Vector3(15, newY, 0), Quaternion.identity);
        yield return new WaitForSeconds(timeWait);
    }
}
