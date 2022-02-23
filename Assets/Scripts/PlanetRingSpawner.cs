using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRingSpawner : MonoBehaviour {

    public GameObject planetPrefab;
    public float width = 10f;
    public float height = 10f;
    
	void Start () {
       
        //foreach (RectTransform child in transform)
        foreach (Transform child in transform)
        {
            GameObject planet = Instantiate(planetPrefab, child.transform.position, Quaternion.identity) as GameObject;
            planet.transform.parent = child;
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
