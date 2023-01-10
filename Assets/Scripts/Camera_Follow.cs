using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    void Update()
    {
        if (LevelManager.instance.currentLevel == 1)
        {
            playerPosition = new Vector3(player1.transform.position.x, transform.position.y, transform.position.z);

            if (player1.transform.localScale.x > 0f)
            {
                playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
            }

            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
        else if (LevelManager.instance.currentLevel == 2)
        {
            playerPosition = new Vector3(player2.transform.position.x, transform.position.y, transform.position.z);

            if (player2.transform.localScale.x > 0f)
            {
                playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
            }

            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
        else if (LevelManager.instance.currentLevel == 3)
        {
            playerPosition = new Vector3(player3.transform.position.x, transform.position.y, transform.position.z);

            if (player3.transform.localScale.x > 0f)
            {
                playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
            }

            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
        else if (LevelManager.instance.currentLevel == 4)
        {
            playerPosition = new Vector3(player4.transform.position.x, transform.position.y, transform.position.z);

            if (player4.transform.localScale.x > 0f)
            {
                playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
            }

            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }

    }
}
