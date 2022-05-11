using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTRO : MonoBehaviour
{


    void Start()
    {
        AYARLAR.Load();
        Invoke(nameof(GoToManinMenu), 0.5f);

    }
    void GoToManinMenu() { GoToScene.Hangi(Sahne.MainMenu); }
    
}
