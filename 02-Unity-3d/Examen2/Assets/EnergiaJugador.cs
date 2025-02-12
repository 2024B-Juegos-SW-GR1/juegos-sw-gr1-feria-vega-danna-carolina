using UnityEngine;
using UnityEngine.UI;

public class EnergiaJugador : MonoBehaviour
{
    public Slider barraEnergia;  // Aseg�rate de que es P�BLICA
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
            Debug.Log("Energ�a agotada. Fin del juego o penalizaci�n.");
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
