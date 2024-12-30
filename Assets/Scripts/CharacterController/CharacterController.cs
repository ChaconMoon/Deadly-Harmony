using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// CharacterControllers controls the inputs of the user in the character
/// </summary>
public class CharacterController : MonoBehaviour
{
    /// <summary>
    /// Contain the inputs of the player
    /// </summary>
    [Header("Moviniento")]
    private Vector2 moves;

    /// <summary>
    /// Contain the position where the character moves
    /// </summary>
    private Vector2 targetPosition;

    /// <summary>
    /// The reference to the rigitdbody of main character 
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// The speed of the character
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// Contains if the character is moving
    /// </summary>
    private bool isMoving = false;

    /// <summary>
    /// The reference to the other character partner move character
    /// </summary>
    [Header("Comapañero")]
    public PartnerMove partnerMove;

    /// <summary>
    /// The position of the other character
    /// </summary>
    private Vector2 partnerPosition;

    /// <summary>
    /// The reference to the animator of the character
    /// </summary>
    [Header("Animaciones")]
    private Animator animator;

    /// <summary>
    /// The value of the velocity of the character in the X axis
    /// </summary>
    private float velocityX;

    /// <summary>
    /// The value to the velocity of the character in the Y axis 
    /// </summary>
    private float velocityY;

    /// <summary>
    /// Contain if the character is talking
    /// </summary>
    [Header("Conversaciones")]
    private bool isTalking;

    /// <summary>
    /// Contain if the character can talk
    /// </summary>
    private bool canTalk = true;

    /// <summary>
    /// Contain if a no playable character is near
    /// </summary>
    [Header("Interctuar")]
    private bool isNPCNear;

    /// <summary>
    /// The reference to the dialogue of the NPC
    /// </summary>
    public DialogueOptions dialogueNPCNear;

    /// <summary>
    /// Contain if the player press the boton to interact
    /// </summary>
    public bool isInteractive;

    /// <summary>
    /// The singleton object of this class
    /// </summary>
    [Header("Singleton")]
    public static CharacterController characterController;

    /// <summary>
    /// Start the components of this gameObjects
    /// </summary>
    void Start()
    {
        characterController = this;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        partnerPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// The Update method moves the character and sets the animation
    /// </summary>
    void Update()
    {
        if (!isTalking)
        {
            if (!isMoving && moves != Vector2.zero)
            {
                MoveCharacter();
                setAnimation();
            }
            else
            {
                animator.SetBool("Stop", true);

            }
        }

    }

    /// <summary>
    /// Read the inputs of the moves of the character
    /// </summary>
    /// <param name="context">The context of the InputActions</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        moves = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Read the inputs of the interact buttom and execute the event
    /// </summary>
    /// <param name="context">The context of the InputActions</param>
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
    }
    /// <summary>
    /// Close the game
    /// </summary>
    /// <param name="context">The context of the InputActions</param>
    public void OnCloseGame(InputAction.CallbackContext context) {
        Application.Quit();
    
    }
    /// <summary>
    /// Set the UI of the Debug mode 
    /// </summary>
    private void OnGUI()
    {
        //GUILayout.TextArea(characterOptions.isInteractive.ToString());
    }

    /// <summary>
    /// Move the character with the inputs of the user
    /// </summary>
    public void MoveCharacter()
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

    /// <summary>
    /// Change the animator of the character
    /// </summary>
    private void setAnimation()
    {
        velocityX = moves.x;
        velocityY = moves.y;
        animator.SetBool("Stop", false);
        animator.SetFloat("VelocityX", velocityX);
        animator.SetFloat("VelocityY", velocityY);

    }

    /// <summary>
    /// Get the character position
    /// </summary>
    /// <returns>The character position</returns>
    public Vector2 GetPosition()
    {
        return transform.position;
    }

    /// <summary>
    /// Return the target posticion
    /// </summary>
    /// <returns>The target position</returns>
    public Vector2 GetTargetPosition()
    {
        return targetPosition;
    }

    /// <summary>
    /// Return the inputs of the player move
    /// </summary>
    /// <returns>The inputs of the player move</returns>
    public Vector2 GetMoves()
    {
        return moves;
    }

    /// <summary>
    /// The Cooldown that determine the time that the user must wait to go to the next dialogue
    /// </summary>
    private IEnumerator CoolDownTalk()
    {
        canTalk = false;
        yield return new WaitForSeconds(1);
        canTalk = true;
    }

    /// <summary>
    /// Stop the dialogue talking
    /// </summary>
    public void StopTalking()
    {
        isTalking = false;
    }

    /// <summary>
    /// Start the dialogue talking
    /// </summary>
    public void StartTalking()
    {
        isTalking=true;
    }

    /// <summary>
    /// Set the actual dialogue with a No Playable Character Dialogue
    /// </summary>
    /// <param name="dialogue">The dialogueof the NPC</param>
    public void SetNPCDialogue(DialogueOptions dialogue)
    {
        dialogueNPCNear = dialogue;
        isNPCNear = true;
    }

    /// <summary>
    /// Set that a No Playable Character is not near
    /// </summary>
    public void EarseNPCDialogue()
    {
        isNPCNear = false;
    }

}
