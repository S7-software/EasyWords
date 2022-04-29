using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        btnGeri.onClick.AddListener(() => HandleButton(false));
        btnIleri.onClick.AddListener(() => HandleButton(true));
        Show();
        //JsonOrnek2();
        AYARLAR.Load();
    }

    void HandleButton(bool ileri)
    {

        index = ileri ? index + 1 : index - 1;
        Show();
    }

    void Show()
    {
        btnGeri.interactable = index != 0;
        btnIleri.interactable = temp.Count - 1 != index;
        txt.text = (temp[index]);
        imgGolge.sprite = PictureBox.Hangi(temp[index], false);
        imgResim.sprite = imgGolge.sprite;
        SoundBox.instance.StopAndPlayOneShot(temp[index]);
    }

    void JsonOrnek2()
    {
        HangiAdimdaKaldik hangiAdimdaKaldik = new HangiAdimdaKaldik(1, "Nabersin");
        string jsonHangiAdimdaKaldik = JsonUtility.ToJson(hangiAdimdaKaldik);
        Debug.Log(jsonHangiAdimdaKaldik);

        HangiAdimdaKaldik han = JsonUtility.FromJson<HangiAdimdaKaldik>(jsonHangiAdimdaKaldik);
        Debug.Log(han._sira);
       
    }
    void JSON_ORNEK()
    {
        /*
             PlayerData playerData= new PlayerData();
             playerData.position= new Vector3(0,3,2);
             playerData.health=80;

             string json=JsonUtility.ToJson(playerData  );
             Debug.Log(json    );

             File.WriteAllText(Application.dataPath+"/saveFile.json",json);
     */
        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(loadedPlayerData.position);
        Debug.Log(loadedPlayerData.health);
    }
   

    class PlayerData
    {
        public Vector3 position;
        public int health;
    }
    class HangiAdimdaKaldik
    {
        public HangiAdimdaKaldik(int sira,string not)
        {
            _sira = sira;
            _not = not;
        }
        public int _sira;
        public string _not;
    }

}
