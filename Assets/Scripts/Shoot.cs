using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public static event Action onShootBall;
    private bool _shotEnabled = true;
    
    [SerializeField] private GameObject prefab;
    [SerializeField] private float forceBuild = 20f;
    [SerializeField] private float maximumHoldTime = 5f;
    private float _pressTimer = 0f;
    private float _launchForce = 0f;
    [SerializeField] private float lineSpeed = 10f;
    private LineRenderer _line;
    private bool _lineActive = false;
    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        
        _line.SetPosition(1, Vector3.zero);

        CountBalls.onBallsDepleted += DisableShot;
    }

    private void OnDisable()
    {
        CountBalls.onBallsDepleted -= DisableShot;
    }

    private void Update()
    {
        if(_shotEnabled)HandleShot();
    }
    
    private void HandleShot()
    {
        if (Input.GetMouseButtonUp(0))
        {

            //eerdere code....voor nu even overgeslagen


            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0f;
            _lineActive = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0; 

        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;
            GameObject ball = Instantiate(prefab, transform.parent);
            ball.transform.rotation = transform.rotation;
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);
            ball.transform.position = transform.position;

            onShootBall?.Invoke();
        }
        
        if (_pressTimer < maximumHoldTime)
        {
            _pressTimer += Time.deltaTime;
        }
        
        if (_lineActive)
        {
            _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }
    }

    private void DisableShot(){
        _shotEnabled = false;
    }

}
