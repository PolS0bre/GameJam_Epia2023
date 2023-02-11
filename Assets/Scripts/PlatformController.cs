using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private float SpeedMove = 6.5f;

    private float limitX = 7.45f;
    private float limitY = 4.3f;
    //private bool mouseSensor = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");
            Vector3 movement = new Vector3(h, v, 0);
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
            else if (transform.position.y >= 2.77f)
            {
                transform.position = new Vector3(transform.position.x, 2.77f, 0);
            }
            
    }
}
