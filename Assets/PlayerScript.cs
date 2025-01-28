using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 initialPosition; // Almacena la posición inicial de la pelota

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Guarda la posición inicial de la pelota al iniciar el juego
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona tiene el tag "Respawn"
        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("La pelota ha tocado un objeto con tag 'Respawn'. Reiniciando posición.");

            // Reinicia la posici�n de la pelota
            transform.position = initialPosition;

            // Si hay un Rigidbody, det�n su movimiento para evitar problemas
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Det�n la velocidad
                rb.angularVelocity = Vector3.zero; // Det�n la rotaci�n
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            Debug.Log("Contacto con Bumper");

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Dirección del centro del bumper al punto de impacto
                Vector3 bumperCenter = collision.transform.position;
                Vector3 collisionPoint = collision.contacts[0].point;

                // Dirección radial (desde el centro del bumper hacia el punto de impacto)
                Vector3 radialDirection = (collisionPoint - bumperCenter).normalized;

                // Invertir la dirección si la pelota entra desde el lado opuesto
                Vector3 incomingVelocity = rb.linearVelocity;
                Vector3 bounceDirection = Vector3.Reflect(incomingVelocity.normalized, radialDirection);

                // Fuerza del rebote, basada en la velocidad de entrada
                float incomingSpeed = incomingVelocity.magnitude;
                float bumperForce = Mathf.Clamp(incomingSpeed * 1.5f, 25f, 75f); // Ajusta los valores según sea necesario

                // Aplica la fuerza en la dirección del rebote
                rb.linearVelocity = Vector3.zero; // Detén cualquier movimiento previo
                rb.AddForce(bounceDirection * bumperForce, ForceMode.Impulse);

                Debug.Log($"Fuerza aplicada: {bounceDirection * bumperForce}, Dirección: {bounceDirection}");
            }
        }
    }

}
