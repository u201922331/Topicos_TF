using System.Collections.Generic;
using UnityEngine;

public class CamionController : MonoBehaviour
{
    [SerializeField] private Saco _saco;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _minDropForce;
    [SerializeField] private float _maxDropForce;
    [SerializeField] private float _heightDropFloat;
    [SerializeField] private float _timeBetweenDrops = 1f;
    [SerializeField] private List<SacoSO> _sacosSO;
    float _currentTime = 0;
    [SerializeField] bool _canDrop = false;

    public void ActiveDrop(bool active)
    {
        _canDrop = active;
        if (_canDrop) _currentTime = 0;
    }

    void Update()
    {
        if (!_canDrop) return;
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeBetweenDrops)
        {
            Drop();
            _currentTime = 0;
        }
    }

    private void Drop()
    {
        Saco NewSaco = Instantiate(_saco);
        NewSaco.Initialize(
            _startPosition.position,
            new Vector2(Random.Range(_minDropForce, _maxDropForce), _heightDropFloat),
            _sacosSO[Random.Range(0, _sacosSO.Count)]
        );
    }
}
