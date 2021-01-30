using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    private CameraShake cameraShake;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        cameraShake = GetComponent<CameraShake>();
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
    
    public void Run(bool isRunning)
    {
        animator.SetBool("Run", isRunning);
    }

    public void Death()
    {
        movement.enabled = false;
        animator.SetTrigger("Death");
        var timeDelay = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(PlayAgain(timeDelay));
        StartCoroutine(cameraShake.ShakeCamera(timeDelay));
    }

    private IEnumerator PlayAgain(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Well");
    }
}
