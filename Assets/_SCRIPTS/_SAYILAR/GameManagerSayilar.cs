using UnityEngine;
using System.Collections;

public class GameManagerSayilar : MonoBehaviour
{
    public static GameManagerSayilar instance;
    SayilarSes[] _sayilarSes;
    private void Awake()
    {
        instance = this;
        _sayilarSes = FindObjectsOfType<SayilarSes>();
        
    }
    private void Start()
    {
        CanvasUI.instance.SetUI(true, "NUMBERS");
    }

    public void ButtonlarSetInc(bool deger)
    {
        foreach (var item in _sayilarSes)
        {
            item._myBtn.interactable = deger;
        }
    }
}
