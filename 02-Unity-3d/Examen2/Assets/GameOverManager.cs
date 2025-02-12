using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class GameOverManager : MonoBehaviour
{
    // Método que reinicia el juego cargando la escena SampleScene
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Método para salir del juego
    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego..."); // Para verificar en el Editor
        Application.Quit();
    }
}