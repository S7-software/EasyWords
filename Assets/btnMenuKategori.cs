using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnMenuKategori : MonoBehaviour
{
    [SerializeField] bool _isActive = true;
    [SerializeField] Categories _categorie;
    [SerializeField] Sprite[] _sptsOfBtn;
    [SerializeField] Image _imgGolge, _imgBtn;
    [SerializeField] Image[] _imgIcon, _imgIconGolge;
    [SerializeField] GameObject _goBtnResim;
    [SerializeField] Color[] _colors;
    [SerializeField] Vector3 _konumDonwResim;
    [SerializeField] [Range(0f, 3f)] float _delay;

    private void Awake()
    {
        //_isActive = AYARLAR._premiumVar||_categorie==Categories.Karisik;
        StartButton();
    }

    private void StartButton()
    {
        _imgBtn.sprite = _sptsOfBtn[0];
        _imgBtn.color = _isActive ? _colors[0] : _colors[1];
        SetIcon(_isActive,_imgIcon,_imgIconGolge);
        _imgGolge.enabled = _isActive;
        _goBtnResim.transform.localPosition = Vector3.zero;


    }

    private void SetIcon(bool isActive, Image[] imgIcon,Image[] imgIconGolge)
    {
        if (isActive) return;
        foreach (var item in imgIcon)
        {
            item.color = _colors[1];
        }
        foreach (var item in imgIconGolge)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void ButtonDown()
    {
        if (!_isActive) return;
        SoundBox.instance.PlayOneShot(NamesOfSound.bas);
        _imgBtn.sprite = _sptsOfBtn[1];
        // _imgBtn.color = _colors[1];
        _imgGolge.enabled = false;
        _goBtnResim.transform.localPosition = _konumDonwResim;

    }
    public void ButtonUp()
    {
        if (!_isActive) return;
        //SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);
        TEMP._secilenCategorie = _categorie;
        Invoke(nameof(SahneyeGit), _delay);
    }

    void SahneyeGit()
    {
        
        GoToScene.Hangi(TEMP._gidilecekSahne);
    }

}
