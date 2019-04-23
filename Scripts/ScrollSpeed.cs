using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeed : MonoBehaviour {

    private ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.Instance.gameOver == true)
        {
            var main = ps.main;
            main.simulationSpeed = 100;
        }
	}
}
