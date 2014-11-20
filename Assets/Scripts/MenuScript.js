var isQuit = false;
var isInfo = false;
var isReturn = false;
function OnMouseEnter() {
	renderer.material.color = Color.red;
}

function OnMouseExit() {
	renderer.material.color = Color.white;
}

function OnMouseUp() {
	if (isQuit == true) {
		Application.Quit();
	}
	else if(isInfo == true) {
		Application.LoadLevel(2);
	}
	else if(isReturn == true) {
		Application.LoadLevel(0);
	}
	else {
		Application.LoadLevel(1);
	}
}

