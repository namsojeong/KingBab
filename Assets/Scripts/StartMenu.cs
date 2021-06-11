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
    private Animation animation = null;
    AudioSource bgm;
    private void Awake()
    {
        animation = GetComponent<Animation>();
        gameManager = GetComponent<GameManager>();
        bgm = GetComponent<AudioSource>();
    }
    public void OnPlayClick()
    {
        DontDestroyOnLoad(bgm);
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

    //public void OnleftClick()
    //{
    //    background = 0;
    //}
    //public void OnrightClick()
    //{
    //    background = 1;
    //}
    
}
