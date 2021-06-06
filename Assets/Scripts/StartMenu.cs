using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnSettingClick()
    {
        
    }
    public void OnRetryClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnHomeClick()
    {
        SceneManager.LoadScene("Start");
    }
}
