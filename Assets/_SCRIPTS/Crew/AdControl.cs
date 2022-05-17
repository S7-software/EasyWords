using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdControl : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdControl instance;
    string gameId = "4737807";
    string placementIdBanner = "Banner_Android";
    string placementIdGecis = "Rewarded_Android";
    string placementIdOdul = "Rewarded_Yeni_Gorev";
    bool testMode = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (!AYARLAR.GetReklamVar()) return;
        Advertisement.Initialize(gameId, testMode);


    }
    public void ShowOdul()
    {
        if (!AYARLAR.GetReklamVar())
        {
            return;
        }
        Advertisement.Show(placementIdOdul, instance);
    }
    public void ShowGecis()
    {
        if (!AYARLAR.GetReklamVar()) return;

        Advertisement.Show(placementIdGecis, instance);
    }
    public void ShowBanner()
    {
        if (!AYARLAR.GetReklamVar()) return;

        StartCoroutine(ShowBannerWhenReady());
    }

    public void CloseBanner()
    {
        if (!AYARLAR.GetReklamVar()) return;

        Advertisement.Banner.Hide();
    }

    IEnumerator ShowBannerWhenReady()
    {

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        yield return new WaitForSeconds(0f);

        Advertisement.Banner.Show(placementIdBanner);


    }

    public void OnInitializationComplete()
    {

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {

    }

    public void OnUnityAdsAdLoaded(string placementId)
    {

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {


    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.SKIPPED:
                Debug.Log("skip basarili");
                break;
            case UnityAdsShowCompletionState.COMPLETED:
                if (placementId == placementIdGecis)
                {
                    Debug.Log("Gecis basarili");
                }
                else if (placementId == placementIdOdul)
                {
                    Debug.Log("odul basarili");
                }


                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                break;
            default:
                break;
        }
    }

}
