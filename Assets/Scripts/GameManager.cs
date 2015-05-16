using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject ground;
	public GameObject grassLight;
	public GameObject grassDark;
	public GameObject selection;
	public GameObject deselection;
	public Text moneyText;
	public GameObject piggyBank;

	private int width;
	private int length;
	private float money;

	// Use this for initialization
	void Start ()
	{
		this.width = 8;
		this.length = 4;
		this.InitializeGround (this.width + 4, this.length + 4);
		this.InitializeGrass (this.width, this.length);
		this.money = 0f;
		this.InstantiatePiggyBank ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.money += Time.deltaTime;
		this.moneyText.text = "Money: " + (int)this.money;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 20f)) {
			if (hit.transform.tag == "Grass") {
				this.selection.transform.position = hit.transform.position + (Vector3.up * 0.1f);
			} else if (hit.transform.tag == "Ground") {
				this.selection.transform.position = this.deselection.transform.position;
			}
		}
	}

	protected void InitializeGround (int width, int length)
	{
		GameObject ground = (GameObject) Instantiate (this.ground, Vector3.zero, Quaternion.identity);
		ground.transform.localScale = new Vector3 (width, 0.75f, length);
	}

	protected void InitializeGrass (int width, int length)
	{
		for (int i = 0; i < length; i++) {
			for (int j = 0; j < width; j++) {
				Vector3 newPosition = new Vector3(j - ((width - 1f) / 2f), 0f, i - ((length - 1f) / 2f));
				if (((i + j) % 2) == 0) {
					Instantiate (this.grassLight, newPosition, Quaternion.identity);
				} else {
					Instantiate (this.grassDark, newPosition, Quaternion.identity);
				}
			}
		}
	}

	protected void InstantiatePiggyBank ()
	{
		Vector3 position = new Vector3 ((this.width / -2) - 1, 1f, (this.length / 2) - 0.5f);
		Instantiate (this.piggyBank, position, Quaternion.identity);
	}
}
