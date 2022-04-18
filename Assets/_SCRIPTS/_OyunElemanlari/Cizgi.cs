using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cizgi : MonoBehaviour
{
    LineRenderer _lineRenderer;
    [SerializeField] float _konumSolX, _konumSagX;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }


    public void SetLine(float konumSolY,float konumSagY,Color color,int sortingLayer)
    {
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;

        _lineRenderer.SetPosition(0, new Vector3(_konumSolX, konumSolY));
        _lineRenderer.SetPosition(1, new Vector3(_konumSagX, konumSagY));

        _lineRenderer.sortingOrder = sortingLayer;
    }


    
}
