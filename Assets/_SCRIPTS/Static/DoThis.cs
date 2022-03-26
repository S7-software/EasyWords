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
}
