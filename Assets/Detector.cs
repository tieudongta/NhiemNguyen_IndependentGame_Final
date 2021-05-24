using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        this.transform.parent.GetComponent<MovingForward>().speed = 0.0f;
    }
    private void OnCollisionExit(Collision collision)
    {
        this.transform.parent.GetComponent<MovingForward>().speed = 10.0f;
    }
}
