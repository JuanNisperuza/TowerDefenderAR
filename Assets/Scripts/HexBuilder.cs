using UnityEngine;

public class HexBuilder : MonoBehaviour
{

    ShopManager shopManager;
    private void Start()
    {
        shopManager = ShopManager.Instance;
    }
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("buildable"))
                    {
                        GameManager.Instance.Money -= shopManager.currentPrice;
                        GameObject TurretGO = Instantiate(ShopManager.Instance.currentBuild, hit.point, hit.transform.rotation);
                        shopManager.turretSelected = false;
                        shopManager.currentBuild = null;
                        shopManager.currentPrice = 0;
                        foreach (GameObject hex in GameManager.Instance.availableHex)
                        {
                            hex.GetComponent<MeshRenderer>().material = GameManager.Instance.defaultMaterial;
                        }
                    }
                }
            }
        }
    }
}

