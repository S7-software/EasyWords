using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnMenu : MonoBehaviour
{
    [SerializeField] Sahne _gidilecekSahne;
    [SerializeField] Sprite[] _sptsOfBtn;
    [SerializeField] Image _imgGolge,_imgBtn;
    [SerializeField] GameObject _goBtnResim;
    [SerializeField] Color[] _colors;
    [SerializeField] Vector3 _konumDonwResim;
    [SerializeField][Range(0f,3f)] float _delay;

    private void Awake()
    {
        
        StartButton();
    }

    private void StartButton()
    {
        _imgBtn.sprite = _sptsOfBtn[0];
        _imgBtn.color = _colors[0];
        _imgGolge.enabled = true;
        _goBtnResim.transform.localPosition = Vector3.zero;


    }

    public void ButtonDown()
    {
        _imgBtn.sprite = _sptsOfBtn[1];
        _imgBtn.color = _colors[1];
        _imgGolge.enabled = false;
        _goBtnResim.transform.localPosition = _konumDonwResim;
       
    }
    public void ButtonUp()
    {
        StartButton();
      //  Invoke(nameof(SahneyeGit), _delay);
    }

    void SahneyeGit()
    {
        GoToScene.Hangi(_gidilecekSahne);
    }
}
