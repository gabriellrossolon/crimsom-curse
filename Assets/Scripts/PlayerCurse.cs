using UnityEngine;
using UnityEngine.UI;

public class PlayerCurse : MonoBehaviour
{
    public float curseValue = 0;
    public float maxCurseValue = 100;

    private void Update()
    {
        HudManager.Instance.curseBar.value = curseValue;
        HudManager.Instance.curseBar.maxValue = maxCurseValue;
    }

    public void ImproveCurse(float value)
    {
        curseValue += value;
        curseValue = Mathf.Clamp(curseValue, 0f, maxCurseValue);
        CurseDeath();
    }

    private void CurseDeath()
    {
        if(curseValue >= maxCurseValue)
        {
            curseValue = maxCurseValue;
            Debug.Log("Curse killed you");
            SoundManager.Instance.ambientSoundSource.Stop();
            SoundManager.Instance.eventsSoundSource.PlayOneShot(SoundManager.Instance.gameOverSound);
            HudManager.Instance.gameOverUI.SetActive(true);
            //Time.timeScale = 0f; // Pausa o jogo
        }
    }
}
