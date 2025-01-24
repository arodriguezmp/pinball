using TMPro;
using UnityEngine;
using System.Collections;

public class MuelleScript : MonoBehaviour
{
    public Animator springAnimator; // Referencia al Animator del muelle
    public Rigidbody ballRigidbody; // Referencia al Rigidbody de la pelota
    public float maxForce = 10f;  // Fuerza m�xima que puede aplicarse
    public string activationKey = "space"; // Tecla para activar el muelle
    public Transform targetObject; // Objeto que se mover�

    private Vector3 initialPosition = new Vector3(15.4f, 14.58f, 19.22f); // Posici�n al presionar espacio
    private Vector3 targetPosition = new Vector3(15.4f, 11.94f, 15.08f); // Posici�n destino
    private float holdTime = 0f; // Tiempo que se mantiene la tecla presionada
    private bool isCharging = false; // Indica si se est� acumulando fuerza

    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            isCharging = true;
            springAnimator.SetTrigger("Stress"); // Activa la animaci�n de carga

            // Asegurarse de que el objeto est� en la posici�n deseada
            if (targetObject != null)
            {
                targetObject.position = initialPosition;
            }
        }

        if (isCharging)
        {
            holdTime += Time.deltaTime; // Incrementa el tiempo de carga
        }

        if (Input.GetKeyUp(activationKey))
        {
            isCharging = false;
            springAnimator.SetTrigger("Release"); // Activa la animaci�n de liberaci�n

            float force = Mathf.Clamp(holdTime * maxForce, 0, maxForce); // Calcula la fuerza
            ApplyForce(force);
            holdTime = 0; // Reinicia el tiempo de carga

            // Inicia la corrutina para mover el objeto
            StartCoroutine(MoveObjectAfterDelay(4f));
        }
    }

    void ApplyForce(float force)
    {
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(Vector3.forward * force); // Aplica la fuerza hacia adelante
        }
    }

    // Corrutina para mover el objeto despu�s de un retraso
    private IEnumerator MoveObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Espera 5 segundos

        if (targetObject != null)
        {
            targetObject.position = targetPosition; // Mueve el objeto a la posici�n especificada
        }
    }
}
