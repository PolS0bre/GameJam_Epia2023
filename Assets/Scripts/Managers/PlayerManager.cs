using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool isDead = false;

    [SerializeField]
    private GameObject DeadMenu;

    [SerializeField]
    private Text ScoreTextGame;
    [SerializeField]
    private Text ScoreTextDead;
    [SerializeField]
    private AudioSource CrashAudio;



    public int Points;

    private void Start()
    {
        DeadMenu = GameObject.Find("DeadMenu");
        ScoreTextDead = GameObject.Find("Score").GetComponent<Text>();
        DeadMenu.SetActive(false);
        ScoreTextGame = GameObject.Find("ActualScore").GetComponent<Text>();
        CrashAudio = GameObject.Find("Crash").GetComponent<AudioSource>();
        Debug.Log(CrashAudio.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            DeadMenu.SetActive(true);
            CrashAudio.Play(0);
            Destroy(GameObject.Find("Bg Engine"));
            GameObject.Find("Bg Music").GetComponent<AudioSource>().pitch = 0.65f;
            Cursor.lockState = CursorLockMode.Confined;
            ScoreTextDead.text = "SCORE: " + Points;
        }
        else
        {
            ScoreTextGame.text = "SCORE: " + Points;
        }
    }
}