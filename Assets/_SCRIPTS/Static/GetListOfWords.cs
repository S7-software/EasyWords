﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetListOfWords : MonoBehaviour
{
    static List<string> Hayvan = new List<string>() { "cheetah", "chimpanzee", "gorilla", "kangaroo", "panda", "zebra" };

    static List<string> Bina = new List<string>() { "cinema", "hotel" };

    static List<string> Esya = new List<string>() { "balloon", "radio" };

    static List<string> Spor = new List<string>() { "tennis", "judo" };

    static List<string> YiyecekIcecek = new List<string>() { "biscuit", "cake", "milkshake", "pizza", "salad", "sandwich", "yoghurt", "coffee" };

    static List<string> Meyve = new List<string>() { "apple","apricot","avocado","banana","blackberry","cherry","coconut","fig","grape",
        "kiwi","mango","nectarine","orange","peach","pear","pineapple","quince","strawberry","lemon","melon","watermelon",
    "brocolli","cabbage","carrot","cauliflower","corn","cucumber","eggplant","greeenbeen","lettuce","leek","mushroom","onion",
    "pea","potato","pumpkin","radish","tomato","zucchini","pepper","bell pepper","garlic","spinach"};

    static List<string> Vucut = new List<string>() { "eye","nose","mouth","ear","cheek","chin","nostril","eyebrow","eyelid","eyelash","lip",
        "finger","palm","wrist","elbow","arm","shoulder","hand","knee","leg","calf","ankle","heel","foot","toe","heart","lung","vein",
    "brain","throat","liver","stomach","kidney","skeleton"};

    static List<string> Diger = new List<string>() { "lemon" };


    public static List<string> Harfler = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

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
            case 5: return YeniList(YiyecekIcecek);
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
                return YeniList(YiyecekIcecek);
            case Categories.Diger:
                return YeniList(Diger);
            case Categories.Vucut:
                return YeniList(Vucut);
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
        foreach (var item in FullPaket(Categories.Vucut)) { hepsi.Add(item); }

        return hepsi;
    }

    public static List<string> YeniList(List<string> eski)
    {
        List<string> yeni = new List<string>();
        foreach (var item in eski)
        {
            yeni.Add(item);
        }
        return yeni;
    }
    public static List<string> Rasgele5Kelime()
    {
        List<string> newList = new List<string>();
        int a = 0;
        while (a!=5)
        {
            string kelime = RasgeleUniq();
            if (newList.Contains(kelime)) continue;

            newList.Add(kelime);
            a++;
        }


        return newList;
    }

}
