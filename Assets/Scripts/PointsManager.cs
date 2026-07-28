using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private static int score = 0;

    // Use this in the script for breakable objects to add points to the score
    // Use a SerializedField variable for the amount of points an object gives so it can be easily altered from the editor
    // An example of calling this would be AlterScore(1000); to gain a thousand points from destroying a cone
    public static void AlterScore(int points)
    {
        score = (int)Mathf.Clamp(score + points, 0, Mathf.Infinity);
    }

    // Used to recieve the player's score, like to determine the player's rank after the game ends
    public static int GetScore()
    {
        return score;
    }
}
