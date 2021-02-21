using UnityEngine;
using Random = System.Random;

public class BallMovement : MonoBehaviour
{
    private float _xV = 10f;
    private float _yV = 10f;
    private Random _rng;
    private Rigidbody2D _rigidbody;
    private float _speed;

    private void Start()
    {
        _rng = new Random();
        _rigidbody = GetComponent<Rigidbody2D>();
        Init();
    }

    private void Init()
    {
        _xV = _rng.Next(0, 1000) % 2 == 0 ? -_xV : _xV;
        _yV = _rng.Next(0, 1000) % 2 == 0 ? -_yV : _yV;
        _rigidbody.velocity = new Vector2(_xV, _yV);
        _rigidbody.position = new Vector2(0f, 0f);
        _speed = _rigidbody.velocity.magnitude;
    }

    private void Update()
    {
        Debug.Log($"Magnitude: {_rigidbody.velocity.magnitude}");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "PlayerA" && other.gameObject.name != "PlayerB") return;

        float y = hitFactor(transform.position,
            other.transform.position,
            other.collider.bounds.size.y);

        Vector2 dir = new Vector2
        {
            x = other.gameObject.name == "PlayerA" ? 1f : -1f,
            y = y
        }.normalized;

        _rigidbody.velocity = dir * _speed;
    }

    private float hitFactor(
        Vector2 ballPos,
        Vector2 racketPos,
        float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    
    public void Reset()
    {
        Init();
    }
}
