using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    [SerializeField] Categories kategori;
    [SerializeField] Image imgResim, imgGolge;
    [SerializeField] Text txt;
    [SerializeField] Button btnGeri, btnIleri;
    List<string> temp;
    int index = 0;
    private void Awake()
    {
        temp = GetListOfWords.FullPaket(kategori);
        btnGeri.onClick.AddListener(()=>HandleButton(false));
        btnIleri.onClick.AddListener(()=>HandleButton(true));
        Show();
    }

    void HandleButton(bool ileri)
    {
        index = ileri ? index + 1 : index - 1;
        Show();
    }

    void Show()
    {
        btnGeri.interactable = index != 0;
        btnIleri.interactable = temp.Count-1 != index;
        txt.text = (temp[index]);
        imgGolge.sprite =PictureBox.Hangi( temp[index],false);
        imgResim.sprite = imgGolge.sprite;
        SoundBox.instance.StopAndPlayOneShot(temp[index]);
    }
}
