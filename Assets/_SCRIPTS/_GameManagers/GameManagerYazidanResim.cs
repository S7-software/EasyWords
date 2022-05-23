using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerYazidanResim : MonoBehaviour
{
  public static  GameManagerYazidanResim instance;
    [SerializeField] TMP_Text _txtName;
   [SerializeField] Color[] _colors;
    SecenekResim[] _secenekResims;
    string _name;
    bool _bulundu = false;

    int _gunlukYanlis, _gunlukDogru,
        _haftalikYanlis, _haftalikDogru;
    private void Awake()
    {
        instance = this;
        _secenekResims = FindObjectsOfType<SecenekResim>();
    }



    private void Start()
    {
        AdControl.instance.CloseBanner();
        SetScore();
        SetGame(_secenekResims);
    }
    private void Update()
    {
        if (!_bulundu) return;
        if (SoundBox.instance.IsPlaying()) return;
        _bulundu = false;
        SetGame(_secenekResims);

    }
    private void SetScore()
    {
        if (Kayit.IsYeniGun()) Kayit.ResetGun();
        if (Kayit.IsYeniHafta()) Kayit.ResetHafta();
        CanvasUI.instance.SetUI(Kayit.GetScore(Sahne.EslestirmeYazidanResim1x5));

    }

    void SetGame(SecenekResim[] secenekResims)
    {
        AdControl.instance.ShowGecis();
        DoThis.ContainReset();
        foreach (var item in secenekResims)
        {
            string name;
            int zamanAsimi = 0;
            do
            {
                zamanAsimi++;
                name = GetListOfWords.RasgeleUniq(TEMP._secilenCategorie);

            } while (DoThis.Contain(name) && zamanAsimi < 100);
            if (zamanAsimi == 100) Debug.LogError("Zaman Aşımı");
            item.SetSecenek(name); ;
            DoThis.ContainAdd(name);
        }
        //foreach (var item in secenekResims)
        //{
        //    item.SetSecenek(GetListOfWords.RasgeleUniq(TEMP._secilenCategorie));
        //}
        _name = secenekResims[Random.Range(0, secenekResims.Length)]._name;
        _txtName.text = _name;
        _txtName.color = _colors[Random.Range(0,_colors.Length  )];
    }

    public void Kontrol(string name, SecenekResim secenekResim)
    {
        if (name == _name)
        {
            RemoveAllHandle();
            SoundBox.instance.StopAndPlayOneShot(name);
            secenekResim.Renk(true);

            _bulundu = true;
            CanvasUI.instance.ArttirSayi(true, Sahne.EslestirmeYazidanResim1x5);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);
            secenekResim.Renk(false);
            CanvasUI.instance.ArttirSayi(false, Sahne.EslestirmeYazidanResim1x5);

        }
    }
   
    void RemoveAllHandle()
    {
        foreach (var item in _secenekResims)
        {
            item._basildi = true;
        }
    }
}
