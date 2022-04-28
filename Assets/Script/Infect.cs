using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Infect : MonoBehaviour
{
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            this.transform.GetComponent<Renderer>().material.color = new Color(0.816f, 0.612f, 0.816f);
        }
    }

}