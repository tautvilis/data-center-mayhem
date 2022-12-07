using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackController : MonoBehaviour
{
    public List<Server> _servers = new List<Server>();

    private List<int> _availableServers;
    // Start is called before the first frame update
    void Start()
    {
        _availableServers = new List<int>();
        for (int i = 0; i < _servers.Count; i++) {_availableServers.Add(i);}

        int serverCount = Random.Range(1,_availableServers.Count);
        while(serverCount > 0 && _availableServers.Count > 0) {
            int pickedServer = Random.Range(1,_availableServers.Count);
            _servers[_availableServers[pickedServer]].EnableServer(true);
            _servers[_availableServers[pickedServer]].OnFire(true);

            _availableServers.RemoveAt(pickedServer);
            serverCount--;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
