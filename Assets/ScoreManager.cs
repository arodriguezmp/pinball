using UnityEngine;
using TMPro;  // Asegúrate de incluir esta librería para trabajar con TextMeshPro
using UnityEngine.SceneManagement; // Importa SceneManager

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Usamos TextMeshProUGUI en lugar de Text
    private int score = 0; // Puntaje inicial

    // Llamado cuando la pelota choca con un bumper
    public void OnBumperHit()
    {
        score += 10; // Aumentar el puntaje por cada colisión con un bumper
        UpdateScoreText(); // Actualizar el texto del contador

        // Verificar si el puntaje alcanzó o superó 200
        if (score >= 200)
        {
            LoadNextLevel();
        }
    }

    public void OnDie()
    {
        if (score < 100)
        {
            score = 0;
        }
        else{
            score -= 100;
        }
        UpdateScoreText();
    }

    // Método para cambiar de nivel
    private void LoadNextLevel()
    {
        Debug.Log("¡Has alcanzado 200 puntos! Cargando el siguiente nivel...");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Obtener la escena actual
        int nextSceneIndex = (currentSceneIndex == 5) ? 0 : currentSceneIndex + 1; // Si estamos en la escena 3, volver a 0

        SceneManager.LoadScene(nextSceneIndex);
    }

    // Actualizar el texto en pantalla
    private void UpdateScoreText()
    {
        Debug.Log("ACTUALIZAR CONTADOR");
        scoreText.text = "Score: " + score.ToString();
    }

}