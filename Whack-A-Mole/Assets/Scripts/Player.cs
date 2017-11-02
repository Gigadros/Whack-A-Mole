using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int score = 0;
	public Hammer hammer;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)){
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit)) {
				if (hit.transform.GetComponent<Mole> () != null) {
					Mole mole = hit.transform.GetComponent<Mole> ();
					if (mole.isVisible) score++;
					mole.OnHit ();
					hammer.Hit (mole.transform.position);
				}
			}
		}
	}
}
