using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonAyudas : MonoBehaviour
{
    public GameObject MenuSmallSeleccion;  // El menú que contiene los botones UsarAyuda y VerAnuncio
    public Button UsarAyuda;               // El botón UsarAyuda
    public Button VerAnuncio;              // El botón VerAnuncio
    private bool isMenuActive = false;     // Estado para controlar la visibilidad del menú

    // Start is called before the first frame update
    void Start()
    {
        // Asegurarse de que el menú esté oculto al principio
        MenuSmallSeleccion.SetActive(false);

        // Agregar listeners a los botones dentro del menú pequeño
        UsarAyuda.onClick.AddListener(OnUsarAyudaClick);
        VerAnuncio.onClick.AddListener(OnVerAnuncioClick);
    }

    // Función que se ejecuta al presionar el botón BotonAyudas
    public void OnBotonAyudasClick()
    {
        // Cambiar el estado del menú (mostrar u ocultar)
        isMenuActive = !isMenuActive;
        MenuSmallSeleccion.SetActive(isMenuActive);
    }

    // Función para manejar el evento al presionar el botón UsarAyuda
    void OnUsarAyudaClick()
    {
        Debug.Log("Usar Ayuda presionado");
        // Aquí puedes agregar la funcionalidad que desees para el botón UsarAyuda
    }

    // Función para manejar el evento al presionar el botón VerAnuncio
    void OnVerAnuncioClick()
    {
        Debug.Log("Ver Anuncio presionado");
        // Aquí puedes agregar la funcionalidad que desees para el botón VerAnuncio
    }

    // Update is called once per frame
    void Update()
    {
        // Si necesitas algo que ocurra en cada frame, puedes agregarlo aquí.
    }
}
