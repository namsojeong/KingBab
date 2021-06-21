using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore=null;
    private SoundManager soundManager;
    protected virtual void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        textHighScore.text = string.Format("{0}", PlayerPrefs.GetInt("HIGHSCORE"), 0);
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnHome()
    {
        soundManager.Stopbgm();
        SceneManager.LoadScene("Start");
    }
}
