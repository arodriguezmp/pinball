using UnityEngine;
using UnityEngine.UI;

public class FlipperScript : MonoBehaviour
{
    public float baseZRotation = 115f; // Rotaci�n base en Z
    public float hitZRotation = 75f;  // Rotaci�n de golpe en Z
    public float rotationSpeed = 5000f; // Velocidad de rotaci�n

    private float targetZRotation; // Rotaci�n objetivo
    private Quaternion targetRotation; // Rotaci�n calculada

    void Start()
    {
        // Establecer la rotaci�n inicial del flipper
        transform.rotation = Quaternion.Euler(61, 0, baseZRotation);
        targetZRotation = baseZRotation;
    }

    void Update()
    {
        // Detectar si se presiona la tecla "D" (golpe hacia arriba)
        if (Input.GetKey(KeyCode.D))
        {
            targetZRotation = hitZRotation;
        }
        // Volver a la posici�n base al soltar la tecla
        else
        {
            targetZRotation = baseZRotation;
        }

        // Calcular la rotaci�n objetivo
        targetRotation = Quaternion.Euler(61, 0, targetZRotation);

        // Suavizar la rotaci�n hacia el objetivo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
