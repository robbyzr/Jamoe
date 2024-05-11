using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioMenang;
    public AudioSource audioKalah;



    private void Start()
    {
       
    }

    public void ToggleBgmMainmenu()
    {
        audioSource.mute = !audioSource.mute;
    }

    public void ToggleSFX()
    {
        audioMenang.mute = !audioMenang.mute;
        audioKalah.mute = !audioKalah.mute;
    }

}
