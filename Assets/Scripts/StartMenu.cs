using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject rule = null;
    [SerializeField]
    private GameObject setting = null;
    [SerializeField]
    private GameObject Quit = null;
    private GameManager gameManager = null;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        gameManager = GetComponent<GameManager>();
        soundManager.Startbgm();
    }
    public void OnQuitClick()
    {
        Quit.SetActive(true);
    }
    public void OnQuitYes()
    {
        Application.Quit();
    }
    public void OnQuitNo()
    {
        Quit.SetActive(false);
    }
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnSettingOpenClick()
    {
        setting.SetActive(true);
    }
    public void OnSettingCloseClick()
    {
        setting.SetActive(false);
    }
    public void OnRuleCloseClick()
    {
        rule.SetActive(false);
    }
    public void OnOpenRuleClick()
    {
        rule.SetActive(true);
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
