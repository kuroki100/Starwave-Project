﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region Singleton

    public static PlayerManager instance;
    public static PlayerManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
