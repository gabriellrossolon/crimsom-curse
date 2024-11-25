using System.Collections;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    private GameObject _playerObject;
    public GameObject _transition;
    public Vector3 _destinyPos;

    public bool _firstEncounter;

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("PlayerParent");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_firstEncounter) { StartCoroutine(CallEffect()); }
    }

    private IEnumerator CallEffect()
    {
        _transition.GetComponent<Animator>().SetTrigger("DoTransition");
        yield return new WaitForSeconds(0.3f);
        _playerObject.transform.position = _destinyPos;
    }
}
