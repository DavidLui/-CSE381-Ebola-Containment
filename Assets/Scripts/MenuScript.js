var isQuit = false;
var isInfo = false;
var isReturn = false;
var loadLevel1 = false;
var loadLevel2 = false;
var loadLevel3 = false;
var loadLevel4 = false;
var loadLevel5 = false;
var levelSelect = false;
function OnMouseEnter() {
	renderer.material.color = Color.red;
	Debug.Log(Application.loadedLevelName);

}

function OnMouseExit() {
	renderer.material.color = Color.white;
}

function OnMouseUp() {
Debug.Log(Application.loadedLevelName);
	if (isQuit == true) {
		Application.Quit();
	}
	else if(isInfo == true) {
		Application.LoadLevel(2);
	}
	else if(isReturn == true) {
		Application.LoadLevel(0);
	}
	else if(loadLevel2 == true) {
	
		if (Application.loadedLevelName == "Level Select"){
			Application.LoadLevel("Level 2 Loader");
		}
		else {
		Application.LoadLevel(4);
		}
	}
	else if(loadLevel3 == true) {
		if (Application.loadedLevelName == "Level Select"){
			Application.LoadLevel("Level 3 Loader");
		}
		else {
		Application.LoadLevel("Level 3");
		}
	}
	else if (loadLevel4 == true)
	{
		if(Application.loadedLevelName == "Level Select")
		{
			Application.LoadLevel("Level 4 Loader");
		}
		else
		{
			Application.LoadLevel("Level 1");
		}
	}
	else if (loadLevel5 == true)
	{
		if(Application.loadedLevelName == "Level Select")
		{
			Application.LoadLevel("Level 5 Loader");
		}
		else
		{
			Application.LoadLevel("Level 1");
		}
	}
	else if (loadLevel1 == true) {
		if (Application.loadedLevelName == "Level Select"){
			Application.LoadLevel("Level 1 Loader");
		}
		else {
		Application.LoadLevel("Level 1");
		}
	}
	else if (levelSelect == true) {
		Application.LoadLevel("Level Select");
	}
	else {
		Application.LoadLevel("Level 1 Loader");
	}
}

