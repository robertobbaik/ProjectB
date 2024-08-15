using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float _hAxis;
    private float _vAxis;
    private bool wDown;
    private Vector3 _moveVec;
    private float _speed = 5.0f;
    public Rigidbody rigidbody;
    public Animator animator;
    private static readonly int IsWalk = Animator.StringToHash("isWalk");
    private static readonly int IsRun = Animator.StringToHash("isRun");

    void Start()
    {
        Debug.Log("Start");
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
             _hAxis = Input.GetAxisRaw("Horizontal");
             _vAxis = Input.GetAxisRaw("Vertical");
             wDown = Input.GetButton("Walk");
             
             _moveVec = new Vector3(_hAxis, 0, _vAxis).normalized;
             
             transform.position += _speed * Time.deltaTime * _moveVec;
             
             animator.SetBool(IsRun, _moveVec != Vector3.zero);
             animator.SetBool(IsWalk, wDown);
             
         }
}