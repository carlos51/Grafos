using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private RewardedAd recompensado;

    public void Start()
    {
        // Inicializa el SDK de Google Mobile Ads.
        MobileAds.Initialize(initStatus => { });
        CargarRewardedAd();
    }

    void CargarRewardedAd()
    {
        string idTest = "ca-app-pub-3940256099942544/5224354917"; // Id de testeo

        // Crear un AdRequest directamente
        AdRequest request = new AdRequest();

        // Cargar el anuncio recompensado
        RewardedAd.Load(idTest, request, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Anuncio recompensado no pudo ser cargado: " + error);
                return;
            }

            recompensado = ad;
            Debug.Log("Anuncio recompensado cargado exitosamente.");
            // Puedes registrar los eventos aquí si lo deseas
            RegisterEventHandlers(recompensado);
        });
    }

    public void llamarRecompensado()
    {
        if (recompensado != null)
        {
            recompensado.Show((Reward reward) =>
            {
                // Aquí manejas la recompensa
                Debug.Log($"Usuario recompensado: {reward.Type}, cantidad: {reward.Amount}");
            });
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Anuncio recompensado cerrado.");
            // Cargar un nuevo anuncio después de que se cierre
            CargarRewardedAd();
        };
    }
}
