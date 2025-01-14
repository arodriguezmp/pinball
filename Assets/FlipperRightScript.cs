using UnityEngine;
using UnityEngine.UI;

public class FlipperScript : MonoBehaviour
{
    public float baseZRotation = 115f; // Rotación base en Z
    public float hitZRotation = 75f;  // Rotación de golpe en Z
    public float rotationSpeed = 5000f; // Velocidad de rotación

    private float targetZRotation; // Rotación objetivo
    private Quaternion targetRotation; // Rotación calculada

    void Start()
    {
        // Establecer la rotación inicial del flipper
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
        // Volver a la posición base al soltar la tecla
        else
        {
            targetZRotation = baseZRotation;
        }

        // Calcular la rotación objetivo
        targetRotation = Quaternion.Euler(61, 0, targetZRotation);

        // Suavizar la rotación hacia el objetivo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
