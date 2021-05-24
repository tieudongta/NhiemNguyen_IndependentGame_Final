using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailSpawn : MonoBehaviour
{
    GameObject[] mailpoles;
    public GameObject mailDrop;
    public GameObject powerUp;
    private int waveNum = 1;
    private int mailCount;
    public CountDown countDown;
    // Start is called before the first frame update
    void Start()
    {
        mailpoles = GameObject.FindGameObjectsWithTag("Pole");
        SpawnWave(waveNum);
    }

    private void SpawnWave(int waveNum)
    {
        int[] randNums = uniqueRandomNumbers(0, mailpoles.Length, waveNum);
        for (int i = 0; i < waveNum; i++)
        {
            Instantiate(mailDrop, mailpoles[randNums[i]].transform.position, mailDrop.transform.rotation);
        }
        int num = UnityEngine.Random.Range(0, mailpoles.Length);
        Instantiate(powerUp, mailpoles[num].transform.position, mailDrop.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        mailCount = GameObject.FindGameObjectsWithTag("MailBox").Length;
        if (mailCount == 0)
        {
            waveNum++;
            SpawnWave(waveNum);
            countDown.CountDowner += 30;
        }
    }
    private static int[] uniqueRandomNumbers(int min, int max, int howMany)
    {
        // check for impossible combinations
        if (howMany > max - min)
            throw new ArgumentException(String.Format("Range {0}-{1} is too small to have {2} unique random numbers.", min, max, howMany));

        int[] myNumbers = new int[howMany];

        // special case for range and howMany being equal
        if (howMany == max - min)
        {
            // Linq version
            // return Enumerable.Range(min, howMany).ToArray();

            // for loop version
            for (int i = 0; i < howMany; i++)
                myNumbers[i] = i;
            return myNumbers;
        }

        // actual generation of random numbers
        System.Random randNum = new System.Random();
        for (int currIndex = 0; currIndex < howMany; currIndex++)
        {
            // generate a candidate
            int randCandidate = randNum.Next(min, max);

            // generate a new candidate as long as we don't get one that isn't in the array
            while (Array.IndexOf(myNumbers, randCandidate)==0)
            {
                randCandidate = randNum.Next(min, max);
            }

            myNumbers[currIndex] = randCandidate;
        }

        return myNumbers;
    }
}
