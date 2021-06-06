using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject setting = null;
    private bool ismenu = false;
    private GameManager gameManager = null;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnSettingOpenClick()
    {
        setting.SetActive(true);
    }
    public void OnCloseClick()
    {
        setting.SetActive(false);
    }
    public void OnRetryClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnHomeClick()
    {
        SceneManager.LoadScene("Start");
    }
    public void OnHighscoreClick()
    {
        PlayerPrefs.SetInt("HIGHSCORE", 0);
    }
}
