using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float crystalsCollected;
    public float crystalsInPedestal;

    public GameObject winPortal;
    public GameObject firstTrigger;
    public GameObject obstHandLeft;
    public GameObject obstHandRight;

    public float bossDamage;
    public GameObject boss;
    public GameObject winCrystal;
    public GameObject explosion;

    private bool pausedGame;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){ PauseControl(); }
    }
    public void CollectCrystal()
    {
        crystalsCollected++;   
    }

    public void InsertCrystal()
    {
        crystalsInPedestal++;
        if (crystalsInPedestal == 2)
        {
            obstHandLeft.transform.position = new Vector3(obstHandLeft.transform.position.x, -1.57f, obstHandLeft.transform.position.z);
            obstHandLeft.transform.rotation = Quaternion.Euler(obstHandLeft.transform.rotation.eulerAngles.x, obstHandLeft.transform.rotation.eulerAngles.y, -45f);

            obstHandRight.transform.position = new Vector3(obstHandRight.transform.position.x, -1.29f, obstHandRight.transform.position.z);
            obstHandRight.transform.rotation = Quaternion.Euler(obstHandRight.transform.rotation.eulerAngles.x, obstHandRight.transform.rotation.eulerAngles.y, -54f);
        }
        else if (crystalsInPedestal == 3)
        {
            firstTrigger.SetActive(false);
            winPortal.SetActive(true);
            SoundManager.Instance.eventsSoundSource.PlayOneShot(SoundManager.Instance.magicSound);
        }
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f; // Retoma o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PauseControl()
    {
        pausedGame = !pausedGame;

        if (pausedGame)
        {
            Time.timeScale = 0f;
            HudManager.Instance.pauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!pausedGame)
        {
            Time.timeScale = 1f;
            HudManager.Instance.pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void BossDamage()
    {
        bossDamage++;
        if (bossDamage >= 5)
        {
            SoundManager.Instance.ambientSoundSource.clip = SoundManager.Instance.ambientSound;
            SoundManager.Instance.ambientSoundSource.Play();
            SoundManager.Instance.eventsSoundSource.PlayOneShot(SoundManager.Instance.explosionSound);
            boss.SetActive(false);
            winCrystal.SetActive(true);
            explosion.SetActive(true);
        }
    }
}
