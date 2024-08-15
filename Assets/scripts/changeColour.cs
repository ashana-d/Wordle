using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class changeColour : MonoBehaviour
{
    private List <string> words = new List<string>();
    public GameObject[] cubes;
    public int correct=0;
    // Start is called before the first frame update
    void Start()
    {
       var lines=File.ReadAllLines("possible.txt");
        for (int index=0; index<lines.Length; index++)
        {
            var word=lines[index];
            words.Add(word);

        }

        var lines2=File.ReadAllLines("words.txt");
        for (int index=0; index<lines2.Length; index++)
        {
            var word2=lines2[index];
            words.Add(word2);

        }
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown("return"))
        {
            List <string> enteredword = GetComponent<playerInput>().cubes;
            string wordString = string.Join( "", enteredword);
            wordString=wordString.ToLower();
            if (wordString.Length!=5){
                GameObject text = GameObject.Find("information");
                text.GetComponent<text>().Message("Must be five letters long!");
            }
            else if(words.Contains(wordString)==false){
                GameObject text = GameObject.Find("information");
                text.GetComponent<text>().Message("Not a word!");
            }
            
            else {
                GameObject text = GameObject.Find("information");
                text.GetComponent<text>().Clear();
                Colour();
                GameObject.Find("cubes").GetComponent<gameController>().nextRow();
               
           }
        }
    }

    public void Colour()
    {
        correct=0;
        List <string> user_word = GetComponent<playerInput>().cubes;
        // List <string> random_word = GetComponent<chooseWord>().random_word;
        List <string> random_word= GameObject.Find("cubes").GetComponent<chooseWord>().random_word;

            for (int u= 0; u < user_word.Count; u++)
            {
                for (int r=0; r< random_word.Count; r++)
                {
                    int count=0;
                    for (int i=0; i<random_word.Count; i++)
                    {
                        if (random_word[r]==random_word[i])
                        {
                            count+=1;
                        }
                    }

                    if(user_word[u]==random_word[r])
                    {
                        if(u==r)
                        {
                            GameObject thisCube=cubes[u];
                            thisCube.GetComponent<Renderer>().material.color = new Color(174/255, 255/255, 128/255);
                            break;
                        }
                        else
                        {
                            GameObject thisCube=cubes[u];
                            thisCube.GetComponent<Renderer>().material.color = new Color(255/255, 255/255, 128/255);
                            break;
                        }
                    }
                    if (r==4)
                    {
                        GameObject thisCube=cubes[u];
                        thisCube.GetComponent<Renderer>().material.color = Color.grey;
                    }
                }
            }
        
        for(int x=0; x<random_word.Count;x++){
            if(random_word[x]==user_word[x]){
                correct+=1;
                GameObject thisCube=cubes[x];
                thisCube.GetComponent<Renderer>().material.color = new Color(174/255, 255/255, 128/255);
            }
        }
        if (correct==5){
            GameObject text = GameObject.Find("information");
            text.GetComponent<text>().Message("Well done!");
            StartCoroutine(Quit());
                IEnumerator Quit(){
                    yield return new WaitForSeconds(2f);
                    Application.Quit();
                }
        }
    }


}
