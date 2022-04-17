using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasUI : MonoBehaviour
{
    public static CanvasUI instance;
    [SerializeField] Sahne _sahneCikis;
    [SerializeField] [Range(0f, 3f)] float _delayCikis;
    [SerializeField] Sahne _sahneTekrar;
    [SerializeField] [Range(0f, 3f)] float _delayTekrar;
    [SerializeField] TMP_Text _txtHaftaYanlis, _txtHaftaDogru, _txtGunlukYanlis, _txtGunlukDogru, _txtHeader, _txtWeek, _txtDay;
    int _countHaftaYanlis, _countHaftaDogru, _countGunlukYanis, _countGunlukDogru;
    [SerializeField] GameObject _goHeader;
    [SerializeField] MyButton _myBtnAnaMenu, _myBtnAyarlar;
    [SerializeField] MyButton.durumButton _myBtnAnaMenuDurum, _myBtnAyarlarDurum;
    private void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        SetButtonsDurum();
    }

    IEnumerator HandleCikis(float delayCikis, Sahne sahneCikis)
    {
        yield return new WaitForSeconds(delayCikis);
        GoToScene.Hangi(sahneCikis);
    }
    IEnumerator HandleTekrar(float delayTekrar, Sahne sahneTekrar)
    {
        yield return new WaitForSeconds(delayTekrar);
        GoToScene.Hangi(sahneTekrar);
    }

    public void SetUI(AllStatusOfType allStatusOfType)
    {

        _txtHeader.text = "";
        _countHaftaDogru = allStatusOfType.HaftaDogru;
        _countHaftaYanlis = allStatusOfType.HaftaYanlis;
        _countGunlukDogru = allStatusOfType.GunDogru;
        _countGunlukYanis = allStatusOfType.GunYanlis;
        Yazdir(_txtGunlukDogru, _countGunlukDogru);
        Yazdir(_txtGunlukYanlis, _countGunlukYanis);
        Yazdir(_txtHaftaDogru, _countHaftaDogru);
        Yazdir(_txtHaftaYanlis, _countHaftaYanlis);

    }
    public void SetUI(bool isHeader, string header)
    {
        if (isHeader)
        {
            _txtDay.text = "";
            _txtWeek.text = "";
            _txtGunlukDogru.text = "";
            _txtGunlukYanlis.text = "";
            _txtHaftaDogru.text = "";
            _txtHaftaYanlis.text = "";
            _txtHeader.text = header;

        }
        else
        {
            _goHeader.SetActive(false);
        }
    }

    public void ArttirSayi(bool dogru, Sahne sahne)
    {
        if (dogru)
        {
            _countGunlukDogru++;
            _countHaftaDogru++;
            Kayit.Dogru(sahne);
            Yazdir(_txtGunlukDogru, _countGunlukDogru);
            Yazdir(_txtHaftaDogru, _countHaftaDogru);

        }
        else
        {
            _countHaftaYanlis++;
            _countGunlukYanis++;
            Kayit.Yanlis(sahne);

            Yazdir(_txtHaftaYanlis, _countHaftaYanlis);
            Yazdir(_txtGunlukYanlis, _countGunlukYanis);
        }
    }

    void Yazdir(TMP_Text txt, int sayi)
    {
        txt.text = "" + sayi;
    }

    public void HandleSolButton()
    {
      StartCoroutine(  HandleCikis(_delayCikis, _sahneCikis));
    }
    public void HandleSagButton()
    {

     StartCoroutine(   HandleTekrar(_delayTekrar, _sahneTekrar));
    }

    void SetButtonsDurum()
    {
        _myBtnAnaMenu.SetDurumButton(_myBtnAnaMenuDurum);
        _myBtnAyarlar.SetDurumButton(_myBtnAyarlarDurum);
    }
}
