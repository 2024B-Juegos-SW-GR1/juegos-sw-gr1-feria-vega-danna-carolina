using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RecyclingManager : MonoBehaviour
{
    public bool isCorrectBasurero = true;  // Variable que indica si el jugador está en un basurero correcto
    private GameObject objetoRecogido = null;  // El objeto que el jugador está llevando
    private Animator animator;  // Referencia al Animator del jugador
    public EnergiaJugador energiaJugador; // Referencia al script de energía

    private void Start()
    {
        // Obtener la referencia al Animator y la energía del jugador
        animator = GetComponent<Animator>();
        
        // Asegúrate de que el script de EnergiaJugador esté asignado correctamente
        if (energiaJugador == null)
        {
            energiaJugador = GetComponent<EnergiaJugador>();  // Asegúrate de tener acceso al script de energía
            if (energiaJugador == null)
            {
                Debug.LogError("El script de EnergiaJugador no está asignado en el objeto.");
            }
        }
    }

    private void Update()
    {
        // Verificar si la energía ha llegado a cero y finalizar el juego
        if (energiaJugador.energiaActual <= 0)
        {
            GameOver();  // Llamar a la función de Game Over
            return;  // Detener el resto del código en Update si la energía es cero
        }

        // Soltar el objeto si se presiona la tecla 'F'
        if (Input.GetKeyDown(KeyCode.F) && objetoRecogido != null)
        {
            Debug.Log("Soltando objeto: " + objetoRecogido.tag);
            objetoRecogido.transform.SetParent(null);
            objetoRecogido = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el jugador tiene suficiente energía para recoger el objeto
        if (energiaJugador.energiaActual <= 0) 
        {
            Debug.Log("No tienes suficiente energía para recoger más objetos.");
            return;  // No permitir la recogida si no hay energía
        }

        // Recoger el objeto reciclable si aún no estamos cargando uno
        if (objetoRecogido == null)
        {
            if (other.CompareTag("Plastico") || other.CompareTag("Vidrio") || other.CompareTag("Papel") || other.CompareTag("Organico"))
            {
                objetoRecogido = other.gameObject;
                objetoRecogido.transform.SetParent(transform);  // Adjuntar el objeto al jugador
                objetoRecogido.transform.position = transform.position;  // Colocar el objeto en la posición del jugador
                Debug.Log("Has recogido el ítem reciclable con el tag: " + objetoRecogido.tag);

                // Restar energía por recoger un objeto
                //energiaJugador.PerderEnergia(5f);  // Restar 5 unidades de energía por recoger un objeto, ajusta según sea necesario
            }
        }

        // Verificar si estamos llevando un objeto y estamos entrando en un basurero
        else if (objetoRecogido != null)
        {
            if (other.CompareTag("PlasticoBasurero") && objetoRecogido.CompareTag("Plastico") ||
                other.CompareTag("VidrioBasurero") && objetoRecogido.CompareTag("Vidrio") ||
                other.CompareTag("PapelBasurero") && objetoRecogido.CompareTag("Papel") ||
                other.CompareTag("OrganicoBasurero") && objetoRecogido.CompareTag("Organico"))
            {
                Debug.Log("Reciclaje correcto: " + objetoRecogido.tag + ". Eliminando objeto.");
                Destroy(objetoRecogido);
                objetoRecogido = null;
                isCorrectBasurero = true;  // Estás en el basurero correcto
            }
            else
            {
                Debug.Log("Reciclaje incorrecto. No puedes reciclar " + objetoRecogido.tag + " en " + other.tag + ".");
                isCorrectBasurero = false;  // Estás en el basurero incorrecto
                animator.SetTrigger("ouch");  // Activar la animación de error

                // Restar energía al jugador si la acción es incorrecta
                energiaJugador.PerderEnergia(10f);  // Ajusta el valor según lo que consideres adecuado
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Si salimos de un basurero y fue incorrecto, volvemos a activar la variable
        if (!isCorrectBasurero && (other.CompareTag("PlasticoBasurero") || 
                                   other.CompareTag("VidrioBasurero") || 
                                   other.CompareTag("PapelBasurero") || 
                                   other.CompareTag("OrganicoBasurero")))
        {
            Debug.Log("Saliste del basurero incorrecto: " + other.tag + ". Puedes intentar reciclar nuevamente.");
            isCorrectBasurero = true;  // Volver a permitir el reciclaje
        }
    }

    // Función que se llama cuando el juego termina
    private void GameOver()
    {
        Debug.Log("¡Has perdido! No tienes suficiente energía.");
        // Aquí puedes cargar una escena de "Game Over" o reiniciar el juego
        // Si tienes una escena de Game Over, usa la siguiente línea:
        SceneManager.LoadScene("GameOverScene");  // Asegúrate de tener una escena llamada "GameOverScene" en tu proyecto
        // Si quieres reiniciar el juego, puedes usar:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}