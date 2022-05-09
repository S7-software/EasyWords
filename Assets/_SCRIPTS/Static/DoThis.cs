using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DoThis : MonoBehaviour
{
   static int _tempTekrar = 0;
    public static bool TekrarAsimi(int kacTekrar)
    {
        _tempTekrar++;
        if (kacTekrar == _tempTekrar) return true;
        return false;
    }
    public static void TekrarAsimiSifirla() { _tempTekrar = 0; }
    public static void RemoveAllHandleFromButtons(params Button[] buttons)
    {
        foreach (var item in buttons)
        {
            item.onClick.RemoveAllListeners();
        }
    }

    public static MyButton GetMyButtonFromScene(string name)
    {
        MyButton[] temp = FindObjectsOfType<MyButton>();
        foreach (var item in temp)
        {
            if (item._name == name) return item;
        }
        return null;
    }


    static List<string> tempKelimeKontrol= new List<string>();
    public static bool Contain(string name)
    {
        return tempKelimeKontrol.Contains(name);
    }
    public static void ContainAdd(string name) { tempKelimeKontrol.Add(name); }
    public static void ContainReset() { tempKelimeKontrol = new List<string>(); }



}
