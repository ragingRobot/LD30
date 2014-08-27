using UnityEngine;

public class GameController : Singleton<GameController> {
	protected GameController(){}
	public int maxBloodCells = 0;
	public int activeBloodCells = 0;
	public int maxWhiteCells = 0;
	public int activeWhiteCells = 0;
	public int maxGerms = 0;
	public int activeGerms = 0;
	public int currentLevel = 0;
	public FailureMenu failMenu;
	public SuccessMenu successMenu;
	public string[] levels = new string[17]{"level1", "level2","level3","level4","level5","level6","level7","level8","level9","level10","level11","level12","level13","level14","level15","level16","level17"};
	public void Awake(){
		var go = GameObject.Find("Game Music"); //Finds the game object called Game Music, if it goes by a different name, change this.
		DontDestroyOnLoad(go);
		go.audio.Play(); //Plays the audio.

	}
}