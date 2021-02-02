using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text RightScore;
    public Text LeftScore;
    public Button ResetButton;
    public GameObject ball;
    public GameObject pause;
    public Text WinBox;
    public Text Countdown;

    public void WriteScore()
    {
        RightScore.text = GameMaster.rightPlayerScore.ToString();
        LeftScore.text = GameMaster.leftPlayerScore.ToString();
    }

    public void Reset()
    {
        GameMaster.leftPlayerScore = 0;
        GameMaster.rightPlayerScore = 0;
        WinBox.text = null;
        ball.SendMessage("GameReset", null, SendMessageOptions.RequireReceiver);
        pause.SendMessage("PauseControl", null, SendMessageOptions.RequireReceiver);
    }

    void UI()
    {
        if (GameMaster.rightPlayerScore >= 10 && GameMaster.rightPlayerScore >= GameMaster.leftPlayerScore + 2)
        {
            WinBox.color = new Color(70, 70, 255, 255);
            WinBox.text = "BLUE PLAYER WINS!";
            ball.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
        }
        else if (GameMaster.leftPlayerScore >= 10 && GameMaster.leftPlayerScore >= GameMaster.rightPlayerScore + 2)
        {
            WinBox.color = new Color(255, 70, 70, 255);
            WinBox.text = "RED PLAYER WINS!";
            ball.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
        }
    }

    void Update()
    {
        UI();
        WriteScore();
    }
}