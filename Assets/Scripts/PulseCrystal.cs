using UnityEngine;

public class PulseCrystal : MonoBehaviour
{
    private LineRenderer lineRenderer; // O LineRenderer anexado a este GameObject ou outro
    public Transform target;         // O objeto que será o alvo do LineRenderer
    public bool chargedCrystal;
    private bool pointCalculated = false;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (lineRenderer != null && target != null)
        {
            // Define o primeiro ponto do LineRenderer como a posição deste objeto
            lineRenderer.SetPosition(0, transform.position);

            // Define o segundo ponto do LineRenderer como a posição do objeto-alvo
            lineRenderer.SetPosition(1, target.position);
        }

        if (chargedCrystal && !pointCalculated)
        {
            GameManager.Instance.BossDamage();
            pointCalculated = true;
        }
    }
}
