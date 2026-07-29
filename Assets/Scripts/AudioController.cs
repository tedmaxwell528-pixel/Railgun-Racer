using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource bgmPlayer, sfxPlayer;
    [SerializeField] AudioClip driveLoop;
    [SerializeField] AudioClip bgmLoop;
    public static Action<AudioClip> playSfx = null;
    public static Action startBgmLoop = null;

    void Awake()
    {
        sfxPlayer = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmPlayer = Camera.main.gameObject.GetComponent<AudioSource>();
        bgmPlayer.clip = bgmLoop;
        bgmPlayer.loop = true;
        playSfx += PlaySound;
        startBgmLoop += StartLoop;
    }

    void PlaySound(AudioClip sfx){
        sfxPlayer.clip = sfx;
        sfxPlayer.Play();
    }

    void StartLoop(){
        bgmPlayer.Play();
    }
}
