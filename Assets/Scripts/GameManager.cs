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
        }
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f; // Retoma o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BossDamage()
    {
        bossDamage++;
        if (bossDamage >= 3)
        {
            boss.SetActive(false);
            winCrystal.SetActive(true);
        }
    }
}
