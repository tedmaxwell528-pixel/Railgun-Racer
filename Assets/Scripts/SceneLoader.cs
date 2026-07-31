using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject creditsScreen;
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
        ScoreManager.Score = 0;
        SceneManager.LoadScene("Winson");
    }

    public static void EndGame(){ 
        SceneManager.LoadScene("End Screen");
    }

    public static void CreditsScreen(){
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
