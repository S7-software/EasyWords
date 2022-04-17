using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIMainMenu : MonoBehaviour
{

    [SerializeField] [Range(0f, 3f)] float _delay=0f;
    private void Awake()
    {
       ButtonlaraHandleAta();
    }

    private void ButtonlaraHandleAta()
    {
    }

    public void HandleCikis()
    {
        Application.Quit();
    }

    IEnumerator SahneGecis(float delay,Sahne sahne)
    {
        yield return new WaitForSeconds(delay);
        GoToScene.Hangi(sahne);
    }
}
