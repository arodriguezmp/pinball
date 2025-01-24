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
            Debug.Log("La pelota ha tocado un objeto con tag 'Respawn'. Reiniciando posici�n.");

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
}
