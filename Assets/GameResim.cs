using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResim : MonoBehaviour,IWords
{
    bool _isFound, _active,_choiseOne;
    string _name;
    public Vector3 _konumTutamac;
    [SerializeField] SpriteRenderer _sptRenImg;

    public string GetName() { return _name; }
    public bool IsFound() { return _isFound; }
    public bool IsActive() { return _active; }
    public Vector3 GetKonumTutamac() { return _konumTutamac; }

    public void SetWord(string name, Vector3 konumTutamac, bool choiseOne)
    {
        _choiseOne = choiseOne;
        _konumTutamac = konumTutamac;
        _name = name;
        ClickResim(false);
    }

    public void Click()
    {
        GameManager5x5.instance.Clicked(_name,_choiseOne);
        ClickResim(true);
        _active = true;
    }

    void ClickResim(bool aktif)
    {
        _sptRenImg.sprite = PictureBox.Hangi(_name, aktif);
    }

    public void ReturnBack()
    {
        ClickResim(false);
        _active = false;
    }

    public void Found()
    {
        _isFound = true;
    }

}
