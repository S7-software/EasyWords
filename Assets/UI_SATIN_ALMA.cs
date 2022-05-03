using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_SATIN_ALMA : MonoBehaviour
{
    [SerializeField] MyButton _btnAds, _btnPremium, _btnMenu;
    [SerializeField] TMP_Text _txtAds,_txtPremium;
    [SerializeField] Image _imgAds,_imgPremium;

    private void Awake()
    {
      

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

    }
    public void EventPremium()
    {
    }
    public void EventPremium(bool basarili)
    {
    }
    public void EventExit()
    {

        DoThis.GetMyButtonFromScene("satinalma").SetDurumButton(MyButton.durumButton.basilmadi);
        Destroy(gameObject);

    }
  void SetDurum()
    {
        SetAdsDurum(true);
        SetPremiumDurum(true);
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



}
