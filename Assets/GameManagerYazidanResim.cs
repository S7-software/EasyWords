using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerYazidanResim : MonoBehaviour
{
  public static  GameManagerYazidanResim instance;
    [SerializeField] TMP_Text _txtName;
   [SerializeField] Color[] _colors;
    SecenekResim[] _secenekResims;
    string _name;
    bool _bulundu = false;

    private void Awake()
    {
        instance = this;
        _secenekResims = FindObjectsOfType<SecenekResim>();
    }



    private void Start()
    {
        SetScore();
        SetGame(_secenekResims);
    }
    private void Update()
    {
        if (!_bulundu) return;
        if (SoundBox.instance.IsPlaying()) return;
        _bulundu = false;
        SetGame(_secenekResims);

    }
    private void SetScore()
    {
        CanvasUI.instance.SetUI(15, 15, 0, 0);
    }

    void SetGame(SecenekResim[] secenekResims)
    {
        foreach (var item in secenekResims)
        {
            item.SetSecenek(GetListOfWords.RasgeleUniq());
        }
        _name = secenekResims[Random.Range(0, secenekResims.Length)]._name;
        _txtName.text = _name;
        _txtName.color = _colors[Random.Range(0,_colors.Length  )];
    }

    public void Kontrol(string name, SecenekResim secenekResim)
    {
        if (name == _name)
        {
            RemoveAllHandle();
            SoundBox.instance.StopAndPlayOneShot(name);

            _bulundu = true;
            CanvasUI.instance.ArttirSayi(true);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);
            secenekResim.Renk(true);
            CanvasUI.instance.ArttirSayi(false);

        }
    }
   
    void RemoveAllHandle()
    {
        foreach (var item in _secenekResims)
        {
            item._basildi = true;
        }
    }
}
