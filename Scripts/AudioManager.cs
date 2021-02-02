using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip PaddleHit;
    public AudioClip WallHit;
    public GameObject reciever;

    public void PlayWallHit()
    {
        audioSource.PlayOneShot(WallHit);
    }

    public void PlayPaddleHit()
    {
        audioSource.PlayOneShot(PaddleHit);
    }
}