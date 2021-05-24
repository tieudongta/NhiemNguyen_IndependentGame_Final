using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    //Maximum time to complete level (in seconds)
    public float MaxTime;
    //Countdown
    [SerializeField]
    public float CountDowner = 0;
    // Start is called before the first frame update

    public GameController gameCtr;
    void Start()
    {
        CountDowner = MaxTime;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        //Reduce time
        if (!gameCtr.gameOver)
        {
            CountDowner -= Time.deltaTime;
            gameCtr.TimeLeft = Mathf.Round(CountDowner);
        }
        
    }
}
