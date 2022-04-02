using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SayilarSes : MonoBehaviour
{
    [SerializeField] Color[] _colors;
    public   Button _myBtn;
    string _name;
    bool _isPlaying = false;
    TMP_Text _txt;
    private void Awake()
    {
        _txt = GetComponent<TMP_Text>();
        _name = _txt.text;
        _myBtn = GetComponent<Button>();

        _colors[0] = _txt.color;
        _colors[1] = new Color(_colors[0].r, _colors[0].g, _colors[0].b, _myBtn.colors.pressedColor.a);
        _myBtn.onClick.AddListener(handle);
    }

    private void handle()
    {
        SoundBox.instance.PlayIfDontPlay(_name);
        _isPlaying = true;
        GameManagerSayilar.instance.ButtonlarSetInc(false);
        _txt.color = _colors[1];
    }
    private void Update()
    {
        if (!_isPlaying) return;
        if (SoundBox.instance.IsPlaying()) return;
        _isPlaying = false;
        GameManagerSayilar.instance.ButtonlarSetInc(true);
        _txt.color = _colors[0];





    }
}
