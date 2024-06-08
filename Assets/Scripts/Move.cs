using UnityEngine;

/// <summary>
/// Playerの処理
/// </summary>
[RequireComponent(typeof(Rigidbody))]   // Rigidbodyを追加
public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    bool isGoal = false;

    [SerializeField] float _speed = 10f;

    Vector3 pos;

    private Score _score;
    private Lane _currentLane;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;   // Rigidbodyの X, Y, Z のRotationを固定
        _score = FindFirstObjectByType<Score>();
        _currentLane = Lane.Center;
    }

    void Update()
    {
        MovePlayer();
        if (!isGoal)
        {
            // レーン上で動くようにした
            pos = this.transform.position;
            _rigidBody.MovePosition(new Vector3(-(int)_currentLane * 5, pos.y, pos.z));
            _rigidBody.velocity = new Vector3(0, 0, -1) * _speed;
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }

    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentLane == Lane.Center || _currentLane == Lane.Right)
            {
                _currentLane -= 1;
            }
            Debug.Log(_currentLane);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_currentLane == Lane.Center || _currentLane == Lane.Left)
            {
                _currentLane += 1;
            }
            Debug.Log(_currentLane);
        }
    }

    /// <summary>
    /// ゴール判定
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Goal"))
        {
            isGoal = true;
        }
    }

    /// <summary>
    /// アイテム(Trigger)との接触判定
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        _score.CurrentScore += 1;
        Destroy(other.gameObject);
    }
}