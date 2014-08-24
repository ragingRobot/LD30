using UnityEngine;

public class GameController : Singleton<GameController> {
	protected GameController(){}
	public int maxBloodCells = 5;
	public int activeBloodCells = 5;
	
	public void Awake(){
		//  Set Game Options

	}
}