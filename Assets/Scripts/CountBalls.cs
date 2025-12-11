using System;
using UnityEngine;

public class CountBalls : MonoBehaviour
{
    
    
    public static event Action onBallLost;
    public static event Action onBallsDepleted;
    [SerializeField] private int ballsLeft = 5;
    private void Start()
    {
        Shoot.onShootBall += CountOnShot;
    }
    private void CountOnShot()
    {
        if (ballsLeft > 0) {
            ballsLeft--;
        }
        else
        {
            onBallsDepleted?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBallLost?.Invoke();

            Destroy(collision.gameObject);
        }
    }


}
