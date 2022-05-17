using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnMenu : MonoBehaviour
{
    [SerializeField] Sahne _gidilecekSahne;
    [SerializeField] Sprite[] _sptsOfBtn;
    [SerializeField] Image _imgGolge, _imgBtn;
    [SerializeField] GameObject _goBtnResim;
    [SerializeField] Color[] _colors;
    [SerializeField] Vector3 _konumDonwResim;
    [SerializeField] [Range(0f, 3f)] float _delay;

    private void Awake()
    {

        StartButton();
    }

    private void StartButton()
    {
        _imgBtn.sprite = _sptsOfBtn[0];
        _imgBtn.color = _colors[0];
        _imgGolge.enabled = true;
        _goBtnResim.transform.localPosition = Vector3.zero;


    }

    public void ButtonDown()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.bas);
        _imgBtn.sprite = _sptsOfBtn[1];
        // _imgBtn.color = _colors[1];
        _imgGolge.enabled = false;
        _goBtnResim.transform.localPosition = _konumDonwResim;

    }
    public void ButtonUp()
    {
        //SoundBox.instance.PlayIfDontPlay(NamesOfSound.cek);

        Invoke(nameof(KategoriMenuAc), _delay);
    }

    void KategoriMenuAc()
    {
        if (_gidilecekSahne != Sahne.Harfler && _gidilecekSahne != Sahne.Sayilar)
        {
            TEMP._gidilecekSahne = _gidilecekSahne;
          
            DoThis.GetMyButtonFromScene("istatistik").SetDurumButton(MyButton.durumButton.aktifDegil);
            DoThis.GetMyButtonFromScene("ayarlar").SetDurumButton(MyButton.durumButton.aktifDegil);
            DoThis.GetMyButtonFromScene("cikis").SetDurumButton(MyButton.durumButton.aktifDegil);
            DoThis.GetMyButtonFromScene("satinalma").SetDurumButton(MyButton.durumButton.aktifDegil);
            DoThis.GetMyButtonFromScene("premium").SetDurumButton(MyButton.durumButton.aktifDegil);
            Instantiate(CanvasUIMainMenu.instance._menuCategorie);
        }
        else
        {
            TEMP._gidilecekSahne = _gidilecekSahne;
            GoToScene.Hangi(_gidilecekSahne);
        }


    }
}
