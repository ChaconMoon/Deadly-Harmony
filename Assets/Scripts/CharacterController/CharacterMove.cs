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
    public bool isInteractive;

    [Header("Singleton")]
    public static CharacterMove characterOptions;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar todo

        characterOptions = this;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        partnerPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Determina si el personaje esta hablando, y si esta hablando no se puede mover
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

    //Recoge los Inputs
    public void OnMove(InputAction.CallbackContext context)
    {
        moves = context.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        isInteractive = context.ReadValueAsButton();
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
        //if (isInteractuableNear)
        //{
        //    
        //}
    }
    public  void OnCloseGame(InputAction.CallbackContext context) {
        Application.Quit();
    
    }
    private void OnGUI()
    {
        //GUILayout.TextArea(characterOptions.isInteractive.ToString());
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
    //Se usan cuando se requiere usar un atributo del personaje de forma externa
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

    //Cooldown que determina cuanto tiempo debe pasar para poder volver a pulsar espacio para pasar al siguiente dialogo
    private IEnumerator CoolDownTalk()
    {
        canTalk = false;
        yield return new WaitForSeconds(1);
        canTalk = true;
    }

    //Se usa en los dialogos para determinar en el personaje cuando empieza y deja de hablar
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

    public void ExternalStarterTalking()
    {
        isTalking = true;
    }

}
