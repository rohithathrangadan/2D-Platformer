using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    //static so that info is not lost on scene loads

    public static Vector2 lastCheckPointPos = new Vector2(-3, 0);// default starting pos of player

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        //store coin values , so that after exiting the game , if opened again the value persists.
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins",0);//this function will search for key: NumberOfCoins and fetch the value if it exists under a memmory location. If not it creates a new one with default value(0)

        isGameOver = false;//awake is usualy used to set up global variables like isGameOver
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;//on level reload lastChekPointPos gets updated
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(numberOfCoins);
        coinsText.text =  numberOfCoins.ToString();

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reload current scene using its build index
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuScreen.SetActive(false);

    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
