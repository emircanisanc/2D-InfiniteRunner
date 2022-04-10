using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip soundJump;

    [SerializeField]
    private AudioClip soundDie;

    [SerializeField]
    private AudioClip soundLanding;

    private void tryPlayAudioClip(AudioClip clip)
    {
        if(audioSource != null)
        {
            if(clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }

    public void playJumpSound()
    {
        tryPlayAudioClip(soundJump);
    }

    public void playLandingSound()
    {
        tryPlayAudioClip(soundLanding);
    }

    public void playDieSound()
    {
        tryPlayAudioClip(soundDie);
    }
}
