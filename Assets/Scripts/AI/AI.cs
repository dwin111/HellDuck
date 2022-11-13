using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AI : MonoBehaviour
{

    [SerializeField] protected float _wakingTime;
    [SerializeField] protected Transform _productTaking;
    [SerializeField] protected Transform _transformPut;
    protected List<Transform> _PickupPoints = new List<Transform>();

    protected DataStore _data;
    protected Animator _animator;
    protected NavMeshAgent _agent;

    protected int _numbeOfPickupPoints;
    [SerializeField] protected int _state;
    protected float timer = 0;


    private void Awake()
    {
        _data = DataStore.Instance;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    protected void Move(Transform transforms)
    {
        _agent.isStopped = false;
        Vector3 _nexPosition = new Vector3(transforms.position.x, transform.position.y, transforms.position.z);
        _agent.SetDestination(_nexPosition);
    }

    protected void TakeCoordinates(ref Transform transform, List<Transform> transforms)
    {
        int i = Random.Range(0, transforms.Count);
        transform = transforms[i];
    }
}
