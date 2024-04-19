using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSiteChangeMode : MonoBehaviour
{

    public void TurnOffMiningSite()
    {
        this.gameObject.SetActive(false);
    }
    public void TurnOnMiningSite()
    {
        this.gameObject.SetActive(true);
    }
}
