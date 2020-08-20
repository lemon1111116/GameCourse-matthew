using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public int moveVel = 5;

    Transform startPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != GameManager.instance.endPosition.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameManager.instance.endPosition.position.x, transform.position.y, transform.position.z), Time.deltaTime * moveVel);
        }
        else
        {
            startPosition = GameManager.instance.fireBallSpawnPositions[Random.Range(0, GameManager.instance.fireBallSpawnPositions.Length)];
            transform.position = startPosition.position;
        }
    }
}
