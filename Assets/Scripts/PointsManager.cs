using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int score = 0;

    // Use this in the script for breakable objects to add points to the score
    // Use a SerializedField variable for the amount of points an object gives so it can be easily altered from the editor
    // An example of calling this would be AlterScore(1000); to gain a thousand points from destroying a cone
    public void AlterScore(int points)
    {
        score += points;

        // I don't want the score to go below zero, since a negative score would be demoralizing
        if (score < 0)
        {
            score = 0;
        }
    }

    // Used to recieve the player's score, like to determine the player's rank after the game ends
    public int GetScore()
    {
        return score;
    }
}
