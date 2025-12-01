using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //positie van het gameobject (kanon) op het scherm bepalen
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //Richting tussen het gameobject en je muiscursor bepalen
        Vector3 dir = Input.mousePosition - pos;
        //Bereken de hoek tussen het gameobject en de muiscursor in graden
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Roteer het gameobject met deze hoek om de z-as
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
