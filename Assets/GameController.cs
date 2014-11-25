using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUIText healthText, mutationText;
	// Use this for initialization	
	public int enemyCount;
	void Start () {
		if (Application.loadedLevel == 1)
		enemyCount = 4;
		else if (Application.loadedLevel == 4)  {



		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
