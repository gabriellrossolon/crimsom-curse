using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class BtnBehavior : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(MenuManager.Instance != null)
        {
            MenuManager.Instance.eventsSoundSource.PlayOneShot(MenuManager.Instance.btnHoverSound);
        }
        else if (SoundManager.Instance != null)
        {
            SoundManager.Instance.eventsSoundSource.PlayOneShot(SoundManager.Instance.btnHoverSound);
        }
    }
}
