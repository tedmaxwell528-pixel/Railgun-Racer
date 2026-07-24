using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Action caught = null;
    public Action restart = null;

    void Awake(){
        SceneLoader[] objs = FindObjectsByType<SceneLoader>(FindObjectsSortMode.None);
        if (objs.Length > 1){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        caught += EndGame;
        restart += StartGame;
    }

    public void StartGame(){
        SceneManager.LoadScene("Winson");
    }

    void EndGame(){ 
        SceneManager.LoadScene("End Screen");
    }
}
