using UnityEngine;

public class MuelleScript : MonoBehaviour
{
    public Animator springAnimator; // Referencia al Animator del muelle
    public Rigidbody ballRigidbody; // Referencia al Rigidbody de la pelota
    public float maxForce = 10f;  // Fuerza máxima que puede aplicarse
    public string activationKey = "space"; // Tecla para activar el muelle

    private float holdTime = 0f; // Tiempo que se mantiene la tecla presionada
    private bool isCharging = false; // Indica si se está acumulando fuerza

    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            isCharging = true;
            springAnimator.SetTrigger("Stress"); // Activa la animación de carga
        }

        if (isCharging)
        {
            holdTime += Time.deltaTime; // Incrementa el tiempo de carga
        }

        if (Input.GetKeyUp(activationKey))
        {
            isCharging = false;
            springAnimator.SetTrigger("Release"); // Activa la animación de liberación

            float force = Mathf.Clamp(holdTime * maxForce, 0, maxForce); // Calcula la fuerza
            ApplyForce(force);
            holdTime = 0; // Reinicia el tiempo de carga
        }
    }

    void ApplyForce(float force)
    {
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(Vector3.forward * force); // Aplica la fuerza hacia adelante
        }
    }
}
