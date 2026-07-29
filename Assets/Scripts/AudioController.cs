using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource bgmPlayer, sfxPlayer;
    [SerializeField] AudioSource driveLoopPlayer;
    [SerializeField] AudioClip driveLoop;
    [SerializeField] AudioClip bgmLoop;
    public static Action<AudioClip> playSfx = null;
    public static Action startSoundLoops = null;
    public static Action<bool> isDriving = null;

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
        driveLoopPlayer.clip = driveLoop;
        driveLoopPlayer.loop = true;
        playSfx += PlaySound;
        startSoundLoops += StartLoops;
        isDriving += DriveLoopState;
    }

    void PlaySound(AudioClip sfx){
        sfxPlayer.clip = sfx;
        sfxPlayer.Play();
    }

    void StartLoops(){
        bgmPlayer.Play();
        driveLoopPlayer.Play();
    }

    void DriveLoopState(bool state){
        if (state && !driveLoopPlayer.isPlaying){
            driveLoopPlayer.Play();
        } else if (!state && driveLoopPlayer.isPlaying){
            driveLoopPlayer.Pause();
        }
    }
}
