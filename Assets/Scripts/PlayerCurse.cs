using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurse : MonoBehaviour
{
    public float curseValue = 0;
    public float maxCurseValue = 100;
    private bool cursed = false;

    private float lastCurseUpdateTime;


    private void Update()
    {
        HudManager.Instance.curseBar.value = curseValue;
        HudManager.Instance.curseBar.maxValue = maxCurseValue;

        if (SoundManager.Instance.cursingSoundSource.isPlaying && Time.time - lastCurseUpdateTime > 0.5f)
        {
            SoundManager.Instance.cursingSoundSource.Stop();
        }
    }

    public void ImproveCurse(float value)
    {
        curseValue += value;
        curseValue = Mathf.Clamp(curseValue, 0f, maxCurseValue);

        lastCurseUpdateTime = Time.time;

        if (!SoundManager.Instance.cursingSoundSource.isPlaying)
            SoundManager.Instance.cursingSoundSource.Play();

        StartCoroutine(CurseDeath());
    }

    private IEnumerator CurseDeath()
    {
        if(curseValue >= maxCurseValue && !cursed)
        {
            curseValue = maxCurseValue;
            Debug.Log("Curse killed you");
            SoundManager.Instance.ambientSoundSource.Stop();
            SoundManager.Instance.eventsSoundSource.PlayOneShot(SoundManager.Instance.gameOverSound);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            HudManager.Instance.gameOverUI.SetActive(true);
            cursed = true;
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0f;
        }
    }
}
