using System.Collections;
using UnityEngine;
public class BoxJourny : MonoBehaviour
{
    [SerializeField]
    private DrawPath _path;

    [SerializeField]
    private float _timing;

    private Vector3[] _pointsForJourney;
    private int _index = 0;
    private bool _isReady;
    private void Update()
    {
        if (_isReady)
        {
            StartCoroutine(StartJourney());
            _isReady = false;
        }
    }
    public void Journey()
    {
        _pointsForJourney = _path.Path;
        _isReady = true;
    }
    private IEnumerator StartJourney()
    {
        while (_index < _pointsForJourney.Length)
        {
            transform.position = _pointsForJourney[_index];
            _index++;
            yield return new WaitForSeconds(_timing);
        }
    }
}

