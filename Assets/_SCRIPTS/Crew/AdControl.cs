using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdControl : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdControl instance;
    string gameId = "4737807";
    string placementIdBanner = "and_EasyWord_Banner2";
    string placementIdGecis = "and_EasyWord_Gecis";
    string placementIdOdul = "and_EasyWord_Odul";
    bool testMode = false;
    private void Awake()
    {

        
        if (FindObjectsOfType<AdControl>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        }
    }
    
    void Start()
    {
      if (!AYARLAR.GetReklamVar()) return;
        Advertisement.Initialize(gameId, testMode,instance);


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
        if (PREMIUM.GetPremiumGunlukCalisiyor()) { return; }
        TEMP.CountReklamaKalan--;
        Debug.Log(TEMP.CountReklamaKalan);
        if (TEMP.CountReklamaKalan != 0) return;
        Advertisement.Show(placementIdGecis);
        TEMP.CountReklamaKalan = Random.Range(20,26);
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
                    FindObjectOfType<UI_PREMIUM>().SureliPremiumVer();
                }
                else
                {
                    Debug.Log("odul bilinmeyen");

                }


                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                break;
            default:
                break;
        }
    }

}
