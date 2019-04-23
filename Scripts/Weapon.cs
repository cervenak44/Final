﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating ("Fire", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        AudioSource.Play();
    }
}
