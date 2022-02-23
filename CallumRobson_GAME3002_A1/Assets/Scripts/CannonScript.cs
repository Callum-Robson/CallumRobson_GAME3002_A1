using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Vi = sqrt(distance* gravity) / sin(2theta)
//Vx = V sin (theta)
//Vy = V cos (theta)

// catapult begin spawn location -7.95, 2.84, 0
// catapult end spawn location 8.54, 79.432, 0 

public class CannonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cannonballInstance;

    [SerializeField]
    private GameObject invisibleBallInstance;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Transform dest;

    [SerializeField]
    private Transform destInstance;


    // Create angle variable clamped between 10 and 80 degrees
    [SerializeField]
    [Range(10f, 80f)]
    private float angle = 45f;

    // Create barrelSpeed variable clamped between 10 and 50
    [SerializeField]
    [Range(10f, 50f)]
    private float barrelSpeed = 10f;


    private Transform oldTransform;
    private Transform oldDest;
    private float oldAngle;
    GameObject invisibleBall;
    private bool timeToDestroy = false;

    private Rigidbody invisibleBallRigidBody;


    private void Update()
    {
        oldTransform = this.transform;
        oldDest = dest;
        oldAngle = angle;

        if (Input.GetKeyDown(KeyCode.Space))
        {
                // Pass the point in wolrd the ray hit to the FireCannonAtPoint function
                FireCannonAtPoint(dest.position);//hitInfo.point);
        }
        // Decreases angle
        if (Input.GetKey(KeyCode.I))
        {
            angle = Mathf.Clamp(angle - barrelSpeed * Time.deltaTime, 10f, 80f);
        }
        // Increases angle
        if (Input.GetKey(KeyCode.K))
        {
            angle = Mathf.Clamp(angle + barrelSpeed * Time.deltaTime, 10f, 80f);
        }
        transform.eulerAngles = new Vector3(0f, 0f, 90f - angle);

        Debug.Log(this.transform.parent.name);


        if (oldTransform != this.transform || oldAngle != angle || oldDest != dest ||
                this.transform.parent.GetComponent<Rigidbody>().velocity != new Vector3(0.0f, 0.0f, 0.0f))// && Input.GetMouseButton(1))
        {
            GameObject.Destroy(invisibleBall, 0.05f);
            DrawPath();

        }
        else if ( !Input.GetMouseButton(1))
        {
            GameObject.Destroy(invisibleBall, 4.93f);
        }
     
    }
    private void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            dest.localPosition += new Vector3(Input.GetAxis("Mouse ScrollWheel") * 50, 0f, 0f);
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            dest.localPosition -= new Vector3(Input.GetAxis("Mouse ScrollWheel") * -50, 0f, 0f);
        //GetAxis("Mouse ScrollWheel") * Time.deltaTime) / 10000)
    }



    private void FireCannonAtPoint(Vector3 point)
    {
        // Create velocity variable, set to return value of BallisticVelocity function
        // Pass point and angle to BallisticVelocity function
        var velocity = BallisticVelocity(point, angle);
        Debug.Log("Firing at " + point + " velocity " + velocity);

        // Set cannonballInstance layer to "Ball", the body of the catapult is on another layer
        // so they wont collide with eachother
        cannonballInstance.layer = LayerMask.NameToLayer("Ball");

        // Create instance of cannonball object, spawn at spawnPoint, identity quaternion so it has no rotation
        GameObject cannonBall = GameObject.Instantiate(cannonballInstance, spawnPoint.position, Quaternion.identity);
        cannonBall.layer = LayerMask.NameToLayer("Ball");
        Debug.Log("CannonBall starting at" + cannonBall.transform.position);

        // Set cannonBall's velocity to the calculated velocity
        cannonBall.GetComponent<Rigidbody>().velocity = velocity;

        // Destroy cannonBall after 8 seconds
        GameObject.Destroy(cannonBall, 6.0f);
        // transform.parent.gameObject.GetComponent<DrawProjectilePath>().Invoke("DestroyPath", 6.0f);
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        // Already explained...
        Vector3 dir = destination - spawnPoint.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
       // dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        Debug.Log("Velocity: " + velocity * dir.normalized);
        Debug.Log("Velocity: " + velocity * dir.normalized * 10.0f);
        return velocity * dir.normalized; // Return a normalized vector.
    }



    private void DrawPath()
    {
        Debug.Log("Calling Draw Path");
        // Create velocity variable, set to return value of BallisticVelocity function
        // Pass point and angle to BallisticVelocity function
        var velocity = BallisticVelocity(dest.position, angle);

        // Create instance of cannonball object, spawn at spawnPoint, identity quaternion so it has no rotation
        invisibleBall = GameObject.Instantiate(invisibleBallInstance, spawnPoint.position, Quaternion.identity);
        invisibleBall.transform.parent = gameObject.transform;

        // Set cannonBall's velocity to the calculated velocity
        invisibleBall.GetComponent<Rigidbody>().velocity = velocity * 10.0f;
        Debug.Log("Velocity new:  " + invisibleBall.GetComponent<Rigidbody>().velocity);
        if (timeToDestroy == true)
        {
            foreach (GameObject child in invisibleBall.transform)
            {
                Debug.Log("destroying children");
                GameObject.Destroy(child);
            }
        }
    }

    private void FixedUpdate()
    {
        if (invisibleBall != null)
        {
            invisibleBall.GetComponent<Rigidbody>().AddForce(Physics.gravity * (90.5f - 1), ForceMode.Acceleration);
            Debug.Log("BallInstance positon: " + invisibleBall.transform.position);
            Debug.Log("Adding extra gravity");
        }
    }


}

// Credits: https://unity3d.college/2017/06/30/unity3d-cannon-projectile-ballistics/
//          http://answers.unity3d.com/comments/236712/view.html