using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCardCreator : MonoBehaviour
{
    private string buildName;
    private Sprite buildImage;
    private GameObject model;
    private int price;
    GameManager gameManager = GameManager.Instance;

    #region Setters
    public string BuildName
    {
        set
        {
            buildName = value;
        }
    }

    public Sprite BuildImage
    {
        set
        {
            buildImage = value;
        }
    }

    public GameObject Model
    {
        set
        {
            model = value;
        }
    }

    public int Price
    {
        set
        {
            price = value;
        }
    }
    #endregion

    private void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buildName;
        transform.GetChild(1).GetComponent<RawImage>().texture = buildImage.texture;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = price.ToString();

        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelectTurret);
    }

    private void SelectTurret()
    {
        if (gameManager.Money >= price)
        {
            ShopManager.Instance.Buy(model, price);
            foreach (GameObject hex in gameManager.availableHex)
            {
                gameManager.defaultMaterial = hex.GetComponent<MeshRenderer>().material;
                hex.GetComponent<MeshRenderer>().material = gameManager.selectableMaterial;
            }
        }
    }
}