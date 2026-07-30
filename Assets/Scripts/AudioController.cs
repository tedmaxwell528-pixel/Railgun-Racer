using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource bgmPlayer, sfxPlayer, driveLoopPlayer;
    [SerializeField] AudioClip driveLoop;
    [SerializeField] AudioClip bgmLoop;
    public static Action<AudioClip> playSfx = null;
    public static Action<bool> toggleSoundLoops = null;
    public static Action<bool> isDriving = null;
    public static AudioController instance = null;

    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmPlayer.clip = bgmLoop;
        bgmPlayer.loop = true;
        driveLoopPlayer.clip = driveLoop;
        driveLoopPlayer.loop = true;
        playSfx += PlaySound;
        toggleSoundLoops += ToggleLoops;
        isDriving += DriveLoopState;
    }

    void PlaySound(AudioClip sfx){
        sfxPlayer.clip = sfx;
        sfxPlayer.Play();
    }

    void ToggleLoops(bool state){
        if (state){
            bgmPlayer.Play();
            driveLoopPlayer.Play();
        } else {
            bgmPlayer.Pause();
            driveLoopPlayer.Pause();
        }
    }

    void DriveLoopState(bool state){
        if (state && !driveLoopPlayer.isPlaying){
            driveLoopPlayer.Play();
        } else if (!state && driveLoopPlayer.isPlaying){
            driveLoopPlayer.Pause();
        }
    }
}
