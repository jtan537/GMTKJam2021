using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePackage : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(speed * 10f, _rb.velocity.y);
    }
}
