using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{
    public float SpinSpeed=100.0f;
    public bool IsSpin=false;
    public Quaternion StartAngle;
    
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (IsSpin)
        {
            if(Quaternion.Angle(transform.rotation,StartAngle)<179.0f)
            {
               transform.Rotate(Time.deltaTime*SpinSpeed,0,0); 
            }
            else
            {
                IsSpin=false;
                //SpinSpeed=0.0f;
                // Debug.Log(180.0f-Quaternion.Angle(transform.rotation,StartAngle));
                transform.Rotate(180.0f-Quaternion.Angle(transform.rotation,StartAngle),0,0);
            }
            
            
        }
    }


    public void Spin()
    {
        StartAngle=transform.rotation;
        IsSpin=true;
        // Debug.Log(StartAngle);
        //SpinSpeed=200.0f;
    }

    void StopSpin()
    {
        IsSpin=false;
        //SpinSpeed=0.0f;
        // Debug.Log(180.0f-Quaternion.Angle(transform.rotation,StartAngle));
        transform.Rotate(180.0f-Quaternion.Angle(transform.rotation,StartAngle),0,0);
    }

}
