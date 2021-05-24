using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    public float speed = 10.0f;
    public CarController carCtr;
    // Start is called before the first frame update
    void Start()
    {
        carCtr = GameObject.Find("Player").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carCtr.gameOver)
        {
            speed = 0.0f;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            Destroy(gameObject);
        }
        
    }
}
