using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public KeyCode inputKey = KeyCode.A; // Tecla para controlar el flipper
    public float baseZRotation = 115f; // Rotación base en Z
    public float hitZRotation = 90f;  // Rotación de golpe en Z
    public float rotationSpeed = 500f; // Velocidad de rotación
    public float flipperForce = 50f;   // Fuerza aplicada a la pelota
    public bool isLeftFlipper = false; // Indica si es el flipper izquierdo

    private float targetZRotation; // Rotación objetivo
    private Quaternion targetRotation; // Rotación calculada
    private bool isActive = false; // Indica si el flipper está activado

    void Start()
    {
        // Si es el flipper izquierdo, invierte el eje X
        if (isLeftFlipper)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -newScale.x; // Invierte el eje X
            transform.localScale = newScale;
        }

        // Establecer la rotación inicial del flipper
        transform.rotation = Quaternion.Euler(61, 0, baseZRotation);
        targetZRotation = baseZRotation;
    }

    void Update()
    {
        // Detectar si se presiona la tecla asignada (golpe hacia arriba)
        if (Input.GetKey(inputKey))
        {
            targetZRotation = hitZRotation;
            isActive = true; // Activar el flipper
        }
        else
        {
            targetZRotation = baseZRotation;
            isActive = false; // Desactivar el flipper
        }

        // Calcular la rotación objetivo
        targetRotation = Quaternion.Euler(61, 0, targetZRotation);

        // Suavizar la rotación hacia el objetivo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player") && isActive)
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Calcular la dirección de la fuerza según el flipper
                Vector3 forceDirection = isLeftFlipper
                    ? (-transform.right + Vector3.up).normalized // Flipper izquierdo
                    : (transform.right + Vector3.up).normalized; // Flipper derecho

                // Aplicar la fuerza a la pelota
                playerRb.AddForce(forceDirection * flipperForce, ForceMode.Impulse);

                Debug.Log($"Pelota golpeada por el flipper ({(isLeftFlipper ? "izquierdo" : "derecho")}). Dirección: {forceDirection}");
            }
        }
    }
}
