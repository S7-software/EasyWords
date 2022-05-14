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
        AYARLAR.Load();
        AYARLAR.DebugAllData();
        AYARLAR.PremiumSureKontrol();
        AYARLAR.DebugAllData();

        if( (TEMP._gidilecekSahne == Sahne.Harfler || TEMP._gidilecekSahne == Sahne.Sayilar ||
            TEMP._secilenCategorie == Categories.Karisik || AYARLAR._premiumVar||AYARLAR._premiumGunlukCalisiyor)&&SceneManager.GetActiveScene().name!=Sahne.MainMenu.ToString())
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
        AYARLAR.DebugAllData();
    
        _count = AYARLAR._premiumGunlukCount;
        _reklamVar = AYARLAR._reklamVar;
        _premiumGunlukCalisiyor = AYARLAR._premiumGunlukCalisiyor;
        _premiumGunlukAlinabilir= AYARLAR._premiumGunlukAlinabilir;

    
        if (_premiumGunlukCalisiyor)
        {
            _myButtonAktif = false;
            _myBtnPremium.SetDurumButton(MyButton.durumButton.aktifDegil);
        }

        if (_count > 0 && !_premiumGunlukCalisiyor&&_premiumGunlukAlinabilir)
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
        AYARLAR.DebugAllData();

    }
    private void Update()
    {

        if (_myButtonAktif) return;

        if (AYARLAR._premiumGunlukCount <= 0)
        {
            _txtPremium.text = DoThis.GeriSayimGunSonu();

            if (DateTime.Parse("23:46:59") < DateTime.Parse(_txtPremium.text)) IlkAyar();
        }
        else
        {
            if (AYARLAR._premiumGunlukCalisiyor)
            {
                _txtPremium.text = DoThis.GeriSayimFrom(AYARLAR._premiumBitmesineKalanSure);
                _txtPremium.color = Color.green;
            }
            else {
                _txtPremium.text = DoThis.GeriSayimFrom(AYARLAR._premiumAlinacakBirSonrakiSure);
                _txtPremium.color = Color.yellow;

            }

            if (AYARLAR._premiumGunlukCalisiyor) _txtHeader.text = "PREMIUM ON"; else _txtHeader.text = "PREMIUM OFF";
            if (DateTime.Parse("23:46:59") < DateTime.Parse(_txtPremium.text)) IlkAyar();
        }
        AYARLAR.PremiumSureKontrol();
        if (AYARLAR._premiumGunlukCount == 5) { IlkAyar(); }
        
    }

   
    public void EvetntMainMenu()
    {
        StartCoroutine(AnaMenuyeGit(_delay));
    }

    public void EvetnPremium()
    {
        AYARLAR.DebugAllData();

        if (!_myButtonAktif) return;
        if (_reklamVar)
        {
            DateTime temp = DateTime.Now.AddMinutes(0.15f);
            AYARLAR._premiumBitmesineKalanSure = temp.TimeOfDay.ToString();
             temp = DateTime.Now.AddMinutes(0.25f);

            AYARLAR._premiumAlinacakBirSonrakiSure = temp.TimeOfDay.ToString();
            AYARLAR._premiumGunlukCount--;
            _count = AYARLAR._premiumGunlukCount;
            AYARLAR._premiumGunlukCalisiyor = true;
            AYARLAR._premiumGunlukAlinabilir = false;
            AYARLAR.Save();
          if(  CanvasUI.instance) CanvasUI.instance.SetSureliPremium(true);
          if(  DoThis.GetMyButtonFromScene("premium")) DoThis.GetMyButtonFromScene("premium").SetDurumButton(MyButton.durumButton.basildi);
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
