using UnityEngine;
using TMPro;


public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    // Scripts
    [HideInInspector]
    public Player player;
    [HideInInspector]
    public PlayerUpgradeManager playerUpgradeManager;
    SaveManager saveManager;
    LevelManager lm;
    HighScoreManager highScoreManager;
    UpgradeManager upgradeManager;

    //GameObjects
    [Header("GameObjects")]
    public GameObject gameOverUI;
    public GameObject winUI;
    public GameObject eventSystem;
    public GameObject Player;

    //Transforms
    private Transform spawnPlayerTransformRef;

    //Camera
    private CameraFollow cameraFollow;
    
    //UI
    [HideInInspector]
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI swipesText;
    public TextMeshProUGUI moneyMultiplier;

    //Normal Variables
    [Header("Variables")]
    public bool canHarmPlayer = true;

    [HideInInspector]
    public int coinCache;
    public static GameMaster instance;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        lm = GetComponent<LevelManager>();
        saveManager = GetComponent<SaveManager>();
        highScoreManager = GetComponent<HighScoreManager>();
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(gameOverUI);
        DontDestroyOnLoad(winUI);
        DontDestroyOnLoad(eventSystem);
    }

    void Start()
    {
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        SearchForMenuElements();
        coinCache = 0;
    }

    public void UpdateNumberOfUpgradesText()
    {
        //if(player!=null)
            //swipeText.text = player.swipes.ToString();
    }

    //Player Specific
    #region Player
    public void SpawnPlayer()
    {
        Transform playerSpawnLocation = GameObject.Find("PlayerSpawnLocation").transform;

        if (playerSpawnLocation != null)
        {
            spawnPlayerTransformRef = playerSpawnLocation;
            GameObject playerPrefab = Instantiate(Player, playerSpawnLocation.position, playerSpawnLocation.rotation);
            player = playerPrefab.GetComponent<Player>();
            playerUpgradeManager = playerPrefab.GetComponent<PlayerUpgradeManager>();
            saveManager.player = player;
            saveManager.playerUpgradeManager = playerUpgradeManager;

            highScoreManager.player = player;
   
            lm.GetCurrentSceneIndex();
            if (lm.currentSceneIndex == 0)
            {
                DisablePlayer();
            }
            else
            {
                EnablePlayer();
                cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
                cameraFollow.target = playerPrefab.transform;
            }


            //If we in the menu then keep player disabled but there so we can apply changed to it

            coinCache = 0;
            saveManager.LoadPlayer();

        }
        else
        {
            Debug.Log("Cannot Find Spawn Transform");
        }

        // Do not spawn player in the main menu
        
        
    }

    public void EnablePlayer()
    {
        player.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        player.gameObject.GetComponent<Drag_Shoot>().enabled = true;
        canHarmPlayer = true;

    }

    public void DisablePlayer()
    {
        player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        player.gameObject.GetComponent<Drag_Shoot>().enabled = false;
        canHarmPlayer = false;

    }

    public void AddCurrency(int amount)
    {
        player.currency += amount;
        UpdateCurrencyText();
    }

    #endregion

    public void UpdateCurrencyText()
        {
            if(currencyText != null && player != null)
            {
                currencyText.text = player.currency.ToString();
            }
            
        }

    // Scene Region
    #region Level
    public void NextLevel()
    {
        
        winUI.SetActive(false);
        coinCache = 0;
        Debug.Log("Loading Player");
        AudioManager.instance.StopSound("Applause");
    }

    public void ResetLevel()
    {
        Debug.Log("Resetting Level");
        gameOverUI.SetActive(false);
        EnablePlayer();
        player.transform.position = spawnPlayerTransformRef.position;
        cameraFollow.target = player.transform;

        GameObject[] coinArray = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coinArray)
        {
            if(coin.GetComponent<BoxCollider2D>().enabled == false)
            {
                coin.GetComponent<BoxCollider2D>().enabled = true;
                coin.GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log(coinCache);
                AddCurrency(-coinCache);
            }
        }

        coinCache = 0;
        

    }

    public void SearchForMenuElements()
    {
        if(currencyText == null)
        {
            currencyText = GameObject.Find("Currency").GetComponent<TextMeshProUGUI>();
        }
        
    }

    public void WinGame()
    {
        
        //Add an attempt
        highScoreManager.ApplyAttempts();

        //Add to currency

        winUI.SetActive(true);
        //Disable Player Aswell
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        //Disable Cam Follow
        cameraFollow.target = null;
        AudioManager.instance.PlaySound("Applause");
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true);
        cameraFollow.target = null;
        winUI.SetActive(false);
    }
    #endregion

}
