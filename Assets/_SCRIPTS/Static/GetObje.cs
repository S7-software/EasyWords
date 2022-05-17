using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObje : MonoBehaviour
{
   static string _yol = "Prefabs/";
   public enum objeName { UI_KATEGORI, UI_AYARLAR , UI_PREMIUM , UI_SATIN_ALMA }
   
   public static GameObject Hangi(objeName obje) { return Resources.Load<GameObject>(_yol + obje.ToString()); }
}
