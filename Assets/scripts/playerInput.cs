using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerInput : MonoBehaviour
{
    public GameObject[] tiles;
    [SerializeField]
    public List <string> cubes = new List<string>();
    char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    public string letter;
    public GameObject parent;
    public int count=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int index = 0; index < alphabet.Length; index++) 
        {
            letter=alphabet[index].ToString();
            if(Input.GetKeyDown(letter)){
                if(cubes.Count<=4)
                {
                    Add(count); 
                    count+=1;   
                }
                break;
                                            
            }
        }

        if(Input.GetKeyDown("backspace")){
            if(cubes.Count>0)
            {
                count-=1;
                Pop();
            }
            
        }
    }

    void Add(int count)
    {
 
        GameObject thisTile=tiles[count];
        GameObject text;
        letter=letter.ToUpper();
        cubes.Add(letter);
        TMP_Text textObj;
        text=thisTile.transform.GetChild(0).gameObject;
        textObj=text.GetComponent<TMP_Text>();
        textObj.text=letter;

                
    }

    void Pop()
    {
        if(cubes.Count!=0)
        {
            cubes.RemoveAt(cubes.Count-1);
            GameObject thisTile=tiles[cubes.Count];
            GameObject text;
            TMP_Text textObj;
            text=thisTile.transform.GetChild(0).gameObject;
            textObj=text.GetComponent<TMP_Text>();
            textObj.text="";
        }
    }
}  

