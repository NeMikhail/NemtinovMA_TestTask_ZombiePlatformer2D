using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool _isGrounded = true;
    private List<GameObject> _groundObjects = new List<GameObject>();

    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
        _groundObjects.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_groundObjects.Contains(collision.gameObject))
        {
            _groundObjects.Remove(collision.gameObject);
        }
        if (_groundObjects.Count == 0)
        {
            _isGrounded = false;
        }
    }


}
