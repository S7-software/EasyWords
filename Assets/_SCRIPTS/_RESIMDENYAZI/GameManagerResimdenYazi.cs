using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerResimdenYazi : MonoBehaviour
{
    public static GameManagerResimdenYazi instance;
    string _name;
    [SerializeField] SpriteRenderer _sptRen ;
    bool _bulundu = false;

    SecenekKelime[] _secenekler;

    private void Awake()
    {
        _secenekler = FindObjectsOfType<SecenekKelime>();
        instance = this;
    }
    private void Start()
    {
        SetGame(_secenekler);
        SetScore();
    }

    private void SetScore()
    {
        CanvasUI.instance.SetUI(15, 15, 0, 0);
    }

    private void Update()
    {
        if (!_bulundu) return;
        if (SoundBox.instance.IsPlaying()) return;
        _bulundu = false;
        SetGame(_secenekler);

    }

    public void Kontrol(string name,Button button)
    {
        if (name==_name)
        {
            SoundBox.instance.PlayOneShot(name);
            _bulundu = true;
            RemoveAllHadnle(_secenekler);
            CanvasUI.instance.ArttirSayi(true);
        }
        else
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.bayrakKaldir);
            button.interactable = false;
            CanvasUI.instance.ArttirSayi(false);

        }
    }

    

    void SetGame(SecenekKelime[] secenekler)
    {
        
        foreach (var item in secenekler)
        {
            item.SetSecenek(GetListOfWords.RasgeleUniq());
            
        }
        _name = secenekler[Random.Range(0, secenekler.Length)]._name;

        _sptRen.sprite = PictureBox.Hangi(_name, false);

    }
    void RemoveAllHadnle(SecenekKelime[] secenekler)
    {
        foreach (var item in secenekler)
        {
            item.ClearHandle();
        }
    }
}