using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioClip _stepSound;
    public AudioSource _stepSource;

    public void Step()
    {
        _stepSource.PlayOneShot(_stepSound);
    }
}
