using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public bool bloodCrystal;

    public AudioClip collectSound;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bloodCrystal)
            {
                GameManager.Instance.CollectCrystal();
                HudManager.Instance.ChangeToRed();
                SoundManager.Instance.eventsSoundSource.PlayOneShot(collectSound);
                Destroy(this.gameObject);
            }
        } 
    }
}
