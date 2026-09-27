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

            // Lanzar particulas
            collectParticles.Play();

            // Ocultar moneda
            GetComponent<MeshRenderer>().enabled = false;

            // Desactivar collider
            GetComponent<Collider>().enabled = false;

            // Destruir después de que terminen las partículas
            Destroy(gameObject, 1.5f);
        }
    }
}