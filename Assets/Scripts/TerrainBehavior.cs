using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
    private float _timeSinceLastCurse = 0f; // Variável para controlar o tempo
    private float _curseIncreaseInterval = 0.05f; // Intervalo de tempo para aumentar a maldição

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _timeSinceLastCurse += Time.deltaTime;

            // Verifica se o tempo passou o intervalo para aumentar a maldição
            if (_timeSinceLastCurse >= _curseIncreaseInterval)
            {
                other.gameObject.GetComponentInChildren<PlayerCurse>().ImproveCurse(1f);
                _timeSinceLastCurse = 0f; // Reseta o temporizador
            }
        }
    }
}
