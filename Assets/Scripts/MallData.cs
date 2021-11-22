using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallData : MonoBehaviour
{
    public static float xPos, yPos, zPos;
    public static int previousSceneLocation = -1;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
