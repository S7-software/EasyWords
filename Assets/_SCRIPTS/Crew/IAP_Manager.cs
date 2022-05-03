using UnityEngine;
using System.Collections;
using UnityEngine.Purchasing;
public class IAP_Manager : MonoBehaviour
{
    string id_Ads = "com.s7software.easy.words.removeads";
    string id_premium = "com.s7software.easy.premium";
    string id_AdsPre = "com.s7software.easy.words.adsPre";

    void HandleReklam()
    {
       // FindObjectOfType<CanvasMENU>().SetActiveAdsButton(false);
    }
    public void OnPurchaseComplete(Product product)
    {
        if (id_Ads == product.definition.id)
        {
            //AdControl.instance.CloseBanner();
            //KAYIT.SetReklamVar(false);

            Invoke(nameof(HandleReklam), 0.4f);

            Debug.Log("reklam ürün satın alındı");

        }
        else if (id_premium == product.definition.id)
        {
            Debug.Log("pre ürün satın alındı");

        }
        else if (id_AdsPre == product.definition.id)
        {
            Debug.Log("AdsPre ürün satın alındı");
        }
        else
        {
            Debug.Log("Bilinmeyen ürün satın alındı");
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason p)
    {
        if (id_Ads == product.definition.id)
        {
            Debug.Log("reklam satın alma başarısız : " + p);


        }
        else if (id_premium == product.definition.id)
        {
            Debug.Log("Pre satın alma başarısız: " + p);

        }
        else if (id_AdsPre == product.definition.id)
        {
            Debug.Log("ads + pre satın alma başarısız: " + p);

        }
       
        else
        {
            Debug.Log("Bilinmeyen ürün satın alma başarısız: " + p);
        }

    }

}
