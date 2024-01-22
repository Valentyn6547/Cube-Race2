using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded = false;
    public float restartDelay = 0.2f;
    public GameObject compleatLevelUI;
    public GameObject endAnimReverseUI;
    public GameObject addForcePlanes;
   
    void Start()
    {
        Cursor.visible = false;
        gameHasEnded = false;
        endAnimReverseUI.SetActive(true);
    }
    void Awake()
    {
      
        ChangeLevelDifficult();
    }
    public void ChangeLevelDifficult()
    {
        OptionsData data = SaveSystem.LoadOptionsData();
        int LevelDf = data.levelDifficulty;
        float speed = 0;
        float sideSpeed = 0;
        string LevelDifficulty = "";
        switch (LevelDf)
        {
            case 0:
                speed = 4000;
                AddForceTrigger.addForceSpeed = 4500;
                sideSpeed = 50;
                LevelDifficulty = "Easy";
                break;
            case 1:
                speed = 6000;
                AddForceTrigger.addForceSpeed = 1000;
                sideSpeed = 60;
                LevelDifficulty = "Normal";
                break;
            case 2:
                speed = 7000;
                addForcePlanes.SetActive(false);
                sideSpeed = 70;
                LevelDifficulty = "Hard";
                break;

        }
        FindObjectOfType<PlayerMovement>().speed = speed;
        FindObjectOfType<PlayerMovement>().sideSpeed = sideSpeed;
        FindObjectOfType<Objects>().LevelDifficulty.text = "LevelDifficulty : " + LevelDifficulty;
        FindObjectOfType<SettingsMenu>().SetVolume(data.volume);
    }
    public void CompleatLevel()
    {
        if (gameHasEnded == false)
        {
            compleatLevelUI.SetActive(true);
            FindObjectOfType<CompleatedLevels>().Win();
            Cursor.visible = true;
        }
    


    }
    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("Game Over!");
            gameHasEnded = true;
          
            Invoke("Restart",restartDelay);
        }
      
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
