using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject[] rows;
    public int c=0;
    bool done=false;
    // Start is called before the first frame update
    void Start()
    {
        for (int r=0; r<6; r++)
        {
            var row=rows[r];
            MonoBehaviour[] scripts = row.GetComponents<MonoBehaviour>();
            foreach(MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }
        

        nextRow();

        //  for (int i=0; i<6; i++)
        // {
            
            
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextRow()
    {
        if (done==false){
            // Debug.Log(c);
            if (c<6){
                if (c>0){
                        MonoBehaviour[] previous = rows[c-1].GetComponents<MonoBehaviour>();
                        foreach(MonoBehaviour script in previous)
                        {
                            script.enabled = false;
                        }
                    }

                    MonoBehaviour[] s = rows[c].GetComponents<MonoBehaviour>();
                    foreach(MonoBehaviour script in s)
                    {
                        script.enabled = true;
                    }
                    c+=1;
            }
            else if (c==6){
                c+=1;
                done=true;
            }
        }
        
       
    }
}
