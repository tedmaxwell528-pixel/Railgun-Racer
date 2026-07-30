using UnityEngine;

public class RestartGame : MonoBehaviour
{
    SceneLoader sceneLoader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneLoader = GameObject.FindWithTag("GameController").GetComponent<SceneLoader>();
    }

    public void Restart(){
        SceneLoader.MainMenu();
    }
}
