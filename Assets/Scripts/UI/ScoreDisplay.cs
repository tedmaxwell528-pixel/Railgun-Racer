using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    string prefix;
    TMP_Text scoreText;

    void Awake(){
        scoreText = GetComponent<TMP_Text>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prefix = scoreText.text;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = prefix + ScoreManager.ScoreString;
    }
}
