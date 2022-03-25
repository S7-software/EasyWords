using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerSestenenYazi : MonoBehaviour
{
    public static GameManagerSestenenYazi instance;
    string _name;
    [SerializeField] Button _btnSes;
    bool _bulundu = false;

    SecenekKelime[] _secenekler;

    private void Awake()
    {
        instance = this;
        _secenekler = FindObjectsOfType<SecenekKelime>();
        _btnSes.onClick.AddListener(HandleBtnSes);
        
    }
    private void Start()
    {
        SetGame(_secenekler);
    }

    private void Update()
    {
        if (!_bulundu) return;
        if (SoundBox.instance.IsPlaying()) return;
        _bulundu = false;
        SetGame(_secenekler);

    }

    public void Kontrol(string name, Button button)
    {
        if (name == _name)
        {
            SoundBox.instance.PlayOneShot(name);
            _bulundu = true;
        }
        else
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.bayrakKaldir);
            button.interactable = false;
        }
    }



    void SetGame(SecenekKelime[] secenekler)
    {

        foreach (var item in secenekler)
        {
            item.SetSecenek(GetListOfWords.RasgeleUniq());

        }
        _name = secenekler[Random.Range(0, secenekler.Length)]._name;
       
        

    }
    void HandleBtnSes()
    {
        SoundBox.instance.PlayOneShot(_name);
    }
}