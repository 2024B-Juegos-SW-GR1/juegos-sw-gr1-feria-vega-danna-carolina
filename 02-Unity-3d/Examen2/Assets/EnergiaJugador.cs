using UnityEngine;
using UnityEngine.UI;

public class EnergiaJugador : MonoBehaviour
{
    public Slider barraEnergia;  // Asegúrate de que es PÚBLICA
    public float energiaMaxima = 100f;
    public float energiaActual;

    void Start()
    {
        energiaActual = energiaMaxima;
        ActualizarBarraEnergia();
    }

    public void PerderEnergia(float cantidad)
    {
        energiaActual -= cantidad;
        if (energiaActual < 0)
        {
            energiaActual = 0;
            Debug.Log("Energía agotada. Fin del juego o penalización.");
        }
        ActualizarBarraEnergia();
    }

    private void ActualizarBarraEnergia()
    {
        if (barraEnergia != null)
        {
            barraEnergia.value = energiaActual / energiaMaxima;
        }
    }
}
