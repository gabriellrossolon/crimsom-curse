using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Start()
    {
        Destroy(gameObject, 6f);
    }
    public void Initialize(Vector3 direction, float speed)
    {
        moveDirection = direction;
        moveSpeed = speed;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInChildren<PlayerCurse>().ImproveCurse(15f);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("PulseCrystal"))
        {
            other.GetComponent<LineRenderer>().enabled = true;
            other.transform.Find("ChargedCrystal").gameObject.SetActive(true);
            other.transform.Find("NormalCrystal").gameObject.SetActive(false);
            other.GetComponent<PulseCrystal>().chargedCrystal = true;
            Destroy(this.gameObject);
        }
    }
}
