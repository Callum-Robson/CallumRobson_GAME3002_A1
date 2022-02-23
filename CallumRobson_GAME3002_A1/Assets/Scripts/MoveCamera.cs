using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(-1.353752f, 1.217865f, 11.82981f);
            transform.rotation = Quaternion.Euler(-37.303f, 40.772f, -8.936f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = new Vector3(0, 5.71284f, -9.544323f);
            transform.rotation = Quaternion.Euler(25f, 0, 0);
        }
    }
}
