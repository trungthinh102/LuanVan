﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInfo : MonoBehaviour {
    public float range;
    public int maxBullet;
    public int curBullet;
    public int curBulletReLoad;
    public int dame;

    private void Start()
    {
        curBulletReLoad = curBullet;
    }
}
