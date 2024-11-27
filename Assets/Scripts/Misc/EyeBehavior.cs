using UnityEngine;

public class EyeBehavior : MonoBehaviour
{
    private Transform _playerTransform;
    private LineRenderer _lineRenderer;
    private PlayerCurse _playerCurse;

    public bool _rayEmitter;
    public bool _basicEye;
    [SerializeField] private float playerHeightOffset = 1.0f;
    [SerializeField] private LayerMask obstacleLayers;
    [SerializeField] private float activationDistance = 10f;
    [SerializeField] private float curseIncreaseInterval = 1f;
    private float _timeLookingAtPlayer = 0f;

    void Start()
    {
        if (_basicEye)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        }

        _playerTransform = GameObject.FindWithTag("Player").transform;
        _lineRenderer = GetComponent<LineRenderer>();
        _playerCurse = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerCurse>();

        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, transform.position);
    }

    void Update()
    {
        if (IsPlayerInRange())
        {
            LookAtPlayer();
            if (_rayEmitter) { EmitRay(); }
        }
        else
        {
            ResetRay();
            ResetCurseTimer();
        }
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, _playerTransform.position) <= activationDistance;
    }

    private void LookAtPlayer()
    {
        transform.LookAt(_playerTransform);
        transform.Rotate(0, -90f, 0);
    }

    private void EmitRay()
    {
        Vector3 playerTargetPosition = _playerTransform.position + Vector3.up * playerHeightOffset;
        Vector3 direction = (playerTargetPosition - transform.position).normalized;

        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, Mathf.Infinity, obstacleLayers))
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, playerTargetPosition);
            UpdateCurseProgress();
        }

        _lineRenderer.SetPosition(0, transform.position);  

    }

    private void UpdateCurseProgress()
    {
        _timeLookingAtPlayer += Time.deltaTime;

        if (_timeLookingAtPlayer >= curseIncreaseInterval)
        {
            _playerCurse.ImproveCurse();
            _timeLookingAtPlayer -= curseIncreaseInterval;
        }
    }

    private void ResetRay()
    {
        _lineRenderer.SetPosition(1, transform.position);
    }

    private void ResetCurseTimer()
    {
        _timeLookingAtPlayer = 0f;
    }
}

