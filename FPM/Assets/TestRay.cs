using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour
{
    [SerializeField]
    private GameObject planePrefab;
    [SerializeField]
    private GameObject cubePrefab;
     GameObject prevObj = null;
     GameObject obj = null;
    void Start()
    {
        for(int z = 0; z < 10; z++ )
        {
            for(int x = 0; x < 10; x++ )
            {
                Instantiate(planePrefab, new Vector3(x, 0, z), Quaternion.identity);
            }

        }
        
        
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            if(obj != null)
            {
                if(!obj.Equals(hit.transform.gameObject))
                {
                    obj.GetComponent<MeshRenderer>().material.color = Color.white;

                }
                
                prevObj = obj;
            }
            obj = hit.transform.gameObject;
            obj.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
