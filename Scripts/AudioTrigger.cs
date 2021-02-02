using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public GameObject ball;
    public GameObject gameManager;
    private Collider info;

    void OnCollisionEnter()
    {
        if (gameObject.tag == "Wall")
        {
            gameManager.SendMessage("PlayWallHit");
        }
        else if (gameObject.tag == "RightPaddle")
        {
            gameManager.SendMessage("PlayPaddleHit");
        }
        else if (gameObject.tag == "LeftPaddle")
        {
            gameManager.SendMessage("PlayPaddleHit");
        }
        else {}

    }
}