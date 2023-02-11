using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclesList;

    private GameObject dropdown;
    private Dropdown dropComponent;

    List<int> widths = new List<int>() { 1920, 1680, 1366, 1280 };
    List<int> heights = new List<int>() { 1080, 1050, 768, 800 };
    private void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            if (PlayerPrefs.HasKey("resIndex"))
            {
                int IndexRes = PlayerPrefs.GetInt("resIndex");
                int width = widths[IndexRes];
                int height = heights[IndexRes];
                Screen.SetResolution(width, height, Screen.fullScreen);
            }
            else
            {
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
            }
            StartCoroutine(GenerateEnemy());
        }
        if(dropdown != null)
        {
            dropComponent = dropdown.GetComponent<Dropdown>();
        }
    }
    public void SetResolution()
    {
        int resolutionIndex = dropComponent.value;
        PlayerPrefs.SetInt("resIndex", resolutionIndex);
        int IndexRes = PlayerPrefs.GetInt("resIndex");
        int width = widths[IndexRes];
        int height = heights[IndexRes];
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
    public void SetFullscreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    IEnumerator GenerateEnemy()
    {
        float newY = Random.Range(-4.4f, 4.4f);
        int index = Random.Range(0, obstaclesList.Length);
        Debug.Log(index);
        Instantiate(obstaclesList[index], new Vector3(15, newY, 0), Quaternion.identity);
        float time = Random.Range(0.6f, 4f);
        new WaitForSeconds(time);
        yield return new WaitForSeconds(time);

        StartCoroutine(GenerateEnemy());
    }
}
