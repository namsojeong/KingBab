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
