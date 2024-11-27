using System.Collections;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public GameObject _playerObject;
    public GameObject _transition;
    public Vector3 _destinyPos;

    public AudioClip triggerSound;

    public bool _firstEncounter;

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_firstEncounter) { StartCoroutine(CallEffect()); }
    }

    private IEnumerator CallEffect()
    {
        _transition.GetComponent<Animator>().SetTrigger("DoTransition");
        SoundManager.Instance.eventsSoundSource.PlayOneShot(triggerSound);
        yield return new WaitForSeconds(1f);
        _playerObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}
