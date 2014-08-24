using UnityEngine;

public class GameController : Singleton<GameController> {
	protected GameController(){}
	public int maxBloodCells = 5;
	public int activeBloodCells = 5;
	
	public void Awake(){
		var go = GameObject.Find("Game Music"); //Finds the game object called Game Music, if it goes by a different name, change this.
		DontDestroyOnLoad(go);
		go.audio.Play(); //Plays the audio.

	}
}