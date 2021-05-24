using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public GameObject[] vehiclePrefabs1;
    public GameController gameCtrl;
    // Start is called before the first frame update
    void Start()
    {
        float randomInterval = Random.Range(10.5f, 20.0f);
        InvokeRepeating("SpawnRandomVehicle", 10.0f, randomInterval);
        InvokeRepeating("SpawnRandomVehicle1", 6.0f, randomInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomVehicle()
    {
        if (!gameCtrl.gameOver)
        {
            int vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
            Vector3 startingPos = new Vector3(-70, 1, -100);
            Instantiate(vehiclePrefabs[vehicleIndex], startingPos, vehiclePrefabs[vehicleIndex].transform.rotation);
        }
    }
    void SpawnRandomVehicle1()
    {
        if (!gameCtrl.gameOver)
        {
            int vehicleIndex = Random.Range(0, vehiclePrefabs1.Length);
            Vector3 startingPos = new Vector3(-180, 1, -17);
            Instantiate(vehiclePrefabs1[vehicleIndex], startingPos, vehiclePrefabs1[vehicleIndex].transform.rotation);
        }
    }
}
