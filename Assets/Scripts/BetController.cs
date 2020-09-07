using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BetController : MonoBehaviour
{
    public float velocity;
    public string axis;
    public float upperBound;
    public float lowerBound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(axis) * velocity * Time.deltaTime;
        float nextPos = transform.position.y + move;

        if (nextPos > upperBound)
            move = 0;

        if (nextPos < lowerBound)
            move = 0;

        transform.Translate(0, move, 0);
    }
}
