using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RankDisplay : MonoBehaviour
{
    //Ranks will be inserted from F -> S
    [SerializeField] List<Sprite> rankSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int finalScore = (int)ScoreManager.Score;
        Image rank = GetComponent<Image>();
        if (finalScore <= 500){
            rank.sprite = rankSprites[0];
        } else if (finalScore <= 1000){
            rank.sprite = rankSprites[1];
        } else if (finalScore <= 1500){
            rank.sprite = rankSprites[2];
        } else if (finalScore <= 2000){
            rank.sprite = rankSprites[3];
        } else if (finalScore <= 3000){
            rank.sprite = rankSprites[4];
        } else {
            rank.sprite = rankSprites[5];
        } 
    }
}
