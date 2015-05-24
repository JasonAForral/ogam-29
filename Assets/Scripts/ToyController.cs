using UnityEngine;
using System.Collections;

public class ToyController : MonoBehaviour
{
	public int cost;
	public bool isBought;

	private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start ()
	{
		this.meshRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void SetAlpha (float alpha)
	{
		Color oldColor = this.meshRenderer.material.color;
		Color newColor = new Color (oldColor.r, oldColor.g, oldColor.b, alpha);
		this.meshRenderer.material.color = newColor;
	}
}
