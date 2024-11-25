using UnityEngine;

public class EyeBehavior : MonoBehaviour
{
    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (_playerTransform != null)
        {
            // Faz o objeto olhar para o jogador em todos os eixos (horizontal e vertical)
            transform.LookAt(_playerTransform);

            // Corrige a rota��o subtraindo 80� no eixo Y para ajustar a orienta��o
            transform.Rotate(0, -90f, 0);
        }
    }
}
