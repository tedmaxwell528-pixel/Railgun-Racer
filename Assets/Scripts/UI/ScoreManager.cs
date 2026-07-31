using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static float score = 0;
    //Getter and setter property of score
    public static float Score{
        get {return score;}
        set {score = value;}
    }
    public static string ScoreString => Mathf.Round(score).ToString();
}
