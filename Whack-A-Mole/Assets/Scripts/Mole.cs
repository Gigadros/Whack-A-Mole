﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {

	public float visibleHeight = 0.2f;
	public float hiddenHeight = -0.3f;
	public float speed = 3f;
	public float disappearDuration = 1.25f;
	public bool isVisible = false;

	private Vector3 targetPosition;
	private float disappearTimer = 0f;

	// Use this for initialization
	void Awake () {
		targetPosition = new Vector3(
			transform.localPosition.x,
			visibleHeight,
			transform.localPosition.z
		);
	}
	
	// Update is called once per frame
	void Update () {
		disappearTimer -= Time.deltaTime;
		if (disappearTimer <= 0f) {
			Hide ();
		}
		transform.localPosition = Vector3.Lerp (transform.localPosition, targetPosition, Time.deltaTime * speed);
	}

	public void Rise () {
		targetPosition = new Vector3(
			transform.localPosition.x,
			visibleHeight,
			transform.localPosition.z
		);
		isVisible = true;
		disappearTimer = disappearDuration;
	}

	public void Hide () {
		targetPosition = new Vector3(
			transform.localPosition.x,
			hiddenHeight,
			transform.localPosition.z
		);
		isVisible = false;
	}

	public void OnHit () {
		Hide ();
	}
}
