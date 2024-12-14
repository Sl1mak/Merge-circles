using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    public string currentLanguage;

    static public Language instance;

    [DllImport("__Internal")]
    public static extern string GetLang();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            currentLanguage = GetLang();
        }
        else { Destroy(gameObject); }
    }
}
