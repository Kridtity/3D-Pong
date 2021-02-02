using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    #region Variables
    //Player scores
    [Header("Score")]
    public static int rightPlayerScore = 0;
    public static int leftPlayerScore = 0;

    //Reference wall objects
    [Space]
    [Header("Game Objects")]
    public GameObject rightWall;
    public GameObject leftWall;

    //Reference ball
    public GameObject ball;

    #endregion

    public static void Score(string wall)
    {
        if (wall == "LeftWall")
        {
            rightPlayerScore++;

        }
        else
        {
            leftPlayerScore++;
        }
    }
}