using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClick;
    [SerializeField]
    private AudioClip dead;
    [SerializeField]
    private AudioSource bgm;
    [SerializeField]
    private AudioClip lifeDead;
    private void Start()
    {
        bgm = GetComponent<AudioSource>();
    }
    public void Startbgm()
    {
        bgm.Play();
        DontDestroyOnLoad(bgm);
    }
    public void Stopbgm()
    {
        bgm.Stop();
    }
    public void OnbuttonClick()
    {
        audioSource.clip = buttonClick;
        if (audioSource == null) return;
        audioSource.Play();
    }

    public void Dead()
    {
        audioSource.clip = dead;
        audioSource.Play();
    }
    public void LifeDead()
    {
        audioSource.clip = lifeDead;
        audioSource.Play();
    }

}
