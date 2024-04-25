using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script sets the id, level and position data of the HeasvyMachines (HMs)
 */
public class MetaData : MonoBehaviour
{
    int id;
    int level;
    public Vector3 positionObject;
    public void SetMetaData(int id, int level, Vector3 position)
    {
        this.id = id;
        this.level = level;
        this.positionObject.x = position.x;
        this.positionObject.y = position.y;
        this.positionObject.z = position.z;
    }
    public int GetId()
    {
        return id;
    }
    public int GetLevel()
    {
        return level;
    }

    public void setCurrentPosition(Vector3 position)
    {
        this.positionObject.x = position.x;
        this.positionObject.y = position.y;
        this.positionObject.z = position.z;
    }
}
