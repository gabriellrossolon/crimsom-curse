using UnityEngine;

public class EyeBehavior : MonoBehaviour
{
    private Transform _playerTransform;
    private LineRenderer _lineRenderer;
    private PlayerCurse _playerCurse;

    public bool _rayEmitter;
    public bool _basicEye;
    public bool _bossEye;
    [SerializeField] private float playerHeightOffset = 1.0f;
    [SerializeField] private LayerMask obstacleLayers;
    [SerializeField] private float activationDistance = 10f;
    [SerializeField] private float curseIncreaseInterval = 1f;
    private float _timeLookingAtPlayer = 0f;


    public GameObject laserPrefab;
    public float fireInterval = 5f;
    public float laserSpeed = 20f;
    private float fireTimer;
    public AudioClip fireClip;
    public AudioSource bossSounds;

    void Start()
    {
        if (_basicEye)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        }

        if (_bossEye) {bossSounds = GetComponent<AudioSource>(); }

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

        if (_bossEye && IsPlayerInRange())
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireInterval)
            {
                fireTimer = 0f;
                FireLaser();
            }
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
            _playerCurse.ImproveCurse(1f);
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



    void FireLaser()
    {
        bossSounds.PlayOneShot(fireClip);
        Vector3 targetPosition = _playerTransform.position + new Vector3(0, 1f, 0); // Adiciona +2f no Y
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        Vector3 direction = (targetPosition - transform.position).normalized;
        laser.GetComponent<ProjectileBehavior>().Initialize(direction, laserSpeed);
    }
}

