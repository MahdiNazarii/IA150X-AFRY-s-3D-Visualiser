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
    Vector3 position;
    public MetaData(int id, int level, Vector2 position)
    {
        this.id = id;
        this.level = level;
        this.position.x = position.x;
        this.position.z = position.y;
        this.position.y = 0f;
    }
    public int GetId()
    {
        return id;
    }
    public int GetLevel()
    {
        return level;
    }

    public void setCurrentPosition(Vector2 position)
    {
        this.position.x = position.x;
        this.position.Z = position.y;
    }
}
