using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecenekResim5x : MonoBehaviour
{
    [SerializeField] Image _imgBtn, _imgBtnGolge, _imgWord,_imgWordGolge;
    public Image _imgNokta;
    [SerializeField] GameObject _goKonum;
    [SerializeField] Color[] _colors;
    [SerializeField] Vector3 _konumAktif;
    [SerializeField] Sprite[] _sptsOfBtn;
    public string _name;
    public bool _basildi = false;
    public bool _bulundu = false;
    public enum Renk5x { kirmizi,sari,yesil,beyaz}
    Color _colorImgWord;

    private void Awake()
    {
        _colorImgWord = _imgWord.color;
    }
    public void SetSecenek(string name)
    {
        _name = name;
        _basildi = false;
        _bulundu = false;
        _imgNokta.color = _colors[4];
        _imgWord.sprite = PictureBox.Hangi(_name, false);
        _imgWordGolge.sprite = _imgWord.sprite;
        _imgWord.color = _colorImgWord;
        _imgWordGolge.enabled = true;
        Basildi(false);
        Renk(Renk5x.beyaz);
    }


    public void EventDown()
    {
        if (_bulundu) return;
        if (_basildi) return;
        SoundBox.instance.PlayOneShot(NamesOfSound.bas);
        Basildi(true);
        _imgNokta.color = _colors[((int)Renk5x.sari)];
     

    }
    public void EventUp()
    {
        if (_bulundu) return;
        if (_basildi) return;
        SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);
        _basildi = true;
         GameManager5x5.instance.Kontrol(this);
        

    }

    public void Renk(Renk5x renk)
    {

        _imgBtn.color = _colors[((int)renk)];
    }
    public void Bulundu(bool durum)
    {
        if (durum)
        {
            _bulundu = true;
           _imgWordGolge.enabled = false;
            _imgWord.color = new Color(_colorImgWord.r, _colorImgWord.g, _colorImgWord.b, 0.35f);
            Renk(Renk5x.sari);
        }
        else
        {
            Basildi(false);
        }
       
    }

  public  void Basildi(bool durum)
    {
        _imgBtn.sprite = (durum) ? _sptsOfBtn[1] : _sptsOfBtn[0];
        _imgBtnGolge.enabled = !durum;
        _goKonum.transform.localPosition = (durum) ? _konumAktif : Vector3.zero;
        _basildi = false;
        if (!durum) {
            Renk(Renk5x.beyaz);
            _imgNokta.color = _colors[4];
        }
    }

    
}
