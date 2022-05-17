using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UI_PREMIUM : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] float _delay = 0.4f;
    [SerializeField] float _delayYokEt = 0.4f;
    [Header("Tanimlanacaklar")]
    [SerializeField] MyButton _myBtnPremium;
    [SerializeField] TMP_Text _txtPremium,_txtHeader;

    int _count;
    bool _reklamVar;
    bool _premiumGunlukCalisiyor;
    bool _premiumGunlukAlinabilir;

    bool _myButtonAktif = true;
    private void Awake()
    {
        PREMIUM.PremiumSureKontrol();

        if( (TEMP._gidilecekSahne == Sahne.Harfler || TEMP._gidilecekSahne == Sahne.Sayilar ||
            TEMP._secilenCategorie == Categories.Karisik || PREMIUM.GetPremiumVar()|| PREMIUM.GetPremiumGunlukCalisiyor())
            &&SceneManager.GetActiveScene().name!=Sahne.MainMenu.ToString())
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
        IlkAyar();
    }
    private void IlkAyar()
    {
        PREMIUM.PremiumSureKontrol();
        _count = PREMIUM.GetPremiumGunlukCount();
        _reklamVar = AYARLAR.GetReklamVar();
        _premiumGunlukCalisiyor = PREMIUM.GetPremiumGunlukCalisiyor();
        _premiumGunlukAlinabilir= PREMIUM.GetPremiumGunlukAlinabilir();

    
        if (_premiumGunlukCalisiyor)
        {
            _myButtonAktif = false;
            _myBtnPremium.SetDurumButton(MyButton.durumButton.aktifDegil);
        }

       else if (_count > 0 && !_premiumGunlukCalisiyor&&_premiumGunlukAlinabilir)
        {
            _myButtonAktif = true;
            string ads = _reklamVar ? "AD for Premium" : "Premium";
            _txtPremium.text = $"{ads} ({_count})";
            _txtPremium.color = Color.green;

            _myBtnPremium.SetDurumButton(MyButton.durumButton.basilmadi);
        }
        else if (_count > 0 && !_premiumGunlukCalisiyor && !_premiumGunlukAlinabilir)
        {

            _myBtnPremium.SetDurumButton(MyButton.durumButton.aktifDegil);
            _myButtonAktif = false;

        }
        else
        {
            _myBtnPremium.SetDurumButton(MyButton.durumButton.aktifDegil);

            _myButtonAktif = false;
        }

    }
    private void Update()
    {

        if (_myButtonAktif) return;
        if (PREMIUM.GetPremiumGunlukAlinabilir()) return;
        if (PREMIUM.GetPremiumGunlukCount() <= 0)
        {
            _txtPremium.text = DoThis.GeriSayimGunSonu();

            if (DateTime.Parse("23:46:59") < DateTime.Parse(_txtPremium.text)) IlkAyar();
        }
        else
        {
            if (PREMIUM.GetPremiumGunlukCalisiyor())
            {
                _txtPremium.text = DoThis.GeriSayimFrom(PREMIUM.GetPremiumBitmesineKalanSure()) ;
                _txtPremium.color = Color.green;
            }
            else if(!PREMIUM.GetPremiumGunlukCalisiyor()&& !PREMIUM.GetPremiumGunlukAlinabilir())
            {
                _txtPremium.text = DoThis.GeriSayimFrom(PREMIUM.GetPremiumAlinacakBirSonrakiSure());
                _txtPremium.color = Color.yellow;

            }
            else
            {
                IlkAyar();
                Debug.Log("asd");
            }

            if (PREMIUM.GetPremiumGunlukCalisiyor()) _txtHeader.text = "PREMIUM ON"; else _txtHeader.text = "PREMIUM OFF";
            
        }

        PREMIUM.PremiumSureKontrol();
        if (PREMIUM.GetPremiumGunlukAlinabilir()) IlkAyar();
        if (PREMIUM.GetPremiumGunlukCount() == 5) { IlkAyar(); }

    }

   
    public void EvetntMainMenu()
    {
        if (DoThis.GetMyButtonFromScene("premium")) Destroy(gameObject); else StartCoroutine(AnaMenuyeGit(_delay));
    }

    public void EvetnPremium()
    {
        if (!_myButtonAktif) return;
        if (_reklamVar)
        {
            DateTime temp = DateTime.Now.AddMinutes(0.15f);
            PREMIUM.SetPremiumBitmesineKalanSure(  temp);
             temp = DateTime.Now.AddMinutes(0.25f);

            PREMIUM.SetPremiumAlinacakBirSonrakiSure(temp);
            int tempInt = PREMIUM.GetPremiumGunlukCount();
            tempInt--;
            PREMIUM.SetPremiumGunlukCount(tempInt);
            _count = tempInt;
            PREMIUM.SetPremiumGunlukCalisiyor( true);
            PREMIUM.SetPremiumGunlukAlinabilir( false);
            PREMIUM.DebugAll();
            if (  CanvasUI.instance) CanvasUI.instance.SetSureliPremium(true);
          if(  DoThis.GetMyButtonFromScene("premium")) DoThis.GetMyButtonFromScene("premium").SetDurumButton(MyButton.durumButton.basildi);
            if (CanvasUIMainMenu.instance) CanvasUIMainMenu.instance._premiumButtonAktif = false;
            Invoke(nameof(YokEt), _delayYokEt);
        }else if (_reklamVar)
        {
            //reklam
        }
       

    }



    void YokEt()
    {
        Destroy(gameObject);
    }
    IEnumerator AnaMenuyeGit(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        GoToScene.Hangi(Sahne.MainMenu);
    }
  
}