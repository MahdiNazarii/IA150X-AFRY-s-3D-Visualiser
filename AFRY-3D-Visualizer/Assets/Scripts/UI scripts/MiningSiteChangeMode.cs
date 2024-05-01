using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSiteChangeMode : MonoBehaviour
{
    private MeshRenderer miningSite;
    private MeshRenderer meshRenderer2;

    private void Start()
    {
        miningSite = this.gameObject.GetComponent<MeshRenderer>();
    }
    public void TurnOffMiningSite()
    {
        //this.gameObject.SetActive(false);
        miningSite.enabled = false;
    }
    public void TurnOnMiningSite()
    {
        miningSite.enabled = true;
    }
}
