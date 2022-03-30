﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerSestenResim : MonoBehaviour
{
   public static GameManagerSestenResim instance;
    [SerializeField] Button _btnSes;
    SecenekResim[] _secenekResims;
    string _name;
    bool _bulundu = false;
    private void Awake()
    {
        instance = this;
        _secenekResims = FindObjectsOfType<SecenekResim>();
        _btnSes.onClick.AddListener(HandleSes);
    }

   

    private void Start()
    {
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
        CanvasUI.instance.SetUI(15, 15, 0, 0);
    }

    void SetGame(SecenekResim[] secenekResims)
    {
        foreach (var item in secenekResims)
        {
            item.SetSecenek(GetListOfWords.RasgeleUniq());
        }
        _name = secenekResims[Random.Range(0, secenekResims.Length)]._name;
       Invoke( "HandleSes",0.4f);
    }

    public void Kontrol(string name, SecenekResim secenekResim)
    {
        if (name == _name)
        {
            RemoveAllHandle();
            SoundBox.instance.StopAndPlayOneShot(name);

            _bulundu = true;
            CanvasUI.instance.ArttirSayi(true);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);
            secenekResim.Renk(true);
            CanvasUI.instance.ArttirSayi(false);

        }
    }
    private void HandleSes()
    {
        SoundBox.instance.PlayIfDontPlay(_name);
    }
    void RemoveAllHandle()
    {
        foreach (var item in _secenekResims)
        {
            item._basildi = true;
        }
    }
}