using UnityEngine;
using UnityEngine.UI;

public class TranslatorScript : MonoBehaviour
{
    public string en, ru;

    static public TranslatorScript instance;

    private void Start()
    {
        if (Language.instance.currentLanguage == "ru") { GetComponent<Text>().text = ru; }
        else { GetComponent<Text>().text = en; }
    }
}
