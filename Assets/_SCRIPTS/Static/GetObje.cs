using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObje : MonoBehaviour
{
   static string _yol = "Prefabs/";
   public enum objeName { UI_KATEGORI, UI_AYARLAR , UI_PREMIUM , UI_SATIN_ALMA, UI_DEBUG }
    public void YARAT_UI( ) {
        if (FindObjectOfType<UI_DEBUG>()) Destroy(FindObjectOfType<UI_DEBUG>().gameObject);
        Instantiate(Hangi(objeName.UI_DEBUG)); }
    public static GameObject Hangi(objeName obje) { return Resources.Load<GameObject>(_yol + obje.ToString()); }
}
