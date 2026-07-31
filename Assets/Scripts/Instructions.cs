using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] GameObject instructions, gasCan, gasText, scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        instructions.SetActive(true);
        gasCan.SetActive(false);
        gasText.SetActive(false);
        scoreText.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseInstructions(){
        instructions.SetActive(false);
        gasCan.SetActive(true);
        gasText.SetActive(true);
        scoreText.SetActive(true);
        Time.timeScale = 1;
        AudioController.toggleSoundLoops?.Invoke(true);
    }
}
