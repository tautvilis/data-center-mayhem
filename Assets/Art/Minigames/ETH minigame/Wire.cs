using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image _image;
    private LineRenderer _lineRenderer;
    private Canvas _canvas; 
    private bool _isDragStarted = false;
    public bool IsSuccess = false;
    private Wiretask _wiretask;
    public Color customColor;


    private void Awake() {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wiretask = GetComponentInParent<Wiretask>();
    }

    public void SetColor(Color color) {
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        customColor = color;

    }

    public void EnablePort(bool enable) {
        gameObject.SetActive(enable);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDragStarted) {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos);

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }else{
            if(!IsSuccess && gameObject.activeSelf) {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }

        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);

        if (isHovered) {
            _wiretask.CurrentHoverWire = this;
        }
        
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsSuccess) {return;}
        _isDragStarted = true;
        _wiretask.CurrentDragWire = this;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wiretask.CurrentHoverWire != null) {
            if (_wiretask.CurrentHoverWire.customColor == customColor) {
                IsSuccess = true;
            }
        }
        _isDragStarted = false;
        _wiretask.CurrentDragWire = null;
    } 
}
