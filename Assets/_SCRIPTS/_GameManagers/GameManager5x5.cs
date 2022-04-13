﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameManager5x5 : MonoBehaviour
{
    public static GameManager5x5 instance;
    int countBulunma = 0;
    SecenekResim5x _tempResim = null;
    SecenekYazi5x _tempYazi = null;
    SecenekResim5x[] _secenekResim5Xes;
    SecenekYazi5x[] _secenekYazi5Xes;

    public Color[] _colors;
    private void Awake()
    {
        instance = this;
        _secenekResim5Xes = FindObjectsOfType<SecenekResim5x>();
        _secenekYazi5Xes = FindObjectsOfType<SecenekYazi5x>();

    }
    private void Start()
    {
        SetScore();
        SetOyun();
    }
    private void SetScore()
    {
        if (Kayit.IsYeniGun()) Kayit.ResetGun();
        if (Kayit.IsYeniHafta()) Kayit.ResetHafta();

        CanvasUI.instance.SetUI(Kayit.GetScore(Sahne.Eslestirme5x5));
    }

    public void Kontrol(SecenekResim5x secenekResim5X)
    {
        if (_tempYazi != null)
        {
            KontrolCift(secenekResim5X, _tempYazi);

        }
        else if (_tempResim == null)
        {
            _tempResim = secenekResim5X;
        }
        else if (_tempResim != null)
        {
            _tempResim = secenekResim5X;
            KapaSecenekleriResim(secenekResim5X);
        }
        else
        {

        }
    }
    public void Kontrol(SecenekYazi5x secenekYazi5X)
    {
        Debug.Log("Kontrole girdi");
        if (_tempResim != null)
        {
            Debug.Log("_tempResim != null girdi");

            KontrolCift(_tempResim, secenekYazi5X);
        }
        else if (_tempYazi == null)
        {
            Debug.Log("_tempYazi == null girdi");
            _tempYazi = secenekYazi5X;
        }
        else if (_tempYazi != null)
        {
        Debug.Log("_tempYazi != null girdi");
            _tempYazi = secenekYazi5X;
            KapaSecenekleriYazi(_tempYazi);
        }
        else
        {

        }
    }
    void KapaSecenekleriResim(SecenekResim5x secenekResim5X)
    {
        foreach (var item in _secenekResim5Xes)
        {
            if (secenekResim5X != item && !item._bulundu) item.Basildi(false);
        }
    }

    void KapaSecenekleriYazi(SecenekYazi5x secenekYazi5X)
    {
        foreach (var item in _secenekYazi5Xes)
        {
            if (secenekYazi5X != item && !item._bulundu) item.Basildi(false);
        }
    }
    void KapaSeceneklerBulunmamislar()
    {
        _tempYazi = null;
        _tempResim = null;
        foreach (var item in _secenekResim5Xes)
        {
            if (!item._bulundu) item.Basildi(false);
        }

        foreach (var item in _secenekYazi5Xes)
        {
            if (!item._bulundu) item.Basildi(false);
        }
    }

    void KontrolCift(SecenekResim5x secenekResim5X, SecenekYazi5x secenekYazi5X)
    {
        if (secenekYazi5X._name == secenekResim5X._name)
        {
            secenekResim5X.Bulundu(true);
            secenekYazi5X.Bulundu(true);
            countBulunma++;
            SoundBox.instance.StopAndPlayOneShot(secenekResim5X._name);
            if (countBulunma == 5)
            {
                SetOyun();
            }
            CanvasUI.instance.ArttirSayi(true, Sahne.Eslestirme5x5);
            _tempResim = null;
            _tempYazi = null;
        }
        else
        {
            CanvasUI.instance.ArttirSayi(false, Sahne.Eslestirme5x5);
            KapaSeceneklerBulunmamislar();
        }
    }

    private void SetOyun()
    {
        List<Color> _colorsList = new List<Color>();
        foreach (var item in _colors)
        {
            _colorsList.Add(item);
        }
        List<string> _tempName1 = GetListOfWords.Rasgele5Kelime();
        List<string> _tempName2 = GetListOfWords.YeniList(_tempName1);



        foreach (var item in _secenekResim5Xes)
        {
            item.SetSecenek(_tempName1[UnityEngine.Random.Range(0, _tempName1.Count)]);
            _tempName1.Remove(item._name);
        }

        foreach (var item in _secenekYazi5Xes)
        {
            Color tempColor = _colorsList[UnityEngine.Random.Range(0, _colorsList.Count)];

            item.SetSecenek(_tempName2[UnityEngine.Random.Range(0, _tempName2.Count)],tempColor);
            _tempName2.Remove(item._name);
            _colorsList.Remove(tempColor);
        }
        countBulunma = 0;

    }
}