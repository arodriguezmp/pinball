using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Cambia "GameScene" por el nombre de tu escena del juego
        Debug.Log("Cargando juego...");
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
