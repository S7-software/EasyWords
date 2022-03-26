using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecenekResim : MonoBehaviour
{
    [SerializeField] Button _myButton;
    [SerializeField] Image _myImage;
    [SerializeField] Image _myWord;
    [SerializeField] Color[] _colors;
   public string _name;

    public void SetResim(string name)
    {
        _name = name;
        _myWord.sprite = PictureBox.Hangi(_name, false);
       

        ResetResim();
       
    }

    void HandleButton()
    {
        _myImage.color = _colors[0];
        _myButton.interactable = false;
       GameManagerSestenResim.instance. Kontrol(_name,this);
    }
    public void Dogru() { _myImage.color = _colors[2]; }
    public void RemoveHandle() { DoThis.RemoveAllHandleFromButtons(_myButton); }
    public void ResetResim()
    {
        _myImage.color = _colors[1];
        DoThis.RemoveAllHandleFromButtons(_myButton);
        _myButton.interactable = true;

        _myButton.onClick.AddListener(HandleButton);
    }

}
