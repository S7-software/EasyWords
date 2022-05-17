using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_SATIN_ALMA : MonoBehaviour
{
    public static UI_SATIN_ALMA instance;
    [SerializeField] MyButton _btnAds, _btnPremium, _btnMenu,_btnAdsPre;
    [SerializeField] TMP_Text _txtAds,_txtPremium,_txtAdsPre;
    [SerializeField] Image _imgAds,_imgPremium,_imgAdsPre;
    [SerializeField] Sprite _iconBtnAdsPreBasarisiz;
    [SerializeField] Text _txtTempAds,_txtTempPre,_txtTempAdsPre;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        SetDurum();
    }


    public void EvetnAds()
    {

    }
    public void EvetnAds(bool basarili)
    {
        SetAdsDurum(basarili);
        AYARLAR.SetReklamVar(  !basarili);
    }
    public void EventPremium()
    {
    }
    public void EventPremium(bool basarili)
    {
        SetPremiumDurum(basarili);
        PREMIUM.SetPremiumVar( basarili);
    }
    public void EventAdsPremium()
    {
    }
    public void EventAdsPremium(bool basarili)
    {
        SetPremiumDurum(basarili);
        PREMIUM.SetPremiumVar(basarili);
    }
    public void EventExit()
    {

        DoThis.GetMyButtonFromScene("satinalma").SetDurumButton(MyButton.durumButton.basilmadi);
        Destroy(gameObject);

    }
  void SetDurum()
    {
        //bool durumAds = !AYARLAR._reklamVar;
        //bool durumPre = AYARLAR._premiumVar;
        bool durumAds = false;
        bool durumPre = false;

        SetAdsDurum(durumAds);
        SetPremiumDurum(durumPre);
        SetAdsPremiumDurum(durumAds, durumPre);

        _txtAds.text = _txtTempAds.text;
        _txtPremium.text = _txtTempPre.text;
        _txtAdsPre.text = _txtTempAdsPre.text;
    }
    void SetAdsDurum(bool satinAlindi)
    {
        if (satinAlindi)
        {
            _btnAds.SetDurumButton(MyButton.durumButton.aktifDegil);
            _btnAds.SetTusIceride(true);
            _txtAds.enabled = false;
            _imgAds.enabled = true;
        }
        else
        {
            _btnAds.SetDurumButton(MyButton.durumButton.basilmadi);
            _txtAds.enabled = true;
            _imgAds.enabled = false;
        }

    }
    void SetPremiumDurum(bool satinAlindi)
    {
        if (satinAlindi)
        {
            _btnPremium.SetDurumButton(MyButton.durumButton.aktifDegil);
            _btnPremium.SetTusIceride(true);
            _txtPremium.enabled = false;
            _imgPremium.enabled = true;
        }
        else
        {
            _btnPremium.SetDurumButton(MyButton.durumButton.basilmadi);
            _txtPremium.enabled = true;
            _imgPremium.enabled = false;
        }

    }
    void SetAdsPremiumDurum(bool satinAlindiAds,bool satinAlindiPre)
    {
        if (satinAlindiAds&&satinAlindiPre)
        {
            _btnAdsPre.SetDurumButton(MyButton.durumButton.aktifDegil);
            _btnAdsPre.SetTusIceride(true);
            _txtAdsPre.enabled = false;
            _imgAdsPre.enabled = true;
        }else if ((!satinAlindiPre && satinAlindiAds) || (satinAlindiPre && !satinAlindiAds))
        {
            _btnAdsPre.SetDurumButton(MyButton.durumButton.aktifDegil);
            _btnAdsPre.SetTusIceride(true);
            _btnAdsPre.SetIcon(_iconBtnAdsPreBasarisiz);
            _txtAdsPre.enabled = false;
            _imgAdsPre.enabled = true;
        }
        else
        {
            _btnAdsPre.SetDurumButton(MyButton.durumButton.basilmadi);
            _txtAdsPre.enabled = true;
            _imgAdsPre.enabled = false;
        }

    }



}
