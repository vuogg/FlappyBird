using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public FlappyBirdControl flappyBirdControl;
    public bool isGamePlay;

    public void Awake()
    {
        instance = this;
        isGamePlay = false;
    }
}
