using UnityEngine;

/// <summary>
/// ƒAƒCƒeƒ€‚ğ¶¬‚·‚é
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    private GameObject _item;
    void Start()
    {
        _item = (GameObject)Resources.Load("Item");
        InstantiateItem();
    }

    private void InstantiateItem()
    {
        for (int i = -5; i >= -100; i -= 5)
        {
            Instantiate(_item, new Vector3(0, 1, i), Quaternion.identity).transform.parent = this.transform;
        }
    }
}
