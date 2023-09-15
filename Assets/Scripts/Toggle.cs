using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject point;
    bool isActive = true;
    public void TogglePressed()
    {
        if (isActive)
        {
            point.transform.localPosition = new Vector3(-50, 0, 0);
            isActive = false;
        }
        else
        {
            point.transform.localPosition = new Vector3(50, 0, 0);
            isActive = true;
        }

    }
}
