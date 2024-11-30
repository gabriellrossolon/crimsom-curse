using StarterAssets;
using System.Collections;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public GameObject _playerObject;
    public GameObject _transition;
    public Vector3 _destinyPos;

    public AudioClip triggerSound;

    public bool _firstEncounter;
    public bool _lastEncounter;
    public bool _bossTrig;
    public bool _winTrigg;

    public GameObject giantEye;

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        { StartCoroutine(CallEffect()); }
    }

    private IEnumerator CallEffect()
    {
        _transition.GetComponent<Animator>().SetTrigger("DoTransition");
        SoundManager.Instance.eventsSoundSource.PlayOneShot(triggerSound);
        yield return new WaitForSeconds(0.4f);
        _playerObject.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        if (_bossTrig)
        {
            SoundManager.Instance.ambientSoundSource.clip = SoundManager.Instance.bossMusic;
            SoundManager.Instance.ambientSoundSource.Play();
        }
        if (_lastEncounter) { Destroy(giantEye); }
        if (_firstEncounter) { Teleport(); }
        if (_winTrigg) { WinGame(); }
        yield return new WaitForSeconds(1f);
        
        _playerObject.GetComponent<FirstPersonController>().enabled = true;
    }

    private void Teleport()
    {
        _playerObject.transform.localPosition = _destinyPos;
    }

    private void WinGame()
    {
        HudManager.Instance.winUI.SetActive(true);
    }
}
