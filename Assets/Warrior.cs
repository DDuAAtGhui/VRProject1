using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    private new Transform transform;
    private Vector3 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
            transform.Translate(Vector3.forward * Time.deltaTime * 2.0f);
        }
    }
    #region UNITY_EVENTS
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();

        Debug.Log($"ctx.phase={ctx.phase}");

        //2���� ��ǥ�� 3���� ��ǥ�� ��ȯ
        moveDir = new Vector3(dir.x, 0, dir.y);

        //Warrior_Run �ִϸ��̼� ����
        anim.SetFloat("Movement", dir.magnitude);
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        Debug.Log($"ctx.phase={ctx.phase}");

        if (ctx.performed)
        {
            Debug.Log("Attack");
            anim.SetTrigger("Attack");
        }
    }
    #endregion
}