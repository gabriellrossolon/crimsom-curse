using StarterAssets;
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
        if (other.CompareTag("Player"))
        {
            yield return new WaitForSeconds(0.4f);
            other.GetComponent<FirstPersonController>().enabled = false;
            yield return new WaitForSeconds(0.8f);
            other.transform.localPosition = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(1.2f);
            other.GetComponent<FirstPersonController>().enabled = true;
            //Destroy(this.gameObject);
        }
    }
}
