using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    [Header("Inscribed")] public GameObject basketPrefab;
    

    public int numBaskets = 3;

    public float basketBottomY = -14f;

    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basketList = new List<GameObject>();
        
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);

        }
        
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in appleArray)
        {
            Destroy(apple);
        }
        
        //destroy one of the baskets
        int basketIndex = basketList.Count - 1;
        GameObject basketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGo);

        //if no baskets left, restart game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
