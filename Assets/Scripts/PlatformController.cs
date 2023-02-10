using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlatformController : MonoBehaviour
{
    private float SpeedMove = 5.5f;
    private float limitX = 5.5f;
    private float limitY = 4.3f;
    //private bool mouseSensor = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {/*
        if (mouseSensor)
        {*/
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");
            Vector3 movement = new Vector3(h, v, 0);
            //transform.Translate(h, v, 0);
            //Movement hrizontal
            transform.position = transform.position + SpeedMove * (movement * Time.deltaTime);

            //Check limits
            if (transform.position.x <= -limitX)
            {
                transform.position = new Vector3(-limitX, transform.position.y, 0);
            }
            else if (transform.position.x >= limitX)
            {
                transform.position = new Vector3(limitX, transform.position.y, 0);
            }
            if(transform.position.y <= -limitY)
            {
                transform.position = new Vector3(transform.position.x, -limitY, 0);
            }
            else if (transform.position.y >= limitY)
            {
                transform.position = new Vector3(transform.position.x, limitY, 0);
                //Has perdut
            }
            /*
        }
        else
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = transform.position + SpeedMove * (Vector3.left * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = transform.position + SpeedMove * (Vector3.right * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = transform.position + SpeedMove * (Vector3.up * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = transform.position + SpeedMove * (Vector3.down * Time.deltaTime);
            }
        }*/
    }
}
