using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HMTagsManager : MonoBehaviour
{
    public GameObject[] tags;
    // Start is called before the first frame update
    void Start()
    {
        int length = VisualizerSettingsAndData.instance.vehicles.Length;
        for (int i = 0; i < length; i++)
        {
            tags[i].SetActive(true);
        }
    }

}
