using UnityEngine;
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
}
