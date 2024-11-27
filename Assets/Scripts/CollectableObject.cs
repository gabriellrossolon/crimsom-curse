using System.Collections;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public bool bloodCrystal;

    public AudioClip collectSound;
    public GameObject crystalModel;
    public GameObject transition;

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
                transition.GetComponent<Animator>().SetTrigger("DoTransition");
                crystalModel.SetActive(false);
                StartCoroutine(BackToSpawn(other));
            }
        } 
    }

    private IEnumerator BackToSpawn(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.transform.localPosition = new Vector3(0, 0, 0);
        Destroy(this.gameObject);
    }
}
