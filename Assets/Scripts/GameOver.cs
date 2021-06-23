using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore=null;
    [SerializeField]
    private Text textScore=null;
    private SoundManager soundManager;
    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        textHighScore.text = string.Format("최고 가격\n{0}", PlayerPrefs.GetInt("HIGHSCORE"), 0);
        textScore.text = string.Format("{0}", PlayerPrefs.GetInt("SCORE"), 0);
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
