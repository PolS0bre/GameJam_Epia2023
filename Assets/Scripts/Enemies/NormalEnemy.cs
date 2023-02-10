using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    private float moveSpeed = 3.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (moveSpeed * (Vector3.left * Time.deltaTime) / 1.25f);

        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
