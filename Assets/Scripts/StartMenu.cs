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
    //private int background = 0;
    //public Color color1 = Color.red;
    //public Color color2 = Color.blue;
    //public float duration = 3.0f;
    //Camera camera;
    private void Start()
    {
        //camera = GetComponent<Camera>();
        //camera.clearFlags = CameraClearFlags.SolidColor;
        animation = GetComponent<Animation>();
        gameManager = GetComponent<GameManager>();
    }
    private void Update()
    {
        //if(background==0)
        //{
        //    float t = Mathf.PingPong(Time.time, duration) / duration;
        //    camera.backgroundColor = Color.Lerp(color1, color2, t);
        //}
        //if(background==1)
        //{
        //    float t = Mathf.PingPong(Time.time, duration) / duration;
        //    camera.backgroundColor = Color.Lerp(color1, color2, t);
        //}
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

    //public void OnleftClick()
    //{
    //    background = 0;
    //}
    //public void OnrightClick()
    //{
    //    background = 1;
    //}
    
}
