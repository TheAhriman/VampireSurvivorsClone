using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private Animator animator;
    [SerializeField] ThunderLauncher launcher;

    public ThunderLauncher ThunderLauncher
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        launcher = FindAnyObjectByType(typeof(ThunderLauncher)).GetComponent<ThunderLauncher>();
        DestroySpell();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        launcher.DealDamage(collision.gameObject);
    }

    public void DestroySpell()
    {
        StartCoroutine(WaitForAnimationEnd());
    }

    private System.Collections.IEnumerator WaitForAnimationEnd()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        float animationLength = clipInfo[0].clip.length;

        yield return new WaitForSeconds(animationLength);

        Destroy(gameObject);
    }
}
