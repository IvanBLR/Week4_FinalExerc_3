using UnityEngine;
public class OnFinishPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _finishGameObject;

    [SerializeField]
    private BoxController _box;

    [SerializeField]
    private BoxJourny _stopCoroutine;

    private float _xPosition;
    private bool _isEventCalled;
    private void Awake()
    {
        _xPosition = _finishGameObject.transform.position.x;
    }
    private void Update()
    {
        if (transform.position.x <= _xPosition && !_isEventCalled)
        {
            _isEventCalled = true;
            _box.DropDown(_finishGameObject.transform.position);
            _stopCoroutine.StopAllCoroutines();
        }
    }
}
