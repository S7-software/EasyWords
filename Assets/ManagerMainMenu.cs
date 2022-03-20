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
    }

    void SetArkaPlanResimler( SpriteRenderer[] resimler)
    {
        foreach (var item in resimler)
        {
            item.sprite = PictureBox.RasgeleDuzUniq();
        }
    }


}
