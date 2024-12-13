using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("¡Ganaste!");
            // Aquí puedes agregar lógica para reiniciar o salir.
        }

        if (other.CompareTag("Trap"))
        {
            Debug.Log("¡Perdiste!");
            // Reinicia el nivel o termina el juego.
        }
    }
}

