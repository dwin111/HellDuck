using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float _time = 0;

    [SerializeField] private DynamicJoystick _dynamicJoystick;
    private Rigidbody _rigidbody;

    private Animator _animator;
    private string[] _idleAnimation = new string[] {"Eat", "Turn Head"};
    public float Speed { get => _speed; set => _speed = value; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        _time += Time.deltaTime;        
        if (_dynamicJoystick.Horizontal != 0 || _dynamicJoystick.Vertical != 0)
        {
            _time = 0;
            OffIdleAnimatio();

            Vector3 direction = new Vector3(_dynamicJoystick.Horizontal, 0, _dynamicJoystick.Vertical);
            Vector3 offset = direction * ((_speed * 100) * Time.deltaTime);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
            if ((Mathf.Abs(_dynamicJoystick.Horizontal) <= 0.3 && Mathf.Abs(_dynamicJoystick.Vertical) <= 0.3) &&
                (Mathf.Abs(_dynamicJoystick.Horizontal) > 0 || Mathf.Abs(_dynamicJoystick.Vertical) > 0))
            {
                _animator.SetBool("Walk", true);
                _animator.SetBool("Run", false);
            }
            else
            {
                _animator.SetBool("Run", true);
                _animator.SetBool("Walk", false);
            }
            _rigidbody.velocity = offset;
        }
        else
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Walk", false);
            if (Mathf.Round(_time) == 10)
            {
                int num = Random.Range(0, 100) > 50 ? 1 : 0;
                _animator.SetBool(_idleAnimation[num], true);
            }
            if (Mathf.Round(_time) == 12)
            {
                OffIdleAnimatio();
                _time = 5;

            }
            _rigidbody.velocity = Vector3.zero;
        }                
    }   

    private void OffIdleAnimatio()
    {
        _animator.SetBool("Turn Head", false);
        _animator.SetBool("Eat", false);
    }

}
