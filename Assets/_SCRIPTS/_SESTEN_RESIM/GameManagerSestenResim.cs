using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerSestenResim : MonoBehaviour
{
   public static GameManagerSestenResim instance;
    [SerializeField] Button _btnSes;
    SecenekResim[] _secenekResims;
    string _name;
    bool _bulundu = false;
    private void Awake()
    {
        instance = this;
        _secenekResims = FindObjectsOfType<SecenekResim>();
        _btnSes.onClick.AddListener(HandleSes);
    }

   

    private void Start()
    {
        SetScore();
        SetGame(_secenekResims);
    }
    private void Update()
    {
        if (!_bulundu) return;
        if (SoundBox.instance.IsPlaying()) return;
        _bulundu = false;
        SetGame(_secenekResims);

    }
    private void SetScore()
    {
        CanvasUI.instance.SetUI(15, 15, 0, 0);
    }

    void SetGame(SecenekResim[] secenekResims)
    {
        foreach (var item in secenekResims)
        {
            item.SetResim(GetListOfWords.RasgeleUniq());
        }
        _name = secenekResims[Random.Range(0, secenekResims.Length)]._name;
       Invoke( "HandleSes",0.4f);
    }

    public void Kontrol(string name, SecenekResim secenekResim)
    {
        if (name == _name)
        {
            RemoveAllHandle();
            SoundBox.instance.PlayOneShot(name);
            secenekResim.Dogru();
            _bulundu = true;
            CanvasUI.instance.ArttirSayi(true);
        }
        else
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.bayrakKaldir);
           
            CanvasUI.instance.ArttirSayi(false);

        }
    }
    private void HandleSes()
    {
        SoundBox.instance.PlayOneShot(_name);
    }
    void RemoveAllHandle()
    {
        foreach (var item in _secenekResims)
        {
            item.RemoveHandle();
        }
    }
}
