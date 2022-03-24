using System;
using UnityEngine;
public interface IWords
{
    public string GetName();
    public bool IsActive();
    public bool IsFound();
    public Vector3 GetKonumTutamac();

    public void SetWord(string name, Vector3 konumTutamac,bool Choise);
    public void ReturnBack();
   public void Click();
    public void Found();

}
