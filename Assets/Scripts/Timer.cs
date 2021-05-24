using UnityEngine;

public class Timer : MonoBehaviour
{
    //Maximum time to complete level (in seconds)
    public float MaxTime;
    //Countdown
    [SerializeField]
    private float CountDown = 0;
    // Start is called before the first frame update
    public GameController gameCtr;
    //public GameController gameController;
    void Start()
    {
        CountDown = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Reduce time
        if (gameCtr.gameOver)
        {
            Debug.Log("Stop count down.");
        }
        //CountDown -= Time.deltaTime;
        //gameCtr.TimeLeft = Mathf.Round(CountDown);
    }
}