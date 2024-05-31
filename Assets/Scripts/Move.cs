using UnityEngine;

[RequireComponent(typeof(Rigidbody))]   // Rigidbodyを追加
public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    bool isStop = false;

    [SerializeField] float _speed = 10f;

    private float _horizontal;
    Vector3 pos;
    private float _minX = -10;
    private float _maxX = 10;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;   // Rigidbodyの X, Y, Z のRotationを固定
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (!isStop)
        {
            _rigidBody.velocity = new Vector3(-_horizontal, 0, -1) * _speed;

            // 移動制限
            pos = this.transform.position;
            pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
            transform.position = pos;
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
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
            isStop = true;
        }
    }
}