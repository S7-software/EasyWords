using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SecenekKelime : MonoBehaviour
{
    [SerializeField] Button _myBtn;
    [SerializeField] float _delay;
    [SerializeField] TMP_Text _txt;
   public string _name;
    private void Awake()
    {
      
    }
    public void SetSecenek(string name)
    {
        _name = name;
        _txt.text = _name;
        _myBtn.interactable = true;
        _myBtn.onClick.AddListener(() => StartCoroutine(HandleMyBtn(_delay)));
    }
    IEnumerator HandleMyBtn(float delay)
    {
        ClearHandle();
        GameManagerResimdenYazi.instance.Kontrol(_name, _myBtn);
        yield return new WaitForSeconds(delay);
    }
    public void ClearHandle() { _myBtn.onClick.RemoveAllListeners(); }

    

}
