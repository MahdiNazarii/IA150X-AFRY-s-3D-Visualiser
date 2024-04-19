using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSiteChangeMode : MonoBehaviour
{
    private MeshRenderer meshRenderer1;
    private MeshRenderer meshRenderer2;

    private void Start()
    {
        MeshRenderer[] meshRenderers = this.gameObject.GetComponentsInChildren<MeshRenderer>();

        meshRenderer1 = meshRenderers[0];
        meshRenderer2 = meshRenderers[1];
    }
    public void TurnOffMiningSite()
    {
        //this.gameObject.SetActive(false);
        meshRenderer1.enabled = false;
        meshRenderer2.enabled = false;
    }
    public void TurnOnMiningSite()
    {
        meshRenderer1.enabled = true;
        meshRenderer2.enabled = true;

    }
}
