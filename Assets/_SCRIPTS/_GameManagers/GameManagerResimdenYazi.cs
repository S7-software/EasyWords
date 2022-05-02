using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerResimdenYazi : MonoBehaviour
{
    public static GameManagerResimdenYazi instance;
    string _name;
    [SerializeField] SpriteRenderer _sptRen, _sptRenGolge;
    bool _bulundu = false;

    SecenekKelime[] _secenekler;

    private void Awake()
    {
        _secenekler = FindObjectsOfType<SecenekKelime>();
        instance = this;
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

        CanvasUI.instance.SetUI(Kayit.GetScore(Sahne.EslestirmeResimdenYazi1x5));
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
            CanvasUI.instance.ArttirSayi(true, Sahne.EslestirmeResimdenYazi1x5);
            secenekKelime.Renk(false);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);

            CanvasUI.instance.ArttirSayi(false, Sahne.EslestirmeResimdenYazi1x5);
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
     
            } while (DoThis.Contain(name)&&zamanAsimi<100);
            if (zamanAsimi == 100) Debug.LogError("Zaman Aşımı");
            item.SetSecenek(name); ;
            DoThis.ContainAdd(name);
        }
        _name = secenekler[Random.Range(0, secenekler.Length)]._name;

        _sptRen.sprite = PictureBox.Hangi(_name, false);
        _sptRenGolge.sprite = _sptRen.sprite;
    }

    void BlokSecenekler()
    {
        foreach (var item in _secenekler)
        {
            item._basildi = true;
        }
    }

}