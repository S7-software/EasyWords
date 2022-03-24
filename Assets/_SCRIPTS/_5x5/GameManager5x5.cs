using UnityEngine;
using System.Collections;
using System;

public class GameManager5x5 : MonoBehaviour,IGameManager
{
    public static GameManager5x5 instance;
    int countBulunma = 0;
    bool birKartSecildi = false;
    string tempNameSecilme = "";
    GameResim[] _gameResims;
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        GetVariables();
    }

    private void GetVariables()
    {
        _gameResims = FindObjectsOfType<GameResim>();
  
    }

    public void Clicked(string name,bool isChoiseOne)
    {

        if (birKartSecildi)
        {
            birKartSecildi = true;
            tempNameSecilme = name;
        }
        else
        {
            if (tempNameSecilme==name)
            {
                countBulunma++;
                CiftBulundu(name);
                if (countBulunma==5)
                {
                    OyunBitti();
                }

            }
            else
            {
                KapatAciklari();
            }
            birKartSecildi = false;
            tempNameSecilme = "";
        }
    }

    private void CiftBulundu(string name)
    {
        SoundBox.instance.PlayOneShot(name);
    }



    private void KapatAciklari()
    {
       
    }

    private void OyunBitti()
    {
       
    }

    public void CloseChosen(bool isChosenOne)
    {
       
    }
}
