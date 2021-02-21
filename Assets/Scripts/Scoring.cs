using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static uint _aScore { get; private set; }
    public static uint _bScore { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        _aScore = 0;
        _bScore = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (gameObject.name)
        {
            case "LeftBound":
                _bScore++;
                break;
            case "RightBound":
                _aScore++;
                break;
            default:
                return;
        }
        
        other.gameObject.GetComponent<BallMovement>().Reset();
    }
}
