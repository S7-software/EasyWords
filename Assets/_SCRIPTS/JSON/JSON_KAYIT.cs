using UnityEngine;
using System.Collections;
using System.IO;

public class JSON_KAYIT : MonoBehaviour
{
    const string _yolAyarlar = "/";

    public static string OKU(string dosyaAdi)
    {
        try
        {
            return File.ReadAllText(Application.dataPath + _yolAyarlar + dosyaAdi);
        }
        catch (System.Exception )
        {
            return null;
        }
        
    }

    public static void YAZ(string dosyaAdi, string dosya)
    {
        File.WriteAllText(Application.dataPath + _yolAyarlar + dosyaAdi, dosya);
    }
}
