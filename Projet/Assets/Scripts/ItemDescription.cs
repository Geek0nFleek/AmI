using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{

    public Text descriTx;
    public GameObject descriImg;
    public Canvas descriCv;
    private RectTransform rt;
    private Dictionary<string, int> texts;
    private List<string> textsArray; //= { "haha","fucker", "nope", "it's a beautiful\n day, right?", "Surprise I don't know what's happening \nplease help me it's \ndark all around"};
    int random;

    // Use this for initialization
    void Start()
    {
        texts = new Dictionary<string, int> { { "haha", 1 }, { "fucker", 1 }, { "nope", 1 }, { "it's a beautiful\n day, right?", 2 }, { "Surprise I don't know what's happening \nplease help me it's \ndark all around", 3 } };
        textsArray = new List<string>();
        rt = descriImg.GetComponent<RectTransform>();
        foreach (KeyValuePair<string, int> pair in texts) // l� j'ai automatis� le fait de choper les textes du dico pour les mettre dans la liste. C'est mieux.
        {
            textsArray.Add(pair.Key);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            StopAllCoroutines();
            random = Random.Range(0, textsArray.Count);
            StartCoroutine(descri(textsArray[random], texts[textsArray[random]]));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StopAllCoroutines();
            StartCoroutine(descri("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO\nOOOOOOOOOOOOOOOOO\nOOOOOOOO", 3));
        }
    }

    public IEnumerator descri(string sentence, int hauteur)
    {
        toggleDescription(true);
        print("start talking");
        descriTx.text = sentence;
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 70 * hauteur + 10);
        yield return new WaitForSeconds(sentence.Length * .1f);
        descriTx.text = "";
        print("Not saying anything");
        toggleDescription(false);
    }


    public void toggleDescription(bool state)
    {
        descriCv.enabled = state;
    }
    public void toggleDescription()
    {
        descriCv.enabled = !descriCv.enabled;
    }

}
