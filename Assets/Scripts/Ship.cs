using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    private float health = 100f;
    private float armor = 100f;
    private float shields = 100f;
    private float speed = 20f;

    public string shipName;
    [Range (0f, 4f)] public float healthOffset = 1;
    [Range(0f, 4f)] public float armorOffset = 1;
    [Range(0f, 4f)] public float shieldsOffset = 1;
    [Range(0f, 4f)] public float speedOffset = 1;

    public void Awake()
    {
        health = health * (healthOffset / 2f);
        armor = armor * (armorOffset / 2f);
        shields = shields * (shieldsOffset / 2f);
        speed = speed * (speedOffset / 2f);

        Debug.Log("Ship: " + shipName + "\nStarting Stats: " + health.ToString() + ", " + armor.ToString() + ", " + shields.ToString() + ", & " + speed.ToString());
    }

}