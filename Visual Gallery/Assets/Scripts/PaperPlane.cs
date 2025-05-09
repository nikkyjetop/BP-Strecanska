using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PaperPlane : MonoBehaviour
{
    public GameObject TargetDestination;

    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    private Vector2 _currentTarget;

    private float _floatAmplitude = 50f;
    private float _floatFrequency = 2f;
    private float _speed = 100f;
    private float _maxRotationAngle = 25f;
    private SpriteRenderer _spriteRenderer;


    void Start()
    {
        _startPosition = transform.localPosition;
        _targetPosition = TargetDestination.transform.localPosition;
        _currentTarget = _targetPosition;

        _spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Log(_startPosition);
        Debug.Log(_targetPosition);
    }

    void Update()
    {
        Vector2 basePosition = Vector2.MoveTowards(transform.localPosition, _currentTarget, _speed * Time.deltaTime);
        float yOffset = Mathf.Sin(Time.time * _floatFrequency) * _floatAmplitude;

        float directionMultiplier = _spriteRenderer.flipX ? -1f : 1f;

        float rotationZ = Mathf.Cos(Time.time * _floatFrequency) * _maxRotationAngle * directionMultiplier;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        transform.localPosition = new Vector3(basePosition.x, _startPosition.y + yOffset, -1);

        if (Mathf.Abs(transform.localPosition.x - _currentTarget.x) < 0.1)
        {
            _currentTarget = (_currentTarget == _targetPosition) ? _startPosition : _targetPosition;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }


}


