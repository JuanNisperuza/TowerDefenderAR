using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI SelectAreaText;
    [SerializeField] private TextMeshProUGUI AdjustModelText;
    [SerializeField] public TextMeshProUGUI ScoreText;
    [SerializeField] public TextMeshProUGUI CashText;
    [SerializeField] private TextMeshProUGUI rotateText;
    [SerializeField] private TextMeshProUGUI scaleText;
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] private Button SetButton;
    [SerializeField] private Button Options;
    [SerializeField] private Button Shop;
    [SerializeField] private Button PlayButton;
    [SerializeField] private ScrollRect TurretsContainer;
    [SerializeField] private GameObject ToggleEdit;
    [SerializeField] public Image healthSlider;
    [SerializeField] public Image health;
    [SerializeField] private GameObject gameOver;
    public AudioClip buttonSound;


    float playAnimSpeed = 430f;
    bool isShopOpen;

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
        PlayButton.transform.DOMoveY(playAnimSpeed, 2f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    public void InitUIWorkFlow()
    {
        SelectAreaText.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        AdjustModelText.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        SetButton.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        ToggleEdit.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        rotateText.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        scaleText.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }

    public void InitGame()
    {
        AdjustModelText.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        SetButton.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        ToggleEdit.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        rotateText.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        scaleText.transform.DOScale(new Vector3(0, 0, 0), 0.5f);

        Options.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        Shop.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        ScoreText.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        CashText.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        health.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        timerText.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }

    public void ChangeShopStatus()
    {
        if (!isShopOpen)
        {
            TurretsContainer.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
            TurretsContainer.transform.DOMoveY(600, 0.3f, true);
            isShopOpen = true;
        }
        else
        {
            TurretsContainer.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
            TurretsContainer.transform.DOMoveY(-600, 0.5f, true);
            isShopOpen = false;
        }
    }

    public void ButtonSound()
    {
        AudioManager.PlaySound(buttonSound);
    }

    public void GameOverUI()
    {
        gameOver.SetActive(true);
    }

}
