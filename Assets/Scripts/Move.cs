using UnityEngine;

/// <summary>
/// Player�̏���
/// </summary>
[RequireComponent(typeof(Rigidbody))]   // Rigidbody��ǉ�
public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    bool isStop = false;

    [SerializeField] float _speed = 10f;

    private float _horizontal;
    Vector3 pos;
    private float _minX = -10;
    private float _maxX = 10;

    private Score _score;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;   // Rigidbody�� X, Y, Z ��Rotation���Œ�
        _score = FindFirstObjectByType<Score>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (!isStop)
        {
            _rigidBody.velocity = new Vector3(-_horizontal, 0, -1) * _speed;

            // �ړ�����
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
    /// �S�[������
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Goal"))
        {
            isStop = true;
        }
    }

    /// <summary>
    /// �A�C�e��(Trigger)�Ƃ̐ڐG����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        _score.CurrentScore += 1;
        Destroy(other.gameObject);
    }
}