using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore=null;
    void Start()
    {
        textHighScore.text = string.Format("{0}", PlayerPrefs.GetInt("HIGHSCORE"), 0);
    }

    void Update()
    {
        
    }
}
