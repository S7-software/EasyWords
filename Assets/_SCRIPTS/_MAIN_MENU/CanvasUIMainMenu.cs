using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIMainMenu : MonoBehaviour
{
    public static CanvasUIMainMenu instance;
    [SerializeField] [Range(0f, 3f)] float _delay=0f;
    [SerializeField] GameObject _goStats;
    [SerializeField] CardOfStatus _resimdenYazi, _sestenYazi, _sestenResim, _yazidanResim, _besX5,_hepsi;
    [Header("Stat Button")]
    
    [SerializeField] MyButton _statButton;
    [SerializeField] MyButton _myBtnPremium;
    [SerializeField] TMP_Text _txtPremium;
    [SerializeField] Sprite[] _iconsOfStat;
    public GameObject _menuCategorie;
    bool _isStatOpen = false;
  public  bool _premiumButtonAktif = true;
    private void Awake()
    {
        TEMP._gidilecekSahne = Sahne.MainMenu;
        instance = this;
        _goStats.SetActive(false);
        _statButton.SetIcon(_iconsOfStat[0]);
    }

    private void Start()
    {
        
    
            SetButtonPremium();
    }
    private void LateUpdate()
    {
          if(!_myBtnPremium.GetDurumButtonBasilabilir()&& !_premiumButtonAktif
            )
        {
            if (PREMIUM.GetPremiumGunlukCalisiyor())
            {
                _txtPremium.text = DoThis.GeriSayimFrom(PREMIUM.GetPremiumBitmesineKalanSure());
                _txtPremium.color = Color.green;
                PREMIUM.PremiumSureKontrol();
            }
            else if (!PREMIUM.GetPremiumGunlukAlinabilir())
            {
                _txtPremium.text = DoThis.GeriSayimFrom(PREMIUM.GetPremiumAlinacakBirSonrakiSure());
                _txtPremium.color = Color.yellow;
                PREMIUM.PremiumSureKontrol();

            }
            else if(PREMIUM.GetPremiumGunlukAlinabilir())
            {
                _premiumButtonAktif = true;
                SetButtonPremium();
                
            }
        }
    }

    void SetButtonPremium()
    {
        if (PREMIUM.GetPremiumVar())
        {
            _myBtnPremium.gameObject.SetActive(false); return;
        }

        if (PREMIUM.GetPremiumGunlukCalisiyor()|| !PREMIUM.GetPremiumGunlukAlinabilir())
        {
            _myBtnPremium.SetDurumButton(MyButton.durumButton.basildi);
        }
        else if(PREMIUM.GetPremiumGunlukAlinabilir())
        {
            _txtPremium.text = "PREMIUM\n("+ PREMIUM.GetPremiumGunlukCount()+")";
            _txtPremium.color = Color.yellow;
            _myBtnPremium.SetDurumButton(MyButton.durumButton.basilmadi);
        }
        else 
        {
            _myBtnPremium.SetDurumButton(MyButton.durumButton.basildi);
           

        }
     
    }

    public void EventPremium()
    {
        if (FindObjectOfType<btnMenuKategori>()) return;
        if (PREMIUM.GetPremiumGunlukCount() <= 0) return;
        Instantiate(GetObje.Hangi(GetObje.objeName.UI_PREMIUM));
    }
    public void HandleCikis()
    {
        if (FindObjectOfType<btnMenuKategori>()) return;
        Application.Quit();
    }

    IEnumerator SahneGecis(float delay,Sahne sahne)
    {
        yield return new WaitForSeconds(delay);
        GoToScene.Hangi(sahne);
    }


    public void EventAyarlar()
    {
        if (FindObjectOfType<btnMenuKategori>()) return;
        Instantiate(GetObje.Hangi(GetObje.objeName.UI_AYARLAR));
    }

    public void EventSatinAlma()
    {
        if (FindObjectOfType<btnMenuKategori>()) return;
        Instantiate(GetObje.Hangi(GetObje.objeName.UI_SATIN_ALMA));
    }
    public void EventUpStat()
    {
        if (FindObjectOfType<btnMenuKategori>()) return;
        if (_isStatOpen)
        {
        _statButton.SetIcon(_iconsOfStat[0]);
            _statButton.SetDurumButton(MyButton.durumButton.basilmadi);

            _goStats.SetActive(false);
            _isStatOpen = false;
        }
        else
        {
            _statButton.SetIcon(_iconsOfStat[1]);
            KayitlariCekVeAta();

            _goStats.SetActive(true);
           
            _isStatOpen = true;
        }
    }
    void KayitlariCekVeAta()
    {
        AllStatusOfType allStatusOfType = Kayit.GetScore(Sahne.EslestirmeResimdenYazi1x5);
        Ata(allStatusOfType, _resimdenYazi);
         allStatusOfType = Kayit.GetScore(Sahne.EslestirmeSestenYazi1x5);
        Ata(allStatusOfType, _sestenYazi);
         allStatusOfType = Kayit.GetScore(Sahne.EslestirmeSestenResim1x5);
        Ata(allStatusOfType, _sestenResim);
         allStatusOfType = Kayit.GetScore(Sahne.EslestirmeYazidanResim1x5);
        Ata(allStatusOfType, _yazidanResim);
        allStatusOfType = Kayit.GetScore(Sahne.Eslestirme5x5);
        Ata(allStatusOfType, _besX5);
        _hepsi.SetCardOfStatus(0, 0, 0, 0, allStatusOfType.ToplamHepsiDogru, allStatusOfType.ToplamHepsiYanlis);
    }
    void Ata(AllStatusOfType allStatusOfType,CardOfStatus cardOfStatus)
    {
        cardOfStatus.SetCardOfStatus(
            allStatusOfType.GunDogru,
            allStatusOfType.GunYanlis,
            allStatusOfType.HaftaDogru,
            allStatusOfType.HaftaYanlis,
            allStatusOfType.ToplamDogru,
            allStatusOfType.ToplamYanlis
            );
    }
}
