using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Controls : MonoBehaviour
{
    public bool IsGrounded;
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) && (this.IsGrounded == true))
        {

            {
                int _1 = 6;
                Vector3 _2 = this.GetComponent<Rigidbody>().velocity;
                _2.y = _1;
                this.GetComponent<Rigidbody>().velocity = _2;
            }
        }
    }

    public virtual void OnCollisionStay(Collision col)
    {
        this.IsGrounded = true;
    }

    public virtual void OnCollisionExit(Collision col)
    {
        this.IsGrounded = false;
    }

}