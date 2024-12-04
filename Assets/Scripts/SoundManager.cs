using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource eventsSoundSource;
    public AudioSource ambientSoundSource;
    public AudioSource cursingSoundSource;

    public AudioClip gameOverSound;
    public AudioClip jumpSound;
    public AudioClip bossMusic;
    public AudioClip ambientSound;
    public AudioClip explosionSound;
    public AudioClip magicSound;
    public AudioClip btnHoverSound;
    public AudioClip cursingSound;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
