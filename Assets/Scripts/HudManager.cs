using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance { get; private set; }

    public Slider curseBar;
    public GameObject textWarn;
    public GameObject gameOverUI;
    public GameObject winUI;
    public GameObject pauseUI;

    public List<Image> crystalImages;
    private int currentIndex = 0;
    private int currentIndexTwo = 0;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ChangeToRed()
    {
        if (currentIndex < crystalImages.Count)
        {
            crystalImages[currentIndex].color = Color.red;
            currentIndex++;
        }
    }

    public void RemoveCrystalImage()
    {
        if (crystalImages.Count > 0)
        {
            //Destroy(crystalImages[0].gameObject);
            crystalImages[currentIndexTwo].gameObject.SetActive(false);
            currentIndexTwo++;
            //crystalImages.RemoveAt(0);
        }
    }
}
