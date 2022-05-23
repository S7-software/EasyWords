using UnityEngine;
using System.Collections;
using UnityEngine.Purchasing;
public class IAP_Manager : MonoBehaviour
{
    string id_Ads = "com.s7software.easy.words.removeads";
    string id_premium = "com.s7software.easy.premium";
    string id_AdsPre = "com.s7software.easy.words.adspre";

   
    public void OnPurchaseComplete(Product product)
    {
        if (id_Ads == product.definition.id)
        {
            FindObjectOfType<UI_SATIN_ALMA>().EvetnAds(true);

            Debug.Log("reklam ürün satın alındı");

        }
        else if (id_premium == product.definition.id)
        {
            FindObjectOfType<UI_SATIN_ALMA>().EventPremium(true);

        }
        else if (id_AdsPre == product.definition.id)
        {
            FindObjectOfType<UI_SATIN_ALMA>().EventAdsPremium(true);

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
