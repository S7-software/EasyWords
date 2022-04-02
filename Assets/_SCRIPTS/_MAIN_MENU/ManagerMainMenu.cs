using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMainMenu : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] _resimler;
    [SerializeField] SpriteRenderer[] _harfler;
    void Start()
    {
        SetArkaPlanResimler(_resimler);
       SetArkaPlanHarfler(_harfler);
    }

    void SetArkaPlanResimler(SpriteRenderer[] resimler)
    {
        if (resimler.Length == 0) return;
        foreach (var item in resimler)
        {
            item.sprite = PictureBox.RasgeleDuzUniq();
        }
    }
    void SetArkaPlanHarfler(SpriteRenderer[] harfler)
    {
        if (harfler.Length == 0) return;

        foreach (var item in harfler)
        {
            item.sprite = PictureBox.RasgeleDuzUniqHarf();
        }
    }


}
