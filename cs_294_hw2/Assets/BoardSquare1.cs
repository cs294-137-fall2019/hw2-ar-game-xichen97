using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSquare1 : MonoBehaviour, OnTouch3D
{
    public GameObject cube;
    public GameObject sphere;

    public GameObject gameController;

    public float debounceTime = 0.3f;
    public int cubeNum =0;
    public int cubeSide;
    //public string playerSide;
    //public bool thisSet = false;
    // Stores a counter for the current remaining wait time.
    private float remainingDebounceTime;
    private GameController gameControllerScript;
    //private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        remainingDebounceTime = 0;
        gameControllerScript = gameController.GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (remainingDebounceTime > 0)
            remainingDebounceTime -= Time.deltaTime;

    }

    public void OnTouch()
    {
        // If a touch is found and we are not waiting,
        if (remainingDebounceTime <= 0 )
        {
            // thisSet = true;
            // Move the object up by 10cm and reset the wait counter.
            //this.gameObject.transform.Translate(new Vector3(0, 0.1f, 0));
            remainingDebounceTime = debounceTime;
            // cube1.gameObject.SetActive(true);
            
            cubeSide = gameControllerScript.GetPlayerSide();

            if (cubeSide == 1){
                cube.gameObject.SetActive(true);
                gameControllerScript.placePiece(cubeNum, cubeSide);
            }
            else{
                sphere.gameObject.SetActive(true);
                gameControllerScript.placePiece(cubeNum, cubeSide);
            }

            gameControllerScript.EndTurn();

        }
    }


}
