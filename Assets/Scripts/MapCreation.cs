using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    private List<Vector3> itemPositionList = new List<Vector3>();

    // 地图对象列表
    public GameObject[] items;

    public AudioClip backgroundAudio;

    private void Awake()
    {
        // background
        CreateItem(items[0], new Vector3(0, 0, 0), Quaternion.identity);

        // bunker
        CreateItem(items[1], new Vector3(-15, 15, 0), Quaternion.identity);
        CreateItem(items[1], new Vector3(15, -15, 0), Quaternion.identity);

        // spring
        CreateItem(items[2], new Vector3(-20, -20, 0), Quaternion.identity);
        CreateItem(items[3], new Vector3(20, 20, 0), Quaternion.identity);

        // mech
        CreateItem(items[4], new Vector3(-20, -20, 0), Quaternion.identity);
        CreateItem(items[5], new Vector3(20, 20, 0), Quaternion.identity);

        // airwall
        for (int i = -28; i <= 28; i += 5)
        {
            CreateItem(items[6], new Vector3(i, 28, 0), Quaternion.identity);
            CreateItem(items[6], new Vector3(i, -28, 0), Quaternion.identity);
            CreateItem(items[6], new Vector3(28, i, 0), Quaternion.identity);
            CreateItem(items[6], new Vector3(-28, i, 0), Quaternion.identity);
        }

        AudioSource.PlayClipAtPoint(backgroundAudio, transform.position);
    }

    private void CreateItem(GameObject item, Vector3 position, Quaternion quaternion)
    {
        GameObject itemGameObject = Instantiate(item, position, quaternion);
        itemGameObject.transform.SetParent(gameObject.transform);
        itemPositionList.Add(position);
    }
}
