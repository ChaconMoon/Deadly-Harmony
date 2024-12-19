using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PartnerMove : MonoBehaviour
{
    [Header("Principal Character")]
    public CharacterMove mainCharacter;
    public bool followCharacter = true;
    private Vector2 mainCharacterPosition;
    private Vector2 posicionDestino;
    [Header("PartnerCharacter")]
    private Rigidbody2D rb;
    private Vector2 ultimaPosicion;
    [Header("Animaciones")]
    private IEnumerator pararMoviniento;
    private Animator animator;
    private float velocityX;
    private float velocityY;

    private void Start()
    {
            ultimaPosicion = transform.position;
            animator = GetComponent<Animator>();    
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
    }
    private void OnGUI()
    {
        //GUILayout.TextArea((mainCharacterPosition+new Vector2(transform.position.x,transform.position.y)).ToString());
    }
    public void FollowCharacter(Vector2 characterPosition, float moveSpeed)
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, characterPosition, moveSpeed));
        posicionDestino = Vector2.MoveTowards(transform.position, characterPosition, moveSpeed);
    }
    public Vector2 GetPosition() {
        return transform.position;
    
    }
    public bool IsFollow()
    {
        return followCharacter;
    }
    public void setFollow(bool follow)
    {
        followCharacter = follow;
    }
    private void ReturnToCharacter()
    {
        transform.position = Vector2.MoveTowards(transform.position, mainCharacter.GetTargetPosition(),0.1f);
    }
    private void Update()
    {
        animate();
    }
    private void animate()
    {
        if (ultimaPosicion.x-transform.position.x != 0 )
        {
            if (mainCharacter.transform.position.x - transform.position.x < 0)
            {
                animator.SetBool("Stop", false);
                animator.SetFloat("VelocityX", 1);
            }
            else
            {
                animator.SetBool("Stop", false);
                animator.SetFloat("VelocityX", -1);
            }
        }
        else
        {
            animator.SetFloat("VelocityX", 0);
        }
        if (ultimaPosicion.y - transform.position.y != 0)
        {
            if (mainCharacter.transform.position.y - transform.position.y < 0)
            {
                animator.SetBool("Stop", false);
                animator.SetFloat("VelocityY", 1);
            }
            else
            {
                animator.SetBool("Stop", false);
                animator.SetFloat("VelocityY", -1);
            }
        }
        else
        {
            animator.SetFloat("VelocityY", 0);

        }
        if (ultimaPosicion.y == transform.position.y && ultimaPosicion.x == transform.position.x)
        {
            pararMoviniento = pararAnimaciones();
            StartCoroutine(pararMoviniento);
        }
        else
        {
            StopCoroutine(pararMoviniento);
        }
        ultimaPosicion = transform.position;

    }
    IEnumerator pararAnimaciones()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Stop", true);

    }
}

