using InfimaGames.LowPolyShooterPack;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MissionWaypoint : MonoBehaviour,IGameService
{
    public Image _markerImage;
    public Transform _target;
    public TMP_Text _distanationInMeters;
    public Vector3 offset;
    private float distanation;

    private void Update()
    {
        if(_target!= null)ShowMarker();
        else
            HideMarkerFromPlayer();
    }

    private void HideMarkerFromPlayer()
    {
        _markerImage.gameObject.SetActive(false);
        _distanationInMeters.gameObject.SetActive(false);
    }

    private void ShowMarker()
    {
        _distanationInMeters.gameObject.SetActive(true);
        
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
}
