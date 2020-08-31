using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obsticlePrefabs;

    public Player player;
    public TextMesh infoText;
    public float gameTime;
    public GameObject finishLine;
    private float finalTime;


    public float finishLinePosition = 200f;

    public float spawnDistanceFromPlayer = 20f;
    public float spawnDistanceFromObsticles = 5f;
    public float obsticlePointer;
    private bool isGameOver = false; 
    // Start is called before the first frame update
    void Start()
    {
        finishLine.transform.position = new Vector3(0, 0, finishLinePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (obsticlePointer < player.transform.position.z)
        {
            obsticlePointer += spawnDistanceFromObsticles;

            GameObject obsticleObject = Instantiate(obsticlePrefabs);

            obsticleObject.transform.position = new Vector3(Random.Range(-4f, 4f), 1.5f,
                player.transform.position.z + spawnDistanceFromPlayer);
        }

        gameTime += Time.deltaTime;

        if (isGameOver == false)
        {
            if (player.reachedFinishedLine == true)
            {
                isGameOver = true;
                finalTime = gameTime;
            }
            infoText.text = "Time :" + Mathf.FloorToInt(gameTime);
        }
        else
        {
            infoText.text = "GAME OVER!!\nYour Time :" + Mathf.FloorToInt(finalTime);
        }
       
    }
}
