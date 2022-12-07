using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public List<GameObject> _minigames = new List<GameObject>();
    private GameObject currentGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Startminigame() {
        currentGame = Instantiate(_minigames[Random.Range(0,_minigames.Count)]);
    }

    public void DestroyCurrentMinigame() {
        Destroy(currentGame);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
