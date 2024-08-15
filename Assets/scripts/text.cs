using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Message(string message){
        StartCoroutine(Print());

        IEnumerator Print(){
            GameObject text;
            TMP_Text textObj;
            text=transform.gameObject;
            textObj=text.GetComponent<TMP_Text>();
            textObj.text=message;
            yield return new WaitForSeconds(2f);
            Clear();
        }
        
    }

    public void Clear(){
        GameObject text;
        TMP_Text textObj;
        text=transform.gameObject;
        textObj=text.GetComponent<TMP_Text>();
        textObj.text="";
    }
}
