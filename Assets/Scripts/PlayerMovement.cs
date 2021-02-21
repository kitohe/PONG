using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool playerA;

    private Bounds _bounds;
    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;
    private KeyCode _keyUp;
    private KeyCode _keyDown;
    private Vector2 _extents;
    
    // Start is called before the first frame update
    private void Start()
    {
        _bounds = Camera.main.OrthographicBounds();
        _rigidbody = GetComponent<Rigidbody2D>();
        _velocity = new Vector2(0f, 10f);
        _extents = GetComponent<BoxCollider2D>().bounds.extents;

        if (playerA)
        {
            _keyUp = KeyCode.W;
            _keyDown = KeyCode.S;
        }
        else
        {
            _keyUp = KeyCode.UpArrow;
            _keyDown = KeyCode.DownArrow;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var pos = _rigidbody.position;

        if (Input.GetKey(_keyUp))
        {
            pos = _rigidbody.position + _velocity * Time.deltaTime;
        }
        else if (Input.GetKey(_keyDown))
        {
            pos = _rigidbody.position - _velocity * Time.deltaTime;
        }
        
        if (pos.y + _extents.y > _bounds.max.y)
        {
            pos.y = _bounds.max.y - _extents.y;
        }
        else if (pos.y - _extents.y < _bounds.min.y)
        {
            pos.y = _bounds.min.y + _extents.y;
        }
        
        _rigidbody.MovePosition(pos);
    }
}
