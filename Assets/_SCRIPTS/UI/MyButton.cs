using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    public Action _handle;
    [SerializeField] Vector3 _konumV3;
    [SerializeField] durumButton _durum;
    [SerializeField] GameObject _konum;
    [SerializeField] Image _imgBtn, _imgGolge,_imgIcon;
    [SerializeField] Sprite[] _sptsOfButton;

    Color _colorIcon;
    public enum durumButton { aktifDegil, basilmadi, basildi }
    bool _isActive = true;
    private void Awake()
    {
        _colorIcon = _imgIcon.color;
        //SetDurumButton(_durum);
    }



    public void EvetnUp()
    {
        if (!_isActive) return;
       // SetDurumButton(durumButton.basilmadi);
        //SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);

    }
    public void EvetnDown()
    {
        if (!_isActive) return;
        SoundBox.instance.PlayOneShot(NamesOfSound.bas);
        SetDurumButton(durumButton.basildi);

    }




    public void SetDurumButton(durumButton durum)
    {
        _imgIcon.color= (durum == durumButton.aktifDegil)?new Color(_colorIcon.r,_colorIcon.g,_colorIcon.b,0.5f):_colorIcon;
        _imgBtn.sprite = _sptsOfButton[((int)durum)];
        _konum.transform.localPosition = durum == durumButton.basildi ? _konumV3 : Vector3.zero;
        _isActive = !(durum == durumButton.aktifDegil);
        _imgGolge.enabled = (durum == durumButton.basilmadi);

    }

}
