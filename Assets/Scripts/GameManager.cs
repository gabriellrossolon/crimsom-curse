using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float crystalsCollected;

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

    public void CollectCrystal()
    {
        crystalsCollected++;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f; // Retoma o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
