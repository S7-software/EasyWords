using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecenekYazi5x : MonoBehaviour
{
    [SerializeField] TMP_Text _myTxt;
    [SerializeField] Color[] _colors;
    [SerializeField]public Image _imgNokta;
    public string _name;
    public bool _basildi = false;
    public bool _bulundu = false;

    public enum Renk5x { kendi,sari,bulundu}


    public void SetSecenek(string name,Color color)
    {
        _name = name;
        _bulundu = false;
        _myTxt.text = _name;
        _colors[0] = color;
        _myTxt.color = _colors[0];
        _imgNokta.color = color;
        Basildi(false);
    }


    public void EventDown()
    {
        if (_bulundu) return;
        if (_basildi) return;
        SoundBox.instance.PlayOneShot(NamesOfSound.clickArama);
        Basildi(true);
        Renk(Renk5x.sari);

    }
    public void EventUp()
    {
        if (_bulundu) return;
        if (_basildi) return;

        _basildi = true;
        GameManager5x5.instance.Kontrol(this);


    }

    public void Renk(Renk5x renk5X)
    {
        switch (renk5X)
        {
            case Renk5x.kendi:
                _myTxt.color = _colors[0];
                break;
            case Renk5x.sari:
                _myTxt.color = _colors[1];
                break;
            case Renk5x.bulundu:
                Color color = new Color(_colors[0].r, _colors[0].g, _colors[0].b,0.25f);
                _myTxt.color = color;

                break;
            
        }
        
    }
    public void Bulundu(bool durum)
    {
        if (durum)
        {
            _bulundu = true;
            Renk(Renk5x.bulundu);
        }
        else
        {
            Basildi(false);
        }

    }

  public  void Basildi(bool durum)
    {
        
        if (durum)
        {
            Renk(Renk5x.sari);
        }
        else
        {
            Renk(Renk5x.kendi);
            _basildi = false;
        }
        
    }
}
