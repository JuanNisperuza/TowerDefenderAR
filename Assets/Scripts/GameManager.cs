using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public WaveSpawner waveSpawner;
    public bool scenaryPlaced = false;
    public GameObject scenaryGO;
    public GameObject[] availableHex;
    public Material selectableMaterial;
    public Material defaultMaterial;

    private UIManager uiManager;

    private int money;
    private int score;
    private float life;

    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            uiManager.CashText.text = money.ToString();
        }
    }

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            uiManager.ScoreText.text = value.ToString();
        }
    }

    public float Life
    {
        get { return life; }
        set
        {
            life = value;
            if (life > 0)
            {
                uiManager.healthSlider.fillAmount = life / 100.0f;
            }
            else
            {
                uiManager.GameOverUI();
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        uiManager = UIManager.Instance;
        Money = 200;
        Life = 100;
    }

    public void SetScenary(GameObject scenary)
    {
        uiManager.InitUIWorkFlow();
        waveSpawner.spawnPoint = GameObject.FindWithTag("Spawner").transform;
        waveSpawner.scenaryPlaced = true;
        scenaryGO = scenary;
        GetComponent<ShopManager>().CreateCards();
        availableHex = GameObject.FindGameObjectsWithTag("buildable");
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}