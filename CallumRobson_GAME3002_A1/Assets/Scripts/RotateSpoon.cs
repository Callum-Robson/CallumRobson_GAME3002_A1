using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CalculationTools;


public class RotateSpoon : MonoBehaviour
{
    private float rotationRate = 360f;
    private Quaternion newAngle;
    //private Quaternion localSpaceRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotationRate = 120f;
            newAngle = new Quaternion(0, 0, -0.7114132f, 0.702774f);
            //localSpaceRotation = Quaternion.Inverse(transform.rotation) * newAngle;
        }
        if (transform.localRotation.z < -0.7114)
        {
            rotationRate = 100f;
            Debug.Log("Done");
            newAngle = new Quaternion(0, 0, 0, 1);
        }

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, newAngle, rotationRate * Time.deltaTime);
        Debug.Log(transform.rotation.z);
    }
}
