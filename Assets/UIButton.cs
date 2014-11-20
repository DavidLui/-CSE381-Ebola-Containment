using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {
	public int w, x, y, z;
	public int w1, x2, y3, z4;
	public int w2, x3;
	private void OnGUI() {
		if (GUI.Button ( new Rect(15, 15, 150, 75), "Return"))
			Application.LoadLevel ("MenuScreen");
		//GUI.Box(new Rect(w,x,y,z),"Health: 0");
		//GUI.Box(new Rect(w1,x2,y3,z4),"Mutation Capsules: 0");
		//GUI.Box(new Rect(w2,x3,135,25),"Enemies Remaining: 0");
 
	}
}
