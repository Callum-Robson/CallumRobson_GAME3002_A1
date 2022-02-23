using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject goalInstance;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOAL");
        GameObject goal1 = GameObject.Instantiate(goalInstance, this.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
        GameObject.Destroy(goal1, 2.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
