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
        _myBtn.onClick.AddListener(() => StartCoroutine(HandleMyBtn(_delay)));
    }
    public void SetSecenek(string name)
    {
        _name = name;
        _txt.text = _name;
    }
    IEnumerator HandleMyBtn(float delay)
    {
        GameManagerResimdenYazi.instance.Kontrol(_name, _myBtn);
        yield return new WaitForSeconds(delay);
    }

    

}
