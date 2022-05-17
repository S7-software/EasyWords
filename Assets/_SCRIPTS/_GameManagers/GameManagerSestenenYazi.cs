using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerSestenenYazi : MonoBehaviour
{
    public static GameManagerSestenenYazi instance;
    string _name;
    bool _bulundu = false;
    [SerializeField] Button _btnSes;
    SecenekKelime[] _secenekler;

    private void Awake()
    {
        
        instance = this;
        _secenekler = FindObjectsOfType<SecenekKelime>();
        _btnSes.onClick.AddListener(HandleSes);
    }
    private void Start()
    {
        SetGame(_secenekler);
        SetScore();
    }

    private void SetScore()
    {
        if (Kayit.IsYeniGun()) Kayit.ResetGun();
        if (Kayit.IsYeniHafta()) Kayit.ResetHafta();
        CanvasUI.instance.SetUI(Kayit.GetScore(Sahne.EslestirmeSestenYazi1x5));
    }

    private void Update()
    {
        if (!_bulundu) return;
        if (SoundBox.instance.IsPlaying()) return;
        _bulundu = false;
        SetGame(_secenekler);

    }

    public void Kontrol(string name, SecenekKelime secenekKelime)
    {
        if (name == _name)
        {

            SoundBox.instance.StopAndPlayOneShot(name);
            _bulundu = true;
            BlokSecenekler();
            CanvasUI.instance.ArttirSayi(true, Sahne.EslestirmeSestenYazi1x5);
            secenekKelime.Renk(false);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);

            CanvasUI.instance.ArttirSayi(false, Sahne.EslestirmeSestenYazi1x5);
            secenekKelime.Renk(true);

        }
    }



    void SetGame(SecenekKelime[] secenekler)
    {
        DoThis.ContainReset();
        foreach (var item in secenekler)
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
        
        //foreach (var item in secenekler)
        //{
        //    item.SetSecenek(GetListOfWords.RasgeleUniq(TEMP._secilenCategorie));

        //}
        _name = secenekler[Random.Range(0, secenekler.Length)]._name;
      Invoke("HandleSes", 0.4f);

    }

    void BlokSecenekler()
    {
        foreach (var item in _secenekler)
        {
            item._basildi = true;
        }
    }

    private void HandleSes()
    {
        SoundBox.instance.PlayIfDontPlay(_name);
    }

}