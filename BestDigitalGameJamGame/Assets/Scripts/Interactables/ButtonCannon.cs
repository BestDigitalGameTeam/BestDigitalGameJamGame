using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCannon : MonoBehaviour, iButtonListener
{
    protected List<CannonBall> SpawnedCannonBalls = new List<CannonBall>();
    public GameObject CannonBallPrefab;

    private int LongestActiveCannonball = 0; // once enough balls are fired reuse old balls. Go to next ball in list and move that
    private bool BallListFull = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.rotation.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        if (!BallListFull)
        {
            GameObject newCannonBall = Instantiate(CannonBallPrefab, transform.position + Vector3.up, transform.rotation);
            CannonBall NewCannonBallScript = newCannonBall.GetComponent<CannonBall>();
            SpawnedCannonBalls.Add(NewCannonBallScript);
            NewCannonBallScript.CreateCannonBall();

            if (SpawnedCannonBalls.Count > 3)
            {
                BallListFull = true;
            }
        }
        else
        {
            SpawnedCannonBalls[LongestActiveCannonball].ResetBall(transform.position, transform.rotation);
        }
        SpawnedCannonBalls[LongestActiveCannonball].GetComponent<CannonBall>().BallFired();
        LongestActiveCannonball++;
    }
}
