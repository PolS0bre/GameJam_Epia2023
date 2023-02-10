using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Rigidbody2D rig;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + Speed * (Vector3.left * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + Speed * (Vector3.right * Time.deltaTime);
        }
        
        //----------
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0.0f, 3.0f), ForceMode2D.Impulse);
        }
    }
}
