using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 30f;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        _rigidbody.velocity = Vector3.up * _speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            
        _velocity = _rigidbody.velocity;

        if (!_renderer.isVisible) 
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity =  Vector3.Reflect(_velocity, new Vector3(collision.contacts[0].normal.x + Random.Range(-0.01f, 0.01f), collision.contacts[0].normal.y + Random.Range(-0.01f, 0.01f), collision.contacts[0].normal.z));
    }
}
