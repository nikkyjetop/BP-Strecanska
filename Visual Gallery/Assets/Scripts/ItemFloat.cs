using UnityEngine;

public class ItemFloat : MonoBehaviour
{
    public float Amplitude = 0.1f;
    public float Frequency = 10f;
    private Vector3 _startLocalPos;

    void Start()
    {
        _startLocalPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * Frequency) * Amplitude;
        transform.localPosition = _startLocalPos + new Vector3(0, y, 0);
    }
}
