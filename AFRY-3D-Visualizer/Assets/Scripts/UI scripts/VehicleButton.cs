using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VehicleButton : MonoBehaviour
{
    public TextMeshProUGUI vehicleText;

    public void SetVehicleText(string machineName)
    {
        vehicleText.text = machineName;
    }
}
