using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointVisualisation : MonoBehaviour
{
    public List<Transform> patrolPositions = new List<Transform>();
    public Transform newPosition;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, newPosition.position);
    }

    void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.Log(Event.current.mousePosition);
                Vector3 theNewPosition = hit.point;
            }
        }
    }
}