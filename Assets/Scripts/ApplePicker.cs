using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour
{

    [Header("Inscribed")]

    public GameObject basketPrefab;

    public int numbaskets = 3;

    public float basketBottomY = -14f;

    public float basketSpacingY = 2f;

    public List<GameObject> basketList;


    // Start is called before the first frame update

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numbaskets; i++)
        {
            GameObject tbasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tbasketGO.transform.position = pos;
            basketList.Add(tbasketGO);
        }
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tAppleGO in appleArray)
        {
            Destroy(tAppleGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];

        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
