using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public bool bloodCrystal;

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
                Destroy(this.gameObject);
            }
        } 
    }
}
