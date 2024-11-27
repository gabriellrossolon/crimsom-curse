using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class BtnBehavior : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        MenuManager.Instance.eventsSoundSource.PlayOneShot(MenuManager.Instance.btnHoverSound);
    }
}
