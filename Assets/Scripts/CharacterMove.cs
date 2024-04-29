using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    [Header("Atributos Objeto")]

    [Header("Moviniento")]
    private Vector2 moves;
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    public float moveSpeed;
    private bool isMoving = false;
    [Header("Comapañero")]
    public PartnerMove partnerMove;
    private Vector2 partnerPosition;
    [Header("Animaciones")]
    private Animator animator;
    private float velocityX;
    private float velocityY;
    [Header("Conversaciones")]
    private bool isTalking;
    private bool canTalk = true;
    [Header("Interctuar")]
    private bool isNPCNear;
    public DialogueOptions dialogueNPCNear;
    [Header("Singleton")]
    public static CharacterMove characterOptions;

    // Start is called before the first frame update
    void Start()
    {
        characterOptions = this;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        partnerPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTalking)
        {
            //Debug.Log(moves.ToString());
            if (!isMoving && moves != Vector2.zero)
            {
                Moverse();
                setAnimation();
            }
            else
            {
                animator.SetBool("Stop", true);

            }
        }

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moves = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (canTalk & isTalking)
        {
            DialogueControl.dialogueControl.GoToNextDialogue();
            Debug.Log("Siguiente Dialogo");
            StartCoroutine(CoolDownTalk());
        }
        if (canTalk & isNPCNear & !isTalking)
        {
            DialogueOptionsInUI.instance.InstanciateDialogue(dialogueNPCNear);
            StartCoroutine(CoolDownTalk());
        }
    }
    private void OnGUI()
    {
        //GUILayout.TextArea(moves.ToString());
    }
    public void Moverse()
    {
        isMoving = true;
        targetPosition = new Vector2(transform.position.x+moves.x, transform.position.y+ moves.y);
        if (partnerMove.IsFollow())
        {
            partnerPosition = new Vector2(transform.position.x - moves.x, transform.position.y - moves.y);
            partnerMove.FollowCharacter(partnerPosition, moveSpeed);
        }
        rb.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, moveSpeed));

        isMoving = false;

        
    }
    private void setAnimation()
    {
        velocityX = moves.x;
        velocityY = moves.y;
        animator.SetBool("Stop", false);
        animator.SetFloat("VelocityX", velocityX);
        animator.SetFloat("VelocityY", velocityY);

    }
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    public Vector2 GetTargetPosition()
    {
        return targetPosition;
    }
    public Vector2 GetMoves()
    {
        return moves;
    }
    private IEnumerator CoolDownTalk()
    {
        canTalk = false;
        yield return new WaitForSeconds(1);
        canTalk = true;
    }
    public void StopTalking()
    {
        isTalking = false;
    }
    public void StartTalking()
    {
        isTalking=true;
    }
    public void SetNPCDialogue(DialogueOptions dialogue)
    {
        dialogueNPCNear = dialogue;
        isNPCNear = true;
    }
    public void EarseNPCDialogue()
    {
        isNPCNear = false;
    }
}
