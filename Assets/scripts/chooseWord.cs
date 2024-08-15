using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class chooseWord : MonoBehaviour
{
    // private List <string> random_word = new List<string>(new string[] {"L","E","F","T","Y"});
    private List <string> words = new List<string>();
    public List <string> random_word = new List<string>();
    public string rando_word;
    bool done=false;
    
    // Start is called before the first frame update
    void Start()
    {
        var lines=File.ReadAllLines("words.txt");
        for (int index=0; index<lines.Length; index++)
        {
            var word=lines[index];
            words.Add(word);

        }

        var random = Random.Range(0, lines.Length);
        rando_word=words[random];
        rando_word=rando_word.ToUpper();
        //take out:
        // Debug.Log(rando_word);
        for (int l=0; l<rando_word.Length; l++)
        {
            string letter= rando_word[l].ToString();
            random_word.Add(letter);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done==false){
            int count=GameObject.Find("cubes").GetComponent<gameController>().c;
            if (count>6)
            {
                GameObject finalRow = GameObject.Find("cubes 1");
                if (finalRow.GetComponent<changeColour>().correct<5){
                GameObject text = GameObject.Find("information");
                string message="The word was "+rando_word.ToLower();
                text.GetComponent<text>().Message(message);
                done=true;
                StartCoroutine(Quit());
                }
                IEnumerator Quit(){
                    yield return new WaitForSeconds(2f);
                    Application.Quit();
                }
                
            }
        }
        
    }
}
