//Remember to check is trigger on the gun's collider 
 
 var spawnTo : Transform; 
 var gun : GameObject;
 
 function OnTriggerEnter(col : Collider){
	 
	 if(col.tag == "Player"){
	 
	 print("Player touched weapon!");
	 
		 Destroy(gun);
	 
	 }
 
 }