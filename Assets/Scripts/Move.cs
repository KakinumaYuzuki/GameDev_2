using UnityEngine;

[RequireComponent(typeof(Rigidbody))]   // Rigidbody‚ð’Ç‰Á
public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    bool isStop = false;

    [SerializeField] float _speed = 10f;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;   // Rigidbody‚Ì X, Y, Z ‚ÌRotation‚ðŒÅ’è
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
        //ˆÚ“®‚¹‚æ
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