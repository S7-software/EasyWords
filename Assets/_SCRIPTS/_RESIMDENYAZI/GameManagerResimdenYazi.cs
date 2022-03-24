using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerResimdenYazi : MonoBehaviour
{
    public static GameManagerResimdenYazi instance;
    string _name;
    [SerializeField] [Range(0f, 3f)] float _delay = 0;
    [SerializeField] SpriteRenderer _sptRen ;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetGame();
    }



    public void Kontrol(string name,Button button)
    {
        if (name==_name)
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.KazandiSucsses);
            Invoke(nameof(SayfayiYenidenAc), _delay);
        }
        else
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.bayrakKaldir);
            button.interactable = false;
        }
    }

    void SayfayiYenidenAc()
    {
        GoToScene.Hangi(Sahne.EslestirmeResimdenYazi1x5);
    }

    void SetGame()
    {
        SecenekKelime[] secenekler = FindObjectsOfType<SecenekKelime>();
        foreach (var item in secenekler)
        {
            item.SetSecenek(GetListOfWords.RasgeleUniq());
        }
        _name = secenekler[Random.Range(0, secenekler.Length)]._name;

        _sptRen.sprite = PictureBox.Hangi(_name, false);

    }
}