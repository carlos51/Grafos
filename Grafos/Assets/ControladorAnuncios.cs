using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ControladorAnuncios : MonoBehaviour, IUnityAdsInitializationListener
{
    public static ControladorAnuncios instance;


    public string androidGameId;

    public string idAnunciosAndroid;

    private string idSeleccionado;

    private string idAnuncioSeleccionado;

    public bool modoPruebas = true;

    private void Awakee()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void IniciarAnuncios()
    {
#if UNITY_ANDROID
        idSeleccionado = androidGameId;
        idAnuncioSeleccionado = idAnunciosAndroid;
#elif UNITY_EDITOR
        idSeleccionado = androidGameId;
        idAnuncioSeleccionado = idAnunciosAndroid;

#endif
        Advertisement.Initialize(idSeleccionado, modoPruebas, this);
    }
}
