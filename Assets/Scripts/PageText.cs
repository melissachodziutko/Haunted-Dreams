using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageText : MonoBehaviour
{
    public string[] samanthaText = new string[] { "Dear John,   It’s getting harder. I don’t want to lie to you and pretend i’m doing fine, but it’s not easy.   Much Love,  Samantha", "Dear John,   I don’t know if you’ll ever read these. I had a LOT of fun with you today, it’s like I forgot all of my problems. Seeing how much you love me in your eyes… why can’t I get it through my head how loved I am? It’s so obvious.   Much Love,  Samantha", "Dear John,   I don’t want to bother you. But man, things are hard. Waking up having to battle my mind every single day is annoying at best and detrimental at worst. I just have to stay positive.  Much Love,  Samantha", "Dear John,  You did nothing wrong. I love you very much. I’ll see you later.  Much Love,  Samantha" };
    TextMeshProUGUI txt;
    int currentText = 0;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = samanthaText[0];
        Debug.Log(samanthaText[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentText < 3)
        {
            currentText += 1; 
            txt.text = samanthaText[currentText];
        }
    }
}
