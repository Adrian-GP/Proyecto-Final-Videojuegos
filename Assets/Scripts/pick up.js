//Script made by Strups Productions//

var itemInCamera : GameObject; 
var itemOnTheGround : GameObject; 
var pickUpSound : AudioClip;
var text : GameObject;
var icon : GameObject;
var activateTrigger : boolean = false; 
var moveTrigger : boolean = false;

function Start () {
	text.SetActive(false);	//Disabels the text.
	itemInCamera.SetActive(false);	//Disabels the the item in camera.
	itemOnTheGround.SetActive(true);	//turns on the item on the ground.
	icon.SetActive(false);	//Disabels the icon.
	activateTrigger = true;	//Activates the Trigger 
}


function OnTriggerExit () {

	activateTrigger = false;	//Disables the Trigger 
}

function OnTriggerEnter () 
	{
	activateTrigger = true;

	if(Input.GetKeyDown(KeyCode.E))
	{
		activateTrigger = true;
		moveTrigger = true;


	}
}

function Update () 
{
	if (activateTrigger && Input.GetKey(KeyCode.E))
	{
		itemInCamera.SetActive(true); 
		itemOnTheGround.SetActive(false);
		icon.SetActive(true);
		activateTrigger = false;
		moveTrigger = true;
		AudioSource.PlayClipAtPoint(pickUpSound, transform.position);


		 
	}
		if (moveTrigger) 
	{
		transform.Translate(Vector3(0,0,1));
	}
}

