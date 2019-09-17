using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public int[] cubeList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;

	public GameObject[] cubes;
	public GameObject[] spheres;

	private int playerSide;
	private int moves;

    // Start is called before the first frame update
    void Start()
    {
    	playerSide = 1;
    	moves = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void placePiece(int spot, int side){
    	cubeList[spot] = side;

    }

    public int GetPlayerSide(){
    	return playerSide;
    }

    /*
    public void placeRandomPiece(){

    	for (int i = 0; i < cubeList.Length; i++){
    		if (cubeList[i] == 0) {
    			int randomSpot = i;
    		}
    	}
    	
    	cubeList[randomSpot] = 2;
    	cubeObjectList[randomSpot].gameObject.SetActive(true);
    	
    	//if(!cubeObjectList[0].transform.parent.gameObject.GetComponent<BoardSquare1>().thisSet)
    	//	Debug.Log("test");
    }
    */

    public void EndTurn(){
    	moves++;

    	if ( cubeList[0] == playerSide && cubeList[1] == playerSide && cubeList[2] == playerSide)
        {
            GameOver();
        }
        if (cubeList [3] == playerSide && cubeList [4] == playerSide && cubeList [5] == playerSide)
        {
            GameOver();
        }

        if (cubeList [6] == playerSide && cubeList [7] == playerSide && cubeList [8] == playerSide)
        {
            GameOver();
        }

        if (cubeList [0] == playerSide && cubeList [3] == playerSide && cubeList [6] == playerSide)
        {
            GameOver();
        }

        if (cubeList [1] == playerSide && cubeList [4] == playerSide && cubeList [7] == playerSide)
        {
            GameOver();
        }

        if (cubeList [2] == playerSide && cubeList [5] == playerSide && cubeList [8] == playerSide)
        {
            GameOver();
        }

        if (cubeList [0] == playerSide && cubeList [4] == playerSide && cubeList [8] == playerSide)
        {
            GameOver();
        }

        if (cubeList [2] == playerSide && cubeList [4] == playerSide && cubeList [6] == playerSide)
        {
            GameOver();
        }

        if (moves >= 9){
        	gameOverPanel.SetActive(true);
	    	gameOverText.text = "It's a tie!";
	    	restartButton.SetActive(true);
        }

        ChangeSides();
    }

    void ChangeSides ()
    {
        if (playerSide == 1){
        	playerSide = 2;
        }
        else if (playerSide == 2){
        	playerSide = 1;
        }
    }

    void GameOver(){
    	gameOverPanel.SetActive(true);
    	if (playerSide == 1){
    		gameOverText.text = "Blue Cube Wins!";
    	}
    	else{
    		gameOverText.text = "White Sphere Wins!";
    	}

    	restartButton.SetActive(true);
        
    }

    public void RestartGame ()
    {
        playerSide = 1;
        moves = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        // SetBoardInteractable(true);


        for (int i = 0; i < cubeList.Length; i++)
        {
        	if (cubeList[i] == 1){
        		cubes[i].gameObject.SetActive(false);
        	}
        	else{
        		spheres[i].gameObject.SetActive(false);
        	}

            cubeList[i] = 0;
        }
    }


}
