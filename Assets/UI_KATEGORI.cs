using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KATEGORI : MonoBehaviour
{
    [SerializeField] Button _btnX;

    private void Awake()
    {
        ButtonlaraHandleAta();
    }

    private void ButtonlaraHandleAta()
    {
        _btnX.onClick.AddListener(HandleX);
    }

    public void HandleX()
    {
        foreach (var item in FindObjectsOfType<btnMenu>())
        {
            item.StartButton();
        }
        CanvasUIMainMenu.instance.SetButtonPremium();
        DoThis.GetMyButtonFromScene("cikis").SetDurumButton(MyButton.durumButton.basilmadi);
        DoThis.GetMyButtonFromScene("ayarlar").SetDurumButton(MyButton.durumButton.basilmadi);
        DoThis.GetMyButtonFromScene("satinalma").SetDurumButton(MyButton.durumButton.basilmadi);
        DoThis.GetMyButtonFromScene("istatistik").SetDurumButton(MyButton.durumButton.basilmadi);
        //Invoke("YokEt", 0.05f);
        Destroy(gameObject);
    }
    
}
