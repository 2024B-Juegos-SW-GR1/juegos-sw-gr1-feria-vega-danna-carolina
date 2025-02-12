using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class GameOverManager : MonoBehaviour
{
    // M�todo que reinicia el juego cargando la escena SampleScene
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // M�todo para salir del juego
    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego..."); // Para verificar en el Editor
        Application.Quit();
    }
}