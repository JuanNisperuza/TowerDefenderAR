using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionManager : MonoBehaviour
{
    public static ARInteractionManager Instance;
    [SerializeField] private Camera aRCamera;
    [SerializeField] private ARPlaneManager aRPlaneManager;
    [SerializeField] private ARRaycastManager aRRaycastManager;
    [SerializeField] private ARPointCloudManager aRPointManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject scenaryPrefab;
    private GameObject Scenary;
    private bool isInitPosition;
    float previousDistance;
    bool editable = true;
    bool isPinching = false;
    public GameObject TestScenary;
    public bool isScaling = false;


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
        isInitPosition = false;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !isInitPosition)
        {
            SetScenary();
        }

        if (isInitPosition && editable)
        {
            if (Input.touchCount > 0)
            {
                if (Input.touchCount == 1)
                {
                    MoveScenary();
                }
                else if (Input.touchCount == 2)
                {
                    if (isScaling)
                    {
                        ScaleScenary();
                    }
                    else
                    {
                        RotateScenary();
                    }
                }
            }
            else if (Input.touchCount == 0)
            {
                isPinching = false;
            }
        }
    }

    public void EditModeEnd()
    {
        editable = false;
    }

    public void ScaleScenary()
    {
        Vector2 touch0 = Input.GetTouch(0).position;
        Vector2 touch1 = Input.GetTouch(1).position;
        float currentDistance = Vector2.Distance(touch0, touch1);

        if (!isPinching)
        {
            isPinching = true;
            previousDistance = currentDistance;
        }
        else
        {
            float scaleMultiplier = currentDistance / previousDistance;
            Vector3 newScale = Scenary.transform.localScale * scaleMultiplier;
            if (newScale.x > 0 && newScale.y > 0 && newScale.z > 0)
            {
                Scenary.transform.localScale = newScale;
                previousDistance = currentDistance;
            }
        }
    }
    public void MoveScenary()
    {
        Vector3 currentPosition = Scenary.transform.position;
        float horizontalDelta = Input.GetTouch(0).deltaPosition.x * 0.001f;
        currentPosition.x += horizontalDelta;
        float horizontalDeltay = Input.GetTouch(0).deltaPosition.y * 0.001f;
        currentPosition.z += horizontalDeltay;
        Scenary.transform.position = currentPosition;
    }

    public void RotateScenary()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            float deltaX = touch.deltaPosition.x;
            Scenary.transform.Rotate(Vector3.up, deltaX * 0.5f);
        }
    }

    public void SetScenary()
    {
        if (!isInitPosition)
        {
            Vector2 middelPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            aRRaycastManager.Raycast(middelPoint, hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                isInitPosition = true;
                scenaryPrefab.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Scenary = Instantiate(scenaryPrefab, hits[0].pose.position, hits[0].pose.rotation);
                GameManager.Instance.SetScenary(Scenary);
                aRPointManager.enabled = false;
                aRPlaneManager.enabled = false;
                ARPlane[] planes = FindObjectsOfType<ARPlane>();
                foreach (ARPlane item in planes)
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }

    public void ChangeEditMode()
    {
        isScaling = !isScaling;
    }
}


