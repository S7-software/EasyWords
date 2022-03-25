using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIMainMenu : MonoBehaviour
{

    [SerializeField] Button _btnEslestirme5x5, _btnEslestirmeYazidanResim1x5,
        _btnEslestirmeResimdenYazi1x5, _btnEslestirmeSestenYazi1x5, _btnEslestirmeSestenResim1x5,_btnHarfler,
        _btnCikis;
    [SerializeField] [Range(0f, 3f)] float _delay=0f;
    private void Awake()
    {
        ButtonlaraHandleAta();
    }

    private void ButtonlaraHandleAta()
    {
        _btnEslestirme5x5.onClick.AddListener(()=>StartCoroutine(SahneGecis(_delay,Sahne.Eslestirme5x5)));
        _btnEslestirmeYazidanResim1x5.onClick.AddListener(()=>StartCoroutine(SahneGecis(_delay,Sahne.EslestirmeYazidanResim1x5)));
        _btnEslestirmeResimdenYazi1x5.onClick.AddListener(()=>StartCoroutine(SahneGecis(_delay,Sahne.EslestirmeResimdenYazi1x5)));
        _btnEslestirmeSestenYazi1x5.onClick.AddListener(()=>StartCoroutine(SahneGecis(_delay,Sahne.EslestirmeSestenYazi1x5)));
        _btnEslestirmeSestenResim1x5.onClick.AddListener(()=>StartCoroutine(SahneGecis(_delay,Sahne.EslestirmeSestenResim1x5)));
        _btnHarfler.onClick.AddListener(()=>StartCoroutine(SahneGecis(_delay,Sahne.Harfler)));
        _btnCikis.onClick.AddListener(HandleCikis);
    }

    private void HandleCikis()
    {
        Application.Quit();
    }

    IEnumerator SahneGecis(float delay,Sahne sahne)
    {
        yield return new WaitForSeconds(delay);
        GoToScene.Hangi(sahne);
    }
}
