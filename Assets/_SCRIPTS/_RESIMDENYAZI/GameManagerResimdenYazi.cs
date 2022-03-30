﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerResimdenYazi : MonoBehaviour
{
    public static GameManagerResimdenYazi instance;
    string _name;
    [SerializeField] SpriteRenderer _sptRen ;
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
        CanvasUI.instance.SetUI(15, 15, 0, 0);
    }

    private void Update()
    {
        if (!_bulundu) return;
        if (SoundBox.instance.IsPlaying()) return;
        _bulundu = false;
        SetGame(_secenekler);

    }

    public void Kontrol(string name,SecenekKelime secenekKelime)
    {
        if (name==_name)
        {
            
            SoundBox.instance.StopAndPlayOneShot(name);
            _bulundu = true;
            BlokSecenekler();
            CanvasUI.instance.ArttirSayi(true);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);

            CanvasUI.instance.ArttirSayi(false);
            secenekKelime.Renk(true);

        }
    }

    

    void SetGame(SecenekKelime[] secenekler)
    {
        
        foreach (var item in secenekler)
        {
            item.SetSecenek(GetListOfWords.RasgeleUniq());
            
        }
        _name = secenekler[Random.Range(0, secenekler.Length)]._name;

        _sptRen.sprite = PictureBox.Hangi(_name, false);

    }

    void BlokSecenekler()
    {
        foreach (var item in _secenekler )
        {
            item._basildi = true;
        }
    }
  
}