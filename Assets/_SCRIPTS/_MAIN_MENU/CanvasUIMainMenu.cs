using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] Sprite[] _iconsOfStat;
    public GameObject _menuCategorie;
    bool _isStatOpen = false;
    private void Awake()
    {
        instance = this;
        _goStats.SetActive(false);
        _statButton.SetIcon(_iconsOfStat[0]);
    }

    

    public void HandleCikis()
    {
        Application.Quit();
    }

    IEnumerator SahneGecis(float delay,Sahne sahne)
    {
        yield return new WaitForSeconds(delay);
        GoToScene.Hangi(sahne);
    }



    public void EventUpStat()
    {
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
