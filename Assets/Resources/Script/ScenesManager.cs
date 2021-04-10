using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    Scenes scenes;
    float gameTimer = 0;
    float[] endLevelTimer = { 30, 30, 45 };
    int currentSceneNumber = 0;
    bool gameEnding = false;
  public enum Scenes
    {
        bootUp,
        title,
        shop,
        level1,
        level2,
        level3,
        gameover
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        GetComponent<GameManager>().SetLivesDisplay(GameManager.playerLives);
        if (GameObject.Find("score"))
        {
            GameObject.Find("score").GetComponent<Text>().text = ScoreManager.playerScore.ToString();
        }
    }

    private void Update()
    {
        if (currentSceneNumber != SceneManager.GetActiveScene().buildIndex)
        {
            currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            GetScene();
        }
        GameTimer();
    }
    void GetScene()
    {
        scenes = (Scenes)currentSceneNumber;
    }
    void GameTimer()
    {
        switch (scenes)
        {
            case Scenes.level1: case Scenes.level2: case Scenes.level3:
                {
                    if (gameTimer < endLevelTimer[currentSceneNumber - 3])
                    {
                        gameTimer += Time.deltaTime;
                    }
                    else
                    {
                        if (!gameEnding)
                        {
                            gameEnding = true;
                            if (SceneManager.GetActiveScene().name != "level3")
                            {
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTransition>().levelEnds = true;
                            }
                            else
                            {
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTransition>().GameCompleted = true;
                            }

                            Invoke("NextLevel", 4);
                        }
                        
                    }
                    break;
                }
                
        }
        
    }
    public void ResetScene()
    {
        gameTimer = 0;
        SceneManager.LoadScene(GameManager.currentScene);
    }

    void NextLevel()
    {
        gameEnding = false;
        gameTimer = 0;
        SceneManager.LoadScene(GameManager.currentScene + 1);
    }
  
    public void GameOver()
    {
	    Debug.Log("ENDSCORE:" + GameManager.Instance.GetComponent<ScoreManager>().PlayersScore);
        SceneManager.LoadScene("gameOver");
    }
  
    public void BeginGame(int gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }
}