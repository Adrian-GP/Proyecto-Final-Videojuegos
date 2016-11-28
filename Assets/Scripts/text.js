//Script made by Strups Productions//
var text : GameObject;
var activateText : boolean = false; 

function Start () {
	text.SetActive(false);	//Disabels the text. 
}


function OnTriggerExit () 
{
	text.SetActive(false);	//Disabels the text.
}

function OnTriggerEnter () 
{
text.SetActive(true);

if(Input.GetKeyDown(KeyCode.E))
	{
		activateText = true;
	}

}

function Update () 
{
	if (activateText && Input.GetKey(KeyCode.E))
	{
		 text.SetActive(true);
	}
		}
			