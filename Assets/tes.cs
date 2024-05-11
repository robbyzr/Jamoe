using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tes : MonoBehaviour
{
    
    public AudioSource AudioSource;

    public AudioClip Clip1;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlaySFX(Clip1); // Memanggil PlaySFX() dengan AudioClip yang sesuai
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
}
