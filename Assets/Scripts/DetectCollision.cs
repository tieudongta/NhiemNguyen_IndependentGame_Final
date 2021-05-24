using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private CarController carCtrl;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
