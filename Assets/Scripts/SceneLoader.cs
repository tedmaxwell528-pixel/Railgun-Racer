using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance = null;

    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static void MainMenu(){
        SceneManager.LoadScene("Start Screen");
    }

    public static void StartGame(){
        SceneManager.LoadScene("Winson");
    }

    public static void EndGame(){ 
        SceneManager.LoadScene("End Screen");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
