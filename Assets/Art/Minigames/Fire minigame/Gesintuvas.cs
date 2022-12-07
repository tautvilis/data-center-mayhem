using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gesintuvas : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Camera cam;
    private Canvas _canvas;
    private bool _isDragStarted = false;

    public GameObject selectedObject;

    void Awake() {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        _canvas = GetComponentInParent<Canvas>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
 RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out pos);
 transform.position = _canvas.transform.TransformPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragStarted = false;
    }
}
