using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    public int Score;
    public float TimeLeft;
    public bool gameOver = false;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textGameOver;
    public Button restartBtn;
    public float restartDelay;
    public GameObject titleScreen;
    public bool gameActive = false;
    public GameObject spawnManager;
    public GameObject mailGenerator;
    public GameObject timer;
    public GameObject instructionScreen;
    public GameObject creditScreen;
    //---------------
    void Awake()
    {
        titleScreen.gameObject.SetActive(true);
        //ThisInstance = this;
        TimeLeft = 1;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score: " + Score;
        textTime.text = "Timer: " + TimeLeft;
        if (TimeLeft <= 0)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            textGameOver.gameObject.SetActive(true);
            restartBtn.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        spawnManager.gameObject.SetActive(true);
        mailGenerator.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);
    }
    public void Instruction()
    {
        instructionScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        instructionScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }
    public void Credit()
    {
        creditScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }
    public void ReturnToMainMenu1()
    {
        creditScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    //-----------

}
