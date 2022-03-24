using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetListOfWords : MonoBehaviour
{
    static List<string> Hayvan = new List<string>() { "cheetah", "chimpanzee", "gorilla", "kangaroo", "panda", "zebra" };
    static List<string> Bina = new List<string>() { "cinema", "hotel" };
    static List<string> Esya = new List<string>() { "balloon", "radio" };
    static List<string> Spor = new List<string>() { "tennis", "judo" };
    static List<string> Yiyecek = new List<string>() { "biscuit", "cake", "milkshake", "pizza", "salad", "sandwich", "yoghurt", "coffee" };
    static List<string> Meyve = new List<string>() { "lemon" };
    static List<string> Diger = new List<string>() { "lemon" };


  public  static List<string> Harfler = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    static List<string> temp = new List<string>();
    static List<string> tempHarf = new List<string>();

    public static string RasgeleUniq()
    {
        if (temp.Count == 0)
        {
            temp = Hepsi();
            return GetFromTemp(temp);
        }
        else
        {
            return GetFromTemp(temp);
        }

       

    }
    public static string RasgeleUniqHarf()
    {
        if (tempHarf.Count == 0)
        {
            tempHarf = YeniList(Harfler);
            return GetFromTemp(tempHarf);
        }
        else
        {
            return GetFromTemp(tempHarf);
        }
        

    }


    static string GetFromTemp(List<string> tmp)
    {
        string name = tmp[Random.Range(0, tmp.Count)];
        tmp.Remove(name);
        return name;
    }


    public static string Rasgele()
    {
        List<string> rasgele = RasgeleList();
        int random = Random.Range(0, rasgele.Count);
        return rasgele[random];
    }


    //public static List<string> Besli(Categories categories)
    //{
    //    switch (categories)
    //    {
    //        case Categories.Hayvan:
    //            break;
    //        case Categories.Meyve:
    //            break;
    //        case Categories.Bina:
    //            break;
    //        case Categories.Spor:
    //            break;
    //        case Categories.Esya:
    //            break;
    //        case Categories.Yiyecek:
    //            break;
    //        case Categories.Diger:
    //            break;
    //        case Categories.Karisik:
    //            break;
    //        default:
    //            break;
    //    }

    //   c
    //}

    static List<string> RasgeleList()
    {
        int key = Random.Range(1, 7);
        switch (key)
        {
            case 1: return YeniList(Hayvan);
            case 2: return YeniList(Bina);
            case 3: return YeniList(Esya);
            case 4: return YeniList(Spor);
            case 5: return YeniList(Yiyecek);
            case 6: return YeniList(Meyve);

            default: return YeniList(Diger);

        }

    }

    public static List<string> FullPaket(Categories categories)
    {


        switch (categories)
        {
            case Categories.Hayvan:
                return YeniList(Hayvan);
            case Categories.Meyve:
                return YeniList(Meyve);
            case Categories.Bina:
                return YeniList(Bina);
            case Categories.Spor:
                return YeniList(Spor);
            case Categories.Esya:
                return YeniList(Esya);
            case Categories.Yiyecek:
                return YeniList(Yiyecek);
            case Categories.Diger:
                return YeniList(Diger);
            case Categories.Karisik:
            default:
                return Hepsi();

        }
    }
    static List<string> Hepsi()
    {
        List<string> hepsi = new List<string>();
        foreach (var item in FullPaket(Categories.Hayvan)) { hepsi.Add(item); }
        foreach (var item in FullPaket(Categories.Meyve)) { hepsi.Add(item); }
        foreach (var item in FullPaket(Categories.Bina)) { hepsi.Add(item); }
        foreach (var item in FullPaket(Categories.Spor)) { hepsi.Add(item); }
        foreach (var item in FullPaket(Categories.Esya)) { hepsi.Add(item); }
        foreach (var item in FullPaket(Categories.Yiyecek)) { hepsi.Add(item); }
        foreach (var item in FullPaket(Categories.Diger)) { hepsi.Add(item); }

        return hepsi;
    }

    static List<string> YeniList(List<string> eski)
    {
        List<string> yeni = new List<string>();
        foreach (var item in eski)
        {
            yeni.Add(item);
        }
        return yeni;
    }


}
