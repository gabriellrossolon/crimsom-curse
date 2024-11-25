using UnityEngine;

public class BloodScroller : MonoBehaviour
{
    public Material targetMaterial; // Material que será manipulado
    public float scrollSpeed = 0.5f; // Velocidade do deslocamento no eixo X

    private float offsetX = 0f; // Variável para rastrear o deslocamento X

    void Update()
    {
        // Incrementa o offset no eixo X
        offsetX += scrollSpeed * Time.deltaTime;

        // Aplica o offset ao material
        targetMaterial.SetTextureOffset("_BaseMap", new Vector2(offsetX, 0));
    }
}
