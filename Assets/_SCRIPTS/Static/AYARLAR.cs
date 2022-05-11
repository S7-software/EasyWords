using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class AYARLAR : MonoBehaviour
{
    const string _yolAyarlar = "/";
    const string _nameOfAyarlar = "bin.json";
    public static bool _sesAcik = true;
    public static bool _reklamVar = true;
    public static bool _premiumVar = false;

    public static bool _premiumGunlukCalisiyor = false;
    public static bool _premiumGunlukAlinabilir = true;
    public static int _premiumGunlukCount = 5;
    public static string _premiumAlinacakBirSonrakiSure = "00:00:00";
    public static string _premiumBitmesineKalanSure = "00:00:00";
    public static DateTime _premiumBirSonrakiGun = DateTime.Now.AddDays(1);


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
            _premiumVar = _ayarlar._premiumVar;
            _premiumGunlukCalisiyor = _ayarlar._premiumGunlukCalisiyor;
            _premiumGunlukAlinabilir = _ayarlar._premiumGunlukAlinabilir;
            _premiumGunlukCount = _ayarlar._premiumGunlukCount;
            _premiumAlinacakBirSonrakiSure = _ayarlar._premiumAlinacakBirSonrakiSure;
            _premiumBitmesineKalanSure = _ayarlar._premiumBitmesineKalanSure;
            _premiumBirSonrakiGun = DateTime.Parse(_ayarlar._premiumBirSonrakiGun);


            //PremiumSureKontrol();

        }
        catch (System.Exception)
        {
            ///DEFAULT SETTINGS
            Debug.Log("AYARLAR catch");
            Save();
        }

    }
    public static void PremiumSureKontrol()
    {
        if (_premiumBirSonrakiGun.Date <= DateTime.Now.Date)
        {
            _premiumBirSonrakiGun = DateTime.Now.AddDays(1);
            _premiumGunlukCount = 5;
            _premiumGunlukCalisiyor = false;
            Save();
            Load();
        }
        else if (DateTime.Parse(_premiumBitmesineKalanSure).TimeOfDay <= DateTime.Now.TimeOfDay&&_premiumGunlukCalisiyor)
        {
            _premiumGunlukCalisiyor = false;
            Save();
        }
        else if (DateTime.Parse(_premiumAlinacakBirSonrakiSure).TimeOfDay <= DateTime.Now.TimeOfDay&&!_premiumGunlukAlinabilir)
        {
            _premiumGunlukAlinabilir = true;
            Save();
        }


    }
    public static void Save()
    {
        _AYARLAR _ayarlar = new _AYARLAR();
        _ayarlar._sesAcik = _sesAcik;
        _ayarlar._reklamVar = _reklamVar;
        _ayarlar._premiumVar = _premiumVar;
        _ayarlar._premiumGunlukCount = _premiumGunlukCount;
        _ayarlar._premiumGunlukCalisiyor = _premiumGunlukCalisiyor;
        _ayarlar._premiumGunlukAlinabilir = _premiumGunlukAlinabilir;
        _ayarlar._premiumAlinacakBirSonrakiSure = _premiumAlinacakBirSonrakiSure;
        _ayarlar._premiumBitmesineKalanSure = _premiumBitmesineKalanSure;
        _ayarlar._premiumBirSonrakiGun = _premiumBirSonrakiGun.ToString();

        string temp = JsonUtility.ToJson(_ayarlar);
        File.WriteAllText(Application.dataPath + _yolAyarlar + _nameOfAyarlar, temp);
    }
    public static void DebugAllData()
    {
        Debug.LogWarning("_sesAcik " + _sesAcik +
            "\n_reklamVar " + _reklamVar +
            "\n_premiumVar " + _premiumVar +
            "\n_premiumGunlukCalisiyor " + _premiumGunlukCalisiyor +
            "\n_premiumGunlukCount " + _premiumGunlukCount +
            "\n_premiumAlinacakBirSonrakiSure " + _premiumAlinacakBirSonrakiSure +
            "\n_premiumBirSonrakiGun " + _premiumBirSonrakiGun
            );
    }
}


class _AYARLAR
{
    public bool _sesAcik;
    public bool _reklamVar;
    public bool _premiumVar;
    public bool _premiumGunlukCalisiyor;
    public bool _premiumGunlukAlinabilir;
    public int _premiumGunlukCount;
    public string _premiumAlinacakBirSonrakiSure;
    public string _premiumBitmesineKalanSure;
    public string _premiumBirSonrakiGun;
}
