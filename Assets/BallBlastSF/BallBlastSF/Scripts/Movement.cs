using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed; //�������������� ��������.

    [SerializeField] private float _reboundSpeed; //�������� �������.
    
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float _gravity; //����������.

    private Vector3 _velosity; //������ ����������� ��������.

    private void Awake()
    {
        //������ ����������� �������� ��� �������� �������.
        _velosity.x = -Mathf.Sign(transform.position.x) * _horizontalSpeed;
    }

    private void Update()
    {
        Move();
    }

    //������ ��������.
    private void Move()
    {
        _velosity.y -= _gravity * Time.deltaTime;

        _velosity.x = Mathf.Sign(_velosity.x) * _horizontalSpeed;

        transform.position += _velosity * Time.deltaTime;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    //������ ��������� ���������� �� ������������ � ��������� ������.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (_reboundSpeed <= 0.5f)
        {
            enabled = false;

            return;
        }

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                _velosity.y = _reboundSpeed;

                _reboundSpeed /= 1.5f;

                _velosity.x /= 2;
            }

            if (levelEdge.Type == EdgeType.Left && _velosity.x < 0 || levelEdge.Type == EdgeType.Right && _velosity.x > 0)
            {
                _velosity.x *= -1;
            }
        }
    }

    //��������� ������������ ���� �����.
    public void AddVertivalVelocity(float velosity)
    {
        _velosity.y += velosity;
    }
}
