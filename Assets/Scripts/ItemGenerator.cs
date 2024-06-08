using UnityEngine;

/// <summary>
/// �A�C�e���𐶐�����
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    private GameObject _item;

    private Lane _lane;
    void Start()
    {
        _item = (GameObject)Resources.Load("Item");
        InstantiateItem();
    }

    private void InstantiateItem()
    {
        for (int i = -5; i >= -100; i -= 5)
        {
            // ���[����Ń����_���ɐ���
            _lane = (Lane)Random.Range(-1, 2);
            Instantiate(_item, new Vector3(-(int)_lane * 5, 1, i), Quaternion.identity).transform.parent = this.transform;
        }
    }
}
