using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool isDead = false;
    private GameObject DeadMenu;

    private void Start()
    {
        DeadMenu = GameObject.Find("DeadMenu");
        DeadMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            DeadMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}