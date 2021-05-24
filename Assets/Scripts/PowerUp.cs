using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timer;
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.GetComponent<CountDown>().CountDowner += 10;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.1f);
        }
    }
}
