﻿using UnityEngine;
using System.Collections;

public class ToyController : MonoBehaviour
{
	public float cost;
	public enum ToyState
	{
		New,
		BeingDragged,
		Placed,
	};
	public ToyState state;
	public Vector3 initialMousePosition;
	public Vector3 initialToyPosition;

	private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start ()
	{
		this.meshRenderer = GetComponent<MeshRenderer> ();
		this.state = ToyController.ToyState.New;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ToyController.ToyState.BeingDragged == this.state) {
			if (Input.GetMouseButtonUp (0)) {
				this.state = ToyController.ToyState.Placed;
			} else {
				Vector3 difference = Input.mousePosition - this.initialMousePosition;
				float xFactor = Screen.width / 15;
				float yFactor = Screen.height / 5;
				Vector3 translated = new Vector3(difference.x / xFactor, 0f, difference.y / yFactor);
				Vector3 newPosition = this.initialToyPosition + translated;
				this.transform.position = newPosition;
			}
		}
	}

	public void CheckAffordability (float money)
	{
		if (ToyController.ToyState.New == this.state) {
			Color oldColor = this.meshRenderer.material.color;
			float alpha = 1f;
			if (money < this.cost) {
				alpha = (money / 2) / cost;
			}
			Color newColor = new Color (oldColor.r, oldColor.g, oldColor.b, alpha);
			this.meshRenderer.material.color = newColor;
		}
	}

	public void SetInitialClick (Vector3 mousePosition)
	{
		this.initialMousePosition = mousePosition;
		this.initialToyPosition = this.transform.position;
		this.state = ToyController.ToyState.BeingDragged;
	}
}
