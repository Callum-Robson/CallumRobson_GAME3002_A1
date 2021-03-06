using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVectors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnDrawGizmos()
    {
        Color color;
        //color = Color.green;
        //// local up
        //DrawHelperAtCenter(this.transform.up, color, 2f);

        //color.g -= 0.5f;
        //// global up
        //DrawHelperAtCenter(Vector3.up, color, 1f);

        color = Color.blue;
        // local forward
        DrawHelperAtCenter(this.transform.forward, color, 2f);

        //color.b = 0.0f;
        //color.r = 1.0f;
        //color.g = 0;
        //color.a = 1;

        //global forward
        //DrawHelperAtCenter(Vector3.forward, color, 1f);

        color = Color.red;
        // local right
        DrawHelperAtCenter(this.transform.right, color, 2f);

        //color.r -= 0.5f;
        //// global right
        //DrawHelperAtCenter(Vector3.right, color, 1f);
    }

    private void DrawHelperAtCenter(
                       Vector3 direction, Color color, float scale)
    {
        Gizmos.color = color;
        Vector3 destination = transform.position + direction * scale;
        Gizmos.DrawLine(transform.position, destination);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
