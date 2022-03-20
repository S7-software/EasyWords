using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] Button _btnCikis;
    [SerializeField] Sahne _sahneCikis;
    [SerializeField] [Range(0f, 3f)] float _delayCikis;
    [SerializeField] Button _btnTekrar;
    [SerializeField] Sahne _sahneTekrar;
    [SerializeField] [Range(0f, 3f)] float _delayTekrar;


    private void Awake()
    {
        AtaButtnlaraHandle();
    }

    private void AtaButtnlaraHandle()
    {
        _btnCikis.onClick.AddListener(() => StartCoroutine(HandleCikis(_delayCikis,_sahneCikis)));
        _btnTekrar.onClick.AddListener(() => StartCoroutine(HandleTekrar(_delayTekrar,_sahneTekrar)));
    }

    IEnumerator HandleCikis(float delayCikis, Sahne sahneCikis)
    {
        yield return new WaitForSeconds(delayCikis);
        GoToScene.Hangi(sahneCikis);
    }
    IEnumerator HandleTekrar(float delayTekrar, Sahne sahneTekrar)
    {
        yield return new WaitForSeconds(delayTekrar);
        GoToScene.Hangi(sahneTekrar);
    }
}
