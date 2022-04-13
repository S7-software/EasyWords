using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SecenekKelime : MonoBehaviour
{
    [SerializeField] [Range(0f, 3f)] float _delay;
    [SerializeField] TMP_Text _txt;
    [SerializeField] Image _imgBtn, _imgBtnGolge;
    [SerializeField] GameObject _goKonum;
    [SerializeField] Vector3 _konumAktif;
    [SerializeField] Color[] _colors;
    [SerializeField] Sprite[] _sptsOfBtn;
    public string _name;
   public bool _basildi = false;


    public void SetSecenek(string name)
    {
        _name = name;
        _txt.text = _name;
        _basildi = false;
        Basildi(false);
        _imgBtn.color = _colors[1];
    }
  

    public void EventDown()
    {
        if (_basildi) return;
        SoundBox.instance.PlayOneShot(NamesOfSound.bas);
        Basildi(true);
        Renk(false);

    }
    public void EventUp()
    {
        if (_basildi) return;

        _basildi = true;
        if (GameManagerResimdenYazi.instance != null)
            GameManagerResimdenYazi.instance.Kontrol(_name, this);
        else if (GameManagerSestenenYazi.instance != null)
            GameManagerSestenenYazi.instance.Kontrol(_name, this);
    }

    public void Renk(bool kimizi)
    {
        _imgBtn.color = (kimizi) ?_colors[0]:_colors[2];
    }

    void Basildi(bool durum) 
    {
        _imgBtn.sprite = (durum)?_sptsOfBtn[1]: _sptsOfBtn[0];
        _imgBtnGolge.enabled = !durum;
        _goKonum.transform.localPosition = (durum)?_konumAktif:Vector3.zero;
    }

}
