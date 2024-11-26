using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private GameObject playerObject;

    public AudioClip interactionSound;

    public bool pedestal;
    public GameObject crystal;

    private float distanceToPlayer;
    public float activeDistance = 4;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(this.gameObject.transform.position, playerObject.transform.position);
    }
    private void OnMouseOver()
    {
        if (distanceToPlayer <= activeDistance)
        {
            HudManager.Instance.textWarn.SetActive(true);
            if (pedestal) { ActiveCrystal(); }
        }
        else
        {
            HudManager.Instance.textWarn.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        HudManager.Instance.textWarn.SetActive(false);
    }

    private void ActiveCrystal()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(GameManager.Instance.crystalsCollected >= 1)
            {
                HudManager.Instance.textWarn.SetActive(false);
                crystal.SetActive(true);
                GameManager.Instance.crystalsCollected--;
                Destroy(this);
                //SoundManager.Instance.eventsSoundSource.PlayOneShot(interactionSound);
            }
        }
    }
}
