using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjectilePath : MonoBehaviour
{
    private GameObject[] lineList = new GameObject[2000];
    private Vector3 lastPosition;
    public Shader lineShader;
    private float duration;
    private int lineIndex;

    Coroutine callDestroyPath;
    [SerializeField]
    private bool RealBall;

    public void DestroyPath()
    {
        Debug.Log("Invoked");
        for (int i = 0; i < lineList.Length; i++)
        {
            GameObject.Destroy(lineList[i], 0.0f);
            //GameObject.DestroyImmediate(lineList[i]);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        lastPosition = transform.position;
        // Destroy cannonBall after 8 seconds
        //GameObject.Destroy(transform.parent.gameObject, 6.0f);
        //Invoke("DestroyPath", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Draw a line between current position and last position, color is green, last for 6 seconds
        if (RealBall == true)
        {
            duration = 0.5f;
        }
        else
        {
            duration = Time.deltaTime * 5;
        }
     
        if (RealBall == true)
        {
            DrawLine(transform.position, lastPosition, Color.green, duration);
            lastPosition = transform.position;
        }
        else
        {
            DrawLine2(transform.position, lastPosition, Color.red, duration);
            lastPosition = transform.position;
        }
    }



    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        if (end.y > 0.0f)
        {
            GameObject myLine = new GameObject();
            myLine.transform.position = start;
            myLine.AddComponent<LineRenderer>();
            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
            lr.startColor = color;
            lr.endColor = color;
            lr.startWidth = 0.05f;
            lr.endWidth = 0.05f;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
            GameObject.Destroy(myLine, duration);
        }
        else
            return;
    }

    void DrawLine2(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        //GameObject myLine = new GameObject();
        //myLine.transform.position = start;
        //myLine.AddComponent<LineRenderer>();
        //LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        //lr.startColor = color;
        //lr.endColor = color;
        //lr.startWidth = 0.05f;
        //lr.endWidth = 0.05f;
        //lr.SetPosition(0, start);
        //lr.SetPosition(1, end);
        //lineList[lineIndex] = myLine;
        ////GameObject.Destroy(myLine, 0.0f);
        //Debug.Log("Number of lines" + lineIndex);
        //lineIndex++;
        if (end.y > 0.0f)
        {
            lineList[lineIndex] = new GameObject();
            lineList[lineIndex].transform.parent = gameObject.transform;
            lineList[lineIndex].transform.position = start;
            lineList[lineIndex].AddComponent<LineRenderer>();
            LineRenderer lr = lineList[lineIndex].GetComponent<LineRenderer>();
            lr.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
            lr.startColor = color;
            lr.endColor = color;
            lr.startWidth = 0.05f;
            lr.endWidth = 0.05f;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
            //GameObject.Destroy(myLine, 0.0f);
            Debug.Log("Number of lines" + lineIndex);
            lineIndex++;
        }
    }

}
