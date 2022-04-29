using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardOfStatus : MonoBehaviour
{
    [SerializeField]
    TMP_Text _txtGunDogru, _txtGunYanlis,
        _txtHaftaDogru, _txtHaftaYanlis,
        _txtHepsiDogru, _txtHepsiYanlis;

    public void SetCardOfStatus(int gunDogru,int gunYanlis,int haftaDogru,int haftaYanlis,int hepsiDogru,int hepsiYanlis)
    {
        _txtGunDogru.text = "" + gunDogru;
        _txtGunYanlis.text = "" + gunYanlis;
        _txtHaftaDogru.text = "" + haftaDogru;
        _txtHaftaYanlis.text = "" + haftaYanlis;
        _txtHepsiDogru.text = "" + hepsiDogru;
        _txtHepsiYanlis.text = "" + hepsiYanlis;
    }
}
