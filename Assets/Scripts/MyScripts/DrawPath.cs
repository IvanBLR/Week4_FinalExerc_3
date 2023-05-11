using UnityEngine;
using UnityEngine.Events;

public class DrawPath : MonoBehaviour
{
    public UnityEvent OnMouseButtonUp;
    public Vector3[] Path { get { return _path; } }
    private Vector3[] _path;

    private int _size;
    private LineRenderer _lineRenderer;
    private float _maxAllowableError = 0.02f;

    private Vector3 _currentPoint;
    private Vector3 _lastPoint;
    private bool _isDrawed;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _size = _lineRenderer.positionCount;
        _lastPoint = _lineRenderer.GetPosition(_size - 1);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && !_isDrawed)
        {
            DrawLine();
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isDrawed = true;
            _path = new Vector3[_lineRenderer.positionCount];
            for (int i = 0; i < _path.Length; i++)
            {
                _path[i] = _lineRenderer.GetPosition(i);
            }
            OnMouseButtonUp.Invoke();
        }
    }

    private void DrawLine()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _lastPoint = _lineRenderer.GetPosition(_size - 1);
        

        if (Physics.Raycast(ray, out var hitInfo))
        {
            _currentPoint = hitInfo.point;
            _currentPoint.x = hitInfo.point.x - 1.5f;
            _currentPoint.z = 0;

            if (Vector3.Distance(_lastPoint, _currentPoint) > _maxAllowableError)//_currentPoint.x < 1 && _currentPoint.x > -1 && _currentPoint.y > 1.5f && _currentPoint.y < 3.5f &&
            {
                _lineRenderer.positionCount++;
                _lineRenderer.SetPosition(_size, _currentPoint);
                _size++;
            }
        }
    }
}
