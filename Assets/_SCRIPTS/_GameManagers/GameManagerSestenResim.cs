using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerSestenResim : MonoBehaviour
{
   public static GameManagerSestenResim instance;
    [SerializeField] Button _btnSes;
    SecenekResim[] _secenekResims;
    string _name;
    bool _bulundu = false;
    private void Awake()
    {
        instance = this;
        _secenekResims = FindObjectsOfType<SecenekResim>();
        _btnSes.onClick.AddListener(HandleSes);
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
        if (Kayit.IsYeniGun()) Kayit.ResetGun();
        if (Kayit.IsYeniHafta()) Kayit.ResetHafta();
        CanvasUI.instance.SetUI(Kayit.GetScore(Sahne.EslestirmeSestenResim1x5));

    }

    void SetGame(SecenekResim[] secenekResims)
    {

        DoThis.ContainReset();
        foreach (var item in secenekResims)
        {
            string name;
            int zamanAsimi = 0;
            do
            {
                zamanAsimi++;
                name = GetListOfWords.RasgeleUniq(TEMP._secilenCategorie);

            } while (DoThis.Contain(name) && zamanAsimi < 100);
            if (zamanAsimi == 100) Debug.LogError("Zaman Aşımı");
            item.SetSecenek(name); ;
            DoThis.ContainAdd(name);
        }
        //foreach (var item in secenekResims)
        //{
        //    item.SetSecenek(GetListOfWords.RasgeleUniq(TEMP._secilenCategorie));
        //}
        _name = secenekResims[Random.Range(0, secenekResims.Length)]._name;
        if (!FindObjectOfType<UI_PREMIUM>()) Invoke( "HandleSes",0.4f);
    }

    public void Kontrol(string name, SecenekResim secenekResim)
    {
        if (name == _name)
        {
            RemoveAllHandle();
            SoundBox.instance.StopAndPlayOneShot(name);
            secenekResim.Renk(true);
            _bulundu = true;
            CanvasUI.instance.ArttirSayi(true, Sahne.EslestirmeSestenResim1x5);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);
            secenekResim.Renk(false);
            CanvasUI.instance.ArttirSayi(false, Sahne.EslestirmeSestenResim1x5);

        }
    }
    private void HandleSes()
    {
        SoundBox.instance.PlayIfDontPlay(_name);
    }
    void RemoveAllHandle()
    {
        foreach (var item in _secenekResims)
        {
            item._basildi = true;
        }
    }
}
