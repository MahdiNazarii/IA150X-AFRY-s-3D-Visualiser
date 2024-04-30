using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VehicleButton : MonoBehaviour
{
    public TextMeshProUGUI vehicleText;

    public void setVehicleText(string machineName)
    {
        vehicleText.text = machineName;
    }
}
