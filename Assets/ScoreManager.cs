using UnityEngine;
using TMPro;  // Aseg�rate de incluir esta librer�a para trabajar con TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Usamos TextMeshProUGUI en lugar de Text
    private int score = 0; // Puntaje inicial

    // Llamado cuando la pelota choca con un bumper
    public void OnBumperHit()
    {
        score += 10; // Aumentar el puntaje por cada colisi�n con un bumper
        UpdateScoreText(); // Actualizar el texto del contador
    }

    // Actualizar el texto en pantalla
    private void UpdateScoreText()
    {
        Debug.Log("ACTUALIZAR CONTADOR");
        scoreText.text = "Score: " + score.ToString();
    }
}