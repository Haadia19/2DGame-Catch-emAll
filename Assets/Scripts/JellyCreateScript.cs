using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyCreateScript : MonoBehaviour
{
    public GameObject[] allObjectsPreFab;
    public GameObject[] jellyPreFab;
    private GameObject requiredJelly;
    public GameObject player;
    public int jelly;
    private bool bonusCheck = false;

    [SerializeField] float spawnTimer = 2;
    [SerializeField] public int gravity = 5;
    float leftPos = -10;
    float rightPos = 10;

    public static JellyCreateScript instance;
    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public void Update()
    {
        leftPos = player.transform.position.x + 2;
        if (leftPos >= 32)
        {
            leftPos = player.transform.position.x;
        }
        rightPos = player.transform.position.x + 10;
        if (rightPos >= 32)
        {
            rightPos = 30;
        }
    }
    public void Awake()
    {
        getGravity();

    }
    public int getGravity()
    {
        return this.gravity;
    }
    public void OnEnable()
    {
        StartCoroutine(wait());
    }
    public void randomJellyGenerator()
    {
        int randomNumber = Random.Range(0, jellyPreFab.Length);
        this.requiredJelly = jellyPreFab[randomNumber];
        jelly = randomNumber;
    }
    public GameObject getJelly()
    {
        return this.requiredJelly;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(jellySpawn());
        randomJellyGenerator();
    }

    IEnumerator jellySpawn()
    {
        while (true)
        {
            var randomXPos = Random.Range(leftPos, rightPos);
            var newPosition = new Vector3(randomXPos, transform.position.y);
            Instantiate(allObjectsPreFab[Random.Range(0, allObjectsPreFab.Length)], newPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
