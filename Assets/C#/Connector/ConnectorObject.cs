using Connector;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConnectorObject : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        Conn.Instance.SetAnotherGameObject(this.gameObject);
        Conn.Instance.SetOneGameObject(this.gameObject);
    }
}