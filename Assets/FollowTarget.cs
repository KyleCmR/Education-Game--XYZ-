using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _dumping;

    private void LateUpdate()
    {
        var distance = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, distance, Time.deltaTime * _dumping);
    }
}
