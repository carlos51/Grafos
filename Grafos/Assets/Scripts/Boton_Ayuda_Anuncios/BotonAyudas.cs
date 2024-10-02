using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonAyudas : MonoBehaviour
{
    public GameObject MenuSmallSeleccion;  // El men� que contiene los botones UsarAyuda y VerAnuncio
    public Button UsarAyuda;               // El bot�n UsarAyuda
    public Button VerAnuncio;              // El bot�n VerAnuncio
    private bool isMenuActive = false;     // Estado para controlar la visibilidad del men�

    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de que el men� est� oculto al principio
        MenuSmallSeleccion.SetActive(false);

        // Agregar listeners a los botones dentro del men� peque�o
        UsarAyuda.onClick.AddListener(OnUsarAyudaClick);
        VerAnuncio.onClick.AddListener(OnVerAnuncioClick);
    }

    // Funci�n que se ejecuta al presionar el bot�n BotonAyudas
    public void OnBotonAyudasClick()
    {
        // Cambiar el estado del men� (mostrar u ocultar)
        isMenuActive = !isMenuActive;
        MenuSmallSeleccion.SetActive(isMenuActive);
    }

    // Funci�n para manejar el evento al presionar el bot�n UsarAyuda
    void OnUsarAyudaClick()
    {
        Debug.Log("Usar Ayuda presionado");
        // Aqu� puedes agregar la funcionalidad que desees para el bot�n UsarAyuda
    }

    // Funci�n para manejar el evento al presionar el bot�n VerAnuncio
    void OnVerAnuncioClick()
    {
        Debug.Log("Ver Anuncio presionado");
        // Aqu� puedes agregar la funcionalidad que desees para el bot�n VerAnuncio
    }

    // Update is called once per frame
    void Update()
    {
        // Si necesitas algo que ocurra en cada frame, puedes agregarlo aqu�.
    }
}
