using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class MachinePositionUpdate : EventArgs
{

    public int AreaId{get; set;}
    public int ZoneId{get;  set;}
    public int MachineId{get; set;}
    public double XPos{get;  set;}
    public double YPos{get; set;}
    public double FrontHeading{get; set;}
    public double RearHeading{get; set;}
    public double Speed{get;  set;}
    public int Level{get; set;}

    //

    
}
