﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CarregaMenu : MonoBehaviour {
	
	float timeLeft = 5.0f;

	// Update is called once per frame
	void Update () {
		
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			SceneManager.LoadScene("Menu");
		}

	}
}

