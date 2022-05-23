using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasINTRO : MonoBehaviour
{
    private void Awake()
    {
        if (PREMIUM.GetPremiumVar()) return;
        PREMIUM.PremiumSureKontrol();
    }
    public void EventAnaMenuyeGit()
    {
        GoToScene.Hangi(Sahne.MainMenu);
    }
}
