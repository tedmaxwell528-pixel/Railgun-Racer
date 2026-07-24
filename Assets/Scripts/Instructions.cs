using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] GameObject instructions;
    private SceneLoader sceneLoader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        instructions.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseInstructions(){
        instructions.SetActive(false);
        Time.timeScale = 1;
    }
}
