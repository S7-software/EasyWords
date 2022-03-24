using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System;

public class GameManagerHarfler : MonoBehaviour
{
    [SerializeField] Harf[] _harfler;
    private void Awake()
    {
        AtaHarfleri();
    }

    private void AtaHarfleri()
    {
        int i = 0;
        foreach (var item in _harfler)
        {
            item.SetHarf(GetListOfWords.Harfler[i]);
            i++;
        }
    }

    private void Update()
    {
        Kontrol();
    }
    void Kontrol()
    {

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {

            return;
        }

        Collider2D[] touchs;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);


        touchs = Physics2D.OverlapBoxAll(worldPosition, new Vector2(0.2f, 0.2f), 0.5f);
        if (touchs.Length > 0)
        {

            Harf temp = touchs[0].GetComponent<Harf>();
            if (temp!=null)
            {
                temp.Click();
            }
        }
       




    }
}
