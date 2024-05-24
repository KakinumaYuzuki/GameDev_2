using UnityEngine;

[RequireComponent(typeof(Rigidbody))]   // Rigidbody��ǉ�
public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    bool isStop = false;

    [SerializeField] float _speed = 10f;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;   // Rigidbody�� X, Y, Z ��Rotation���Œ�
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
        //�ړ�����
        //https://candle-stoplight-544.notion.site/4e021f226d584730b715626436ccc330
        if (!isStop)
        {
            _rigidBody.velocity = new Vector3(0, 0, -1) * _speed;
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Goal"))
        {
            isStop = true;
        }
    }
}