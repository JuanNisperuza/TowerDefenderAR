using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    [SerializeField] private List<Build> buildings = new List<Build>();
    [SerializeField] private GameObject Container;
    [SerializeField] private ShopCardCreator cardCreator;
    public GameObject currentBuild;
    public bool turretSelected;
    public int currentPrice;
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
    public void CreateCards()
    {
        foreach (Build build in buildings)
        {
            ShopCardCreator card;
            card = Instantiate(cardCreator, Container.transform);
            card.BuildName = build.BuildName;
            card.BuildImage = build.BuildImage;
            card.Model = build.Model;
            card.Price = build.Price;

        }
    }

    public void Buy(GameObject model, int price)
    {
        currentBuild = model;
        turretSelected = true;
        currentPrice = price;
    }
}
