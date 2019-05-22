using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public AudioClip wall = null;
    public AudioClip paddle = null;
    public AudioClip score = null;
    public AudioClip win = null;
    public AudioClip portalIn = null;
    public AudioClip portalOut = null;

    public static AudioManager Call
    {
        get { return audioManager; }
    }
    #endregion

    #region PRIVATE_VARIABLES
    private AudioSource audioSource = null;

    private static AudioManager audioManager = null;
    #endregion

    private AudioManager()
    {
        audioManager = this;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWall()
    {
        audioSource.PlayOneShot(wall);
    }

    public void PlayPaddle()
    {
        audioSource.PlayOneShot(paddle);
    }

    public void PlayScore()
    {
        audioSource.PlayOneShot(score);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(win);
    }

    public void PlayPortalIn()
    {
        audioSource.PlayOneShot(portalIn);
    }

    public void PlayPortalOut()
    {
        audioSource.PlayOneShot(portalOut);
    }
}