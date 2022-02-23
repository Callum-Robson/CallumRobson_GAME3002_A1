using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultMovement : MonoBehaviour
{
    private Quaternion rightRotation = new Quaternion(0, 0.0087265f, 0, 0.9999619f);
    private Quaternion leftRotation = Quaternion.Inverse(new Quaternion(0, 0.0087265f, 0, 0.9999619f));
    Vector3 localForward;
    Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Mouse x: " + Input.GetAxis("Mouse X"));
        transform.Rotate(0, (Input.GetAxis("Mouse X") * 100 )* Time.fixedDeltaTime, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += (this.transform.right * Time.fixedDeltaTime) ;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= (this.transform.right * Time.fixedDeltaTime) ;
        }
        //if (Input.GetKey(KeyCode.D))
        //{
        //    // transform.rotation = Quaternion.Slerp(transform.rotation, rightRotation, Time.deltaTime * 1);
        //    transform.Rotate(0, 100 * Time.fixedDeltaTime, 0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    // transform.rotation = Quaternion.Slerp(transform.rotation, leftRotation, Time.deltaTime * 1);
        //    transform.Rotate(0, -100 * Time.fixedDeltaTime, 0);
        //}
    }
}
