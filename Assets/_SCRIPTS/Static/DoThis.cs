using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoThis : MonoBehaviour
{
    public static void RemoveAllHandleFromButtons(params Button[] buttons)
    {
        foreach (var item in buttons)
        {
            item.onClick.RemoveAllListeners();
        }
    }

    public static MyButton GetMyButtonFromScene(string name)
    {
        MyButton[] temp = FindObjectsOfType<MyButton>();
        foreach (var item in temp)
        {
            if (item._name == name) return item;
        }
        return null;
    }

}
