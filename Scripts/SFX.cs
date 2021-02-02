using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource audioSource;

    public void Mute()
    {
        audioSource.mute = !audioSource.mute;
    }
}