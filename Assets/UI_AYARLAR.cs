using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AYARLAR : MonoBehaviour
{
    [SerializeField] MyButton _btnSesOn, _btnSesOff, _btnReset,_btnResetNo;
    [SerializeField] Image[] _imgsSesIcon;
    [SerializeField] Sprite[] _sptsSesIcon;
    [SerializeField] GameObject _goReset;

    bool _isSesOn = true;
    private void Awake()
    {
        _isSesOn = Kayit.GetSesAcik();
       
    }
    private void Start()
    {
        _goReset.SetActive(false);
        SesAyarla();
    }


    public void EvetntDownSes(bool isSesOn)
    {
        if (isSesOn == _isSesOn) return;
        _isSesOn = !_isSesOn;
        
        Kayit.SetSesAcik(_isSesOn);
        if (_isSesOn) SoundBox.instance.PlayOneShot(NamesOfSound.bas);
        SesAyarla();
    }
    public void EventExit()
    {

        GameObject.Find("myBtnAyarlar").GetComponent<MyButton>().SetDurumButton(MyButton.durumButton.basilmadi);
        Destroy(gameObject);
       
    }

    public void EventReset()
    {
        _goReset.SetActive(true);
    }
    public void EventResetYes() { }
    public void EventResetNo() {
        _goReset.SetActive(false);
        _btnReset.SetDurumButton(MyButton.durumButton.basilmadi);
        _btnResetNo.SetDurumButton(MyButton.durumButton.basilmadi);
    }
    void SesAyarla()
    {
        _imgsSesIcon[0].sprite = _isSesOn ? _sptsSesIcon[0] : _sptsSesIcon[1];
        _imgsSesIcon[1].sprite = _imgsSesIcon[0].sprite;

        if (_isSesOn)
        {
            _btnSesOff._isActive = true; ;
            _btnSesOff.SetDurumButton(MyButton.durumButton.basilmadi);
           
            _btnSesOn.SetDurumButton(MyButton.durumButton.basildi);
            _btnSesOn._isActive = false; ;
        }
        else
        {
            
            _btnSesOn.SetDurumButton(MyButton.durumButton.basilmadi);
            _btnSesOn._isActive = true; ;
            _btnSesOff.SetDurumButton(MyButton.durumButton.basildi);
            _btnSesOff._isActive = false; ;
        }

    }

    
    
}
