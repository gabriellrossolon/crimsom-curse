using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public AudioSource eventsSoundSource;
    public AudioClip btnHoverSound;
    public AudioClip clickSound;

    public GameObject creditsScreen;
    private bool creditsScreenOpened = false;
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

    private void Update()
    {
        
    }

    public void ChangeToSampleScene()
    {
        eventsSoundSource.PlayOneShot(clickSound);
        SceneManager.LoadScene("SampleScene");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        eventsSoundSource.PlayOneShot(clickSound);
        Application.Quit();
    }

    public void CallCreditsScreen()
    {
        creditsScreenOpened = !creditsScreenOpened;
        creditsScreen.SetActive(creditsScreenOpened);
    }
}
