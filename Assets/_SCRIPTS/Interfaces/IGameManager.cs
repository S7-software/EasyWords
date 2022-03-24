using System;
using UnityEngine;
public interface IGameManager
{
    public void Clicked(string name, bool isChoiseOne);
    void CloseChosen(bool isChosenOne);
}

