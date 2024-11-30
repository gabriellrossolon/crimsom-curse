using UnityEngine;

public class PulseCrystal : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform target;
    public bool chargedCrystal;
    private bool pointCalculated = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            lineRenderer.enabled = false;
            return;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target.position);

        if (chargedCrystal && !pointCalculated)
        {
            GameManager.Instance.BossDamage();
            pointCalculated = true;
        }
    }
}

