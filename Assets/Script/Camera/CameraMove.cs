using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Camera movement variables
    private const float DirectionForceReduceRate = 0.935f;
    private const float DirectionForceMin = 0.001f;
    private bool _userMoveInput;
    private Vector3 _startPosition;
    private Vector3 _directionForce;

    // Zoom variables
    [Header("Zoom Settings")]
    [SerializeField] private float ZoomSpeed = 1.0f;
    [SerializeField] private float MinZoomSize = 3.0f;
    [SerializeField] private float MaxZoomSize = 10.0f;
    private float _targetZoomSize;

    // Boundary variables
    public Vector2 center;
    public Vector2 size;
    private float _height;
    private float _width;

    // Component reference
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _targetZoomSize = _camera.orthographicSize;

        _height = _camera.orthographicSize;
        _width = _height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }

    private void Update()
    {
        ControlCameraPosition();
        ReduceDirectionForce();
        UpdateCameraPosition();
        ControllerZoom();
        UpdateZoom();
    }

    private void ControlCameraPosition()
    {
        var mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            CameraPositionMoveStart(mouseWorldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            CameraPositionMoveProgress(mouseWorldPosition);
        }
        else
        {
            CameraPositionMoveEnd();
        }
    }

    private void CameraPositionMoveStart(Vector3 startPosition)
    {
        _userMoveInput = true;
        _startPosition = startPosition;
        _directionForce = Vector2.zero;
    }

    private void CameraPositionMoveProgress(Vector3 targetPosition)
    {
        if (!_userMoveInput)
        {
            CameraPositionMoveStart(targetPosition);
            return;
        }

        _directionForce = _startPosition - targetPosition;
    }

    private void CameraPositionMoveEnd()
    {
        _userMoveInput = false;
    }

    private void ReduceDirectionForce()
    {
        if (_userMoveInput)
        {
            return;
        }

        _directionForce *= DirectionForceReduceRate;

        if (_directionForce.magnitude < DirectionForceMin)
        {
            _directionForce = Vector3.zero;
        }
    }

    private void UpdateCameraPosition()
    {
        if (_directionForce == Vector3.zero)
        {
            return;
        }

        var currentPosition = transform.position;
        var targetPosition = currentPosition + _directionForce;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, 0.5f);
    }

    private void ControllerZoom()
    {
        var scrollInput = Input.GetAxis("Mouse ScrollWheel");
        var hasScrollInput = Mathf.Abs(scrollInput) > Mathf.Epsilon;
        if (!hasScrollInput)
        {
            return;
        }

        var newSize = _camera.orthographicSize - scrollInput * ZoomSpeed;
        _targetZoomSize = Mathf.Clamp(newSize, MinZoomSize, MaxZoomSize);
    }

    private void UpdateZoom()
    {
        if (Mathf.Abs(_targetZoomSize - _camera.orthographicSize) < Mathf.Epsilon)
        {
            return;
        }

        var mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        var cameraTransform = transform;
        var currentCameraPosition = cameraTransform.position;
        var offsetCamera = mouseWorldPos - currentCameraPosition - (mouseWorldPos - currentCameraPosition) / (_camera.orthographicSize / _targetZoomSize);

        _camera.orthographicSize = _targetZoomSize;

        currentCameraPosition += offsetCamera;
        cameraTransform.position = currentCameraPosition;
    }

    private void LateUpdate()
    {
        float lx = size.x * 0.5f - _width * _camera.orthographicSize / _height;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);
        float ly = size.y * 0.5f - _height * _camera.orthographicSize / _height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
