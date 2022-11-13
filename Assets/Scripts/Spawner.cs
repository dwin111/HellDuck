using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private float _timeSpaw;
    [SerializeField] private int _numberSpawnObject;
    private float _timer;

    private void FixedUpdate()
    {
        if (transform.childCount < _numberSpawnObject)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeSpaw)
            {
                Instantiate(_spawnObject, transform.position, _spawnObject.transform.rotation, transform);
                _timer = 0;
            }
        }
        else
        {
            _timer = 0;
        }
    }

}
