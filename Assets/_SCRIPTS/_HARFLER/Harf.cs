using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Harf : MonoBehaviour
{
    [SerializeField] string _harf;
    [SerializeField] SpriteRenderer _sptRen;
    bool _isPlaying = false;

   

    private void Update()
    {
        if (!_isPlaying) return;
        if (SoundBox.instance.IsPlaying()) return;
        _isPlaying = false;
        SetClick(_harf, false);
    }

    public void Click()
    {
    
        if (SoundBox.instance.IsPlaying()) return;
        SetClick(_harf, true);
        SoundBox.instance.PlayOneShot(_harf);
        _isPlaying = true;
    }


    void SetClick(string harf,bool active) { _sptRen.sprite = PictureBox.HangiHarf(harf, active); }
    public void SetHarf(string harf) { _harf = harf;SetClick(_harf, false); }
    
}
