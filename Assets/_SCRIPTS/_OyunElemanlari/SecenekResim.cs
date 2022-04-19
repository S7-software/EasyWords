using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecenekResim : MonoBehaviour
{
    [SerializeField] Image _imgBtn, _imgBtnGolge, _imgWord,_imgWordGolge;
    [SerializeField] GameObject _goKonum;
    [SerializeField] [Range(0f, 3f)] float _delay;
    [SerializeField] Vector3 _konumAktif;
    [SerializeField] Sprite[] _sptsOfBtn;
    public string _name;
    public bool _basildi = false;


    public void SetSecenek(string name)
    {
        _name = name;
        _basildi = false;
        _imgWord.sprite = PictureBox.Hangi(_name, false);
        _imgWord.color = Color.white;
        _imgWordGolge.sprite = _imgWord.sprite;
        Basildi(false);
        DurumButton(StatusOfButton.Basilmadi);
    }


    public void EventDown()
    {
        if (_basildi) return;
        SoundBox.instance.PlayOneShot(NamesOfSound.bas);
        Basildi(true);
        DurumButton(StatusOfButton.Basildi);
    

    }
    public void EventUp()
    {
        if (_basildi) return;

        _basildi = true;
        if (GameManagerSestenResim.instance != null)
            GameManagerSestenResim.instance.Kontrol(_name, this);
        else if (GameManagerYazidanResim.instance != null)
            GameManagerYazidanResim.instance.Kontrol(_name, this);

    }

    public void Renk(bool kimizi)
    {
        if (kimizi)
        {
            DurumButton(StatusOfButton.Yanlis);


        }
        else {
            _imgWord.color = Color.red;
            DurumButton(StatusOfButton.Dogru);
        }
    }

    void Basildi(bool durum)
    {
       
        _imgBtnGolge.enabled = !durum;
        _goKonum.transform.localPosition = (durum) ? _konumAktif : Vector3.zero;
    }
    void DurumButton(StatusOfButton statusOfButton)
    {
        switch (statusOfButton)
        {
            case StatusOfButton.Basilmadi:
                _imgBtn.sprite = _sptsOfBtn[0];
                break;
            case StatusOfButton.Basildi:
                _imgBtn.sprite = _sptsOfBtn[1];

                break;
            case StatusOfButton.Dogru:
                _imgBtn.sprite = _sptsOfBtn[2];

                break;
            case StatusOfButton.Yanlis:
                _imgBtn.sprite = _sptsOfBtn[3];

                break;
            case StatusOfButton.Secildi:
                break;
            default:
                break;
        }
    }
}
