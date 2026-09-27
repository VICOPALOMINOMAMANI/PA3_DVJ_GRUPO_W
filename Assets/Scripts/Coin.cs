using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Rotacion")]
    public float rotationSpeed = 100f;

    [Header("Particulas")]
    public ParticleSystem collectParticles;

    private bool collected = false;

    void Update()
    {
        transform.Rotate(
            0f,
            rotationSpeed * Time.deltaTime,
            0f,
            Space.World
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;

            // Avisar al GameManager
            GameManager gameManager =
                FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.CollectCoin();
            }

            // Particulas
            if (collectParticles != null)
            {
                collectParticles.Play();
            }

            // Ocultar moneda
            MeshRenderer meshRenderer =
                GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }

            // Desactivar collider
            Collider coinCollider =
                GetComponent<Collider>();

            if (coinCollider != null)
            {
                coinCollider.enabled = false;
            }

            // Destruir despues de las particulas
            Destroy(gameObject, 1.5f);
        }
    }
}