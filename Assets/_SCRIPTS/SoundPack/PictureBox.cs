﻿using UnityEngine;
using System.Collections;

public class PictureBox : MonoBehaviour
{

    static string yol = "img/WordsResimler/";
    public static Sprite Hangi(string name, bool active)
    {

        return Resoruce( Key(name,active));
    }
    public static Sprite RasgeleDuz() { return Resoruce(Key(GetListOfWords.Rasgele(), false)); }
    public static Sprite RasgeleDuzUniq() { return Resoruce(Key(GetListOfWords.RasgeleUniq(), false)); }
    public static Sprite RasgeleActive() { return Resoruce(Key(GetListOfWords.Rasgele(), true)); }
    public static Sprite RasgeleActiveUniq() { return Resoruce(Key(GetListOfWords.RasgeleUniq(), true)); }

    static string Key(string name, bool durum) { return yol + ((durum) ? name + "1" : name); }
    static Sprite Resoruce(string yol) { return Resources.Load<Sprite>(yol); }
}
