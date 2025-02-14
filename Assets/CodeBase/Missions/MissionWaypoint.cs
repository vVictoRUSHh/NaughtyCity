using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
   // Indicator icon
    public Image _markerImage;
    // The target (location, enemy, etc..)
    public Transform _target;
    // UI Text to display the distance
    public TMP_Text _distanationInMeters;
    // To adjust the position of the icon
    public Vector3 offset;
    private float distanation;

    private void Update()
    {
        
        float minX = _markerImage.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = _markerImage.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(_target.position + offset);

        if(Vector3.Dot((_target.position - transform.position), transform.forward) < 0)
        {
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        // Limit the X and Y positions
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        _markerImage.transform.position = pos;
        distanation = ((int)Vector3.Distance(_target.position, transform.position));
        string _distanation = distanation.ToString() + "m";
        MarkerVisability();
        if (distanation > 3)
        {
            _distanationInMeters.text = _distanation;
        }

        else _distanationInMeters.text = "";
    }

    private void MarkerVisability()
    {
        if(distanation > 3) _markerImage.gameObject.SetActive(true);
        else _markerImage.gameObject.SetActive(false);
    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("NpcMission").transform;
    }
}
