using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiretask : MonoBehaviour
{
    public GameObject CameraManager;

    public GameObject _backgroundError;
    public GameObject _backgroundOk;

    public List<Color> _wireColors = new List<Color>();
    public List<Wire> _wires1 = new List<Wire>();
    public List<Wire> _wires2 = new List<Wire>();
    public List<Wire> _wires3 = new List<Wire>();
    public List<Wire> _wires4 = new List<Wire>();

    public Wire CurrentDragWire;
    public Wire CurrentHoverWire;

    public bool IsTaskCompleted = false;

    private List<Color> _availableColors;
    private List<int> _available1WireIndex;
    private List<int> _available2WireIndex;
    private List<int> _available3WireIndex;
    private List<int> _available4WireIndex;
    
    private int wires = 0;

    // Start is called before the first frame update
    void Start()
    {   
        CameraManager = GameObject.Find("CameraManager");

        _availableColors = new List<Color>(_wireColors);
        _available1WireIndex = new List<int>();
        _available2WireIndex = new List<int>();
        _available3WireIndex = new List<int>();
        _available4WireIndex = new List<int>();

        for (int i = 0; i < _wires1.Count; i++) {_available1WireIndex.Add(i);}
        for (int i = 0; i < _wires2.Count; i++) {_available2WireIndex.Add(i);}
        for (int i = 0; i < _wires3.Count; i++) {_available3WireIndex.Add(i);}
        for (int i = 0; i < _wires4.Count; i++) {_available4WireIndex.Add(i);}

        int WireCount = Random.Range(1,5);

        while (_availableColors.Count > 0 && WireCount >0) {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            if (WireCount%2 == 0) {
                int picked1WireIndex = Random.Range(0, _available1WireIndex.Count);
                int picked3WireIndex = Random.Range(0, _available3WireIndex.Count);
                _wires1[_available1WireIndex[picked1WireIndex]].EnablePort(true);
                _wires3[_available3WireIndex[picked3WireIndex]].EnablePort(true);
                _wires1[_available1WireIndex[picked1WireIndex]].SetColor(pickedColor);
                _wires3[_available3WireIndex[picked3WireIndex]].SetColor(pickedColor);
 
                _available1WireIndex.RemoveAt(picked1WireIndex);
                _available3WireIndex.RemoveAt(picked3WireIndex);
            }else {
                int picked2WireIndex = Random.Range(0, _available2WireIndex.Count);
                int picked4WireIndex = Random.Range(0, _available4WireIndex.Count);
                _wires2[_available2WireIndex[picked2WireIndex]].EnablePort(true);
                _wires4[_available4WireIndex[picked4WireIndex]].EnablePort(true);
                _wires2[_available2WireIndex[picked2WireIndex]].SetColor(pickedColor);
                _wires4[_available4WireIndex[picked4WireIndex]].SetColor(pickedColor);

                _available2WireIndex.RemoveAt(picked2WireIndex);
                _available4WireIndex.RemoveAt(picked4WireIndex);
            }            
            wires++;
            _availableColors.Remove(pickedColor);    

            WireCount -= 1;
        }

        StartCoroutine(CheckTaskCompletion());
    }
    
    private IEnumerator CheckTaskCompletion() {
        while (!IsTaskCompleted) {
            int successWires = 0;
            for(int i = 0; i < _wires1.Count; i++) {
                if(_wires1[i].IsSuccess) {successWires++;}
                if(_wires2[i].IsSuccess) {successWires++;}
                if(_wires3[i].IsSuccess) {successWires++;}
                if(_wires4[i].IsSuccess) {successWires++;}
                
            }

            if (successWires >= wires) {
                Debug.Log("Puzzle completed");
                IsTaskCompleted = true;
                _backgroundError.SetActive(false);
                _backgroundOk.SetActive(true);
                yield return new WaitForSeconds(3f);
                CameraManager.GetComponent<CameraManager>().ChangeCamera(1);
                Destroy(GameObject.FindGameObjectWithTag("minigame"));
            }else{
                Debug.Log("Puzzle incompleted");
            }
        
            yield return new WaitForSeconds(0.5f);
        }
    }
}
