using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpinner : MonoBehaviour
{
    public GameObject[] cubes;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey("return"))
        // {
        //     Flipcubes("hello");
        // }
    }

    public void Flipcubes(string word)
    {
        GameObject cube;

        // Debug.Log(word);
     
        for (int i=0; i<=4; i++)
        {
            cube = cubes[i];
            coroutine = WaitAndFlip((float)(i*0.9), cube);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitAndFlip(float delay, GameObject thiscube)
    {
        yield return new WaitForSeconds(delay);
        thiscube.GetComponent<cubeController>().Spin();
        // thiscube.GetComponent<Renderer>().material.color = new Color(198/255, 255/255, 181/255);
    }

}