using UnityEngine;
using System.Collections;
using System.IO;

public class AYARLAR : MonoBehaviour
{
    const string _yolAyarlar = "/";
    const string _nameOfAyarlar = "bin.json";
    public static bool _sesAcik=true;
    public static bool _reklamVar=true;




    public static void Load()
    {
        string json;
        _AYARLAR _ayarlar = new _AYARLAR();
        try
        {
            json = File.ReadAllText(Application.dataPath + _yolAyarlar + _nameOfAyarlar);
            _ayarlar = JsonUtility.FromJson<_AYARLAR>(json);
            _sesAcik = _ayarlar._sesAcik;
            _reklamVar = _ayarlar._reklamVar;

        }
        catch (System.Exception)
        {
            ///DEFAULT SETTINGS

            Save();
        }
        
    }

    public static void Save()
    {
        _AYARLAR _ayarlar = new _AYARLAR();
        _ayarlar._sesAcik = _sesAcik;
        _ayarlar._reklamVar = _reklamVar;
        string temp = JsonUtility.ToJson(_ayarlar);
        File.WriteAllText(Application.dataPath + _yolAyarlar + _nameOfAyarlar, temp);
    }
}
class _AYARLAR
{
    public  bool _sesAcik;
    public bool _reklamVar;
}
