using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public static void Hangi(Sahne sahne)
    {
        SceneManager.LoadScene(sahne.ToString());
    }
}
