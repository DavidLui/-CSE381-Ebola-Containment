using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUIText healthText, mutationText;
	// Use this for initialization	
	public int time = 50;
	public int enemyCount;
	public bool yellow = false;
	void Start () {
		if (Application.loadedLevel == 1)
		enemyCount = 6;
		else if (Application.loadedLevel == 4)  {



		}
	}
	
	// Update is called once per frame
	void Update () {
		string timestring = "" + (time - (int) Time.timeSinceLevelLoad);


		mutationText.text = "TIMER: " + timestring + "s";
		if (timestring == "20") {
			yellow = true;
		}
	}
}
