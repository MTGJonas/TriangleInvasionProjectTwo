using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPlayerArea : MonoBehaviour
{
    [SerializeField] Transform _lowLeftEdge
        ;
    [SerializeField] Transform _lowRightEdge;
    [SerializeField] Transform goal;
    private void OnDrawGizmos()
    {
        
        Vector3 lowLeft = _lowLeftEdge.position;
        Vector3 lowRight= _lowRightEdge.position;
        Vector3 topLeft = new Vector3(lowLeft.x,goal.position.y,0);
        Vector3 topRight = new Vector3(lowRight.x, goal.position.y, 0);
        Gizmos.DrawLine(lowLeft, topLeft);
        Gizmos.DrawLine(lowRight, topRight);
    }
}
