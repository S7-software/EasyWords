using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DEBUG : MonoBehaviour
{
    [SerializeField] Button _btnButunVerileriSil,_btnKapat,_btnIntro,
        _btnPremiumCalisiyor,
        _btnPremiumGunlukAlinabilir,
        _btnPremiumGunlukCount,
        _btnPremiumAlinacakBirSonrakiSure,
        _btnPremiumBitmesineKalanSure,
        _btnPremiumBirSonrakiGun,
        _btnReklam
        ;
    [SerializeField] TMP_Text _txtDebug;

    private void Awake()
    {

        DebugText();
        _btnButunVerileriSil.onClick.AddListener(HandleButunVerileriSil);
        _btnKapat.onClick.AddListener(HandleKapat);
        _btnIntro.onClick.AddListener(HandleIntro);
        _btnPremiumCalisiyor.onClick.AddListener(HandlePremiumCalisiyor);
        _btnPremiumGunlukAlinabilir.onClick.AddListener(HandlenPremiumGunlukAlinabilir);
        _btnPremiumGunlukCount.onClick.AddListener(HandlePremiumGunlukCount);
        _btnPremiumAlinacakBirSonrakiSure.onClick.AddListener(HandlePremiumAlinacakBirSonrakiSure);
        _btnPremiumBitmesineKalanSure.onClick.AddListener(HandlePremiumBitmesineKalanSure);
        _btnPremiumBirSonrakiGun.onClick.AddListener(HandlePremiumBirSonrakiGun);
        _btnReklam.onClick.AddListener(HandleReklamVar);

        ButtonIsimleriYazdir(_btnButunVerileriSil,
            _btnKapat,
            _btnIntro,
            _btnPremiumCalisiyor,
            _btnPremiumGunlukAlinabilir,
            _btnPremiumGunlukCount,
            _btnPremiumAlinacakBirSonrakiSure,
            _btnPremiumBitmesineKalanSure,
            _btnPremiumBirSonrakiGun, _btnReklam
            );
    }

    private void HandleReklamVar()
    {
        AYARLAR.SetReklamVar(!AYARLAR.GetReklamVar());
        DebugText();
    }

    private void HandleIntro()
    {
        GoToScene.Hangi(Sahne.Intro);
    }

    private void HandleKapat()
    {
        Destroy(gameObject);
    }

    private void HandleButunVerileriSil()
    {
        PlayerPrefs.DeleteAll();
    }

    void HandlePremiumCalisiyor()
    {
        PREMIUM.SetPremiumGunlukCalisiyor(!PREMIUM.GetPremiumGunlukCalisiyor());
        DebugText();
    }
    void HandlenPremiumGunlukAlinabilir()
    {
        PREMIUM.SetPremiumGunlukAlinabilir(!PREMIUM.GetPremiumGunlukAlinabilir());
        DebugText();
    }
    void HandlePremiumGunlukCount()
    {
        PREMIUM.SetPremiumGunlukCount(PREMIUM.GetPremiumGunlukCount()<=4?5:0);
        DebugText();
    }
    void HandlePremiumAlinacakBirSonrakiSure()
    {
        PREMIUM.SetPremiumAlinacakBirSonrakiSure(PREMIUM.GetPremiumAlinacakBirSonrakiSure().AddHours(-1));
        DebugText();
    }
    void HandlePremiumBitmesineKalanSure()
    {
        PREMIUM.SetPremiumBitmesineKalanSure(PREMIUM.GetPremiumBitmesineKalanSure().AddHours(-1));
        DebugText();
    }
    void HandlePremiumBirSonrakiGun()
    {
        PREMIUM.SetPremiumBirSonrakiGun(PREMIUM.GetPremiumBirSonrakiGun().AddDays(-2));
        DebugText();
    }

    void DebugText()
    {
        _txtDebug.text = "PremiumVar(): " + PREMIUM.GetPremiumVar() +
            "\nReklamVar(): " + AYARLAR.GetReklamVar() +
            "\nPremiumGunlukCalisiyor(): " + PREMIUM.GetPremiumGunlukCalisiyor() +
            "\nPremiumGunlukAlinabilir(): " + PREMIUM.GetPremiumGunlukAlinabilir() +
            "\nPremiumGunlukCount(): " + PREMIUM.GetPremiumGunlukCount() +
            "\n\nPremiumAlinacakBirSonrakiSure()\n " + PREMIUM.GetPremiumAlinacakBirSonrakiSure() +
            "\n\nPremiumBitmesineKalanSure()\n " + PREMIUM.GetPremiumBitmesineKalanSure() +
            "\n\nPremiumBirSonrakiGun()\n " + PREMIUM.GetPremiumBirSonrakiGun().Date
            ;
    }
    void ButtonIsimleriYazdir(params Button[] buttonlar)
    {
        foreach (var item in buttonlar)
        {
            item.gameObject.GetComponentInChildren<TMP_Text>().text = item.name;
        }
    }
}
