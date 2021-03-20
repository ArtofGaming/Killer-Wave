using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static int currentScene = 0;
    public static int gameLevelScenen = 3;
    public static int playerLives = 3;
    bool died = false;
    public bool Died
    {
        get { return died; }
        set { died = value; }
    }
    public static GameManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        CheckGameManagerIsInTheScene(); 
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; 
        LightandCameraSetup(currentScene);
        
    }
    void CheckGameManagerIsInTheScene()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
      void Start()
    {
        CameraSetup();
        LightSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LifeLost()
    {
        if (playerLives >= 1)
        {
            playerLives--;
            Debug.Log("Lives left: " + playerLives);
            GetComponent<ScenesManager>().ResetScene();
        }
        else
        {
            playerLives = 3;
            GetComponent<ScenesManager>().GameOver();
        }
    }
    void LightandCameraSetup(int sceneNumber)
    {
        switch (sceneNumber)
        {      //testLevel, Level1, Level2, Level3
            case 3:
            case 4:
            case 5:
            case 6:
                {
                    LightSetup();
                    CameraSetup();
                    break;
                }
        }
    }

    void CameraSetup()
    {
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameCamera.transform.position = new Vector3(0, 0, -300);
        gameCamera.transform.eulerAngles = new Vector3(0, 0, 0);
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        gameCamera.GetComponent<Camera>().backgroundColor = new Color32(0, 0, 0, 255);
    }
    void LightSetup()
    {
        GameObject dirLight = GameObject.Find("Directional Light");
        dirLight.transform.eulerAngles = new Vector3(50, -30, 0);
        dirLight.GetComponent<Light>().color = new Color(152, 204, 255, 255);
    }
}
