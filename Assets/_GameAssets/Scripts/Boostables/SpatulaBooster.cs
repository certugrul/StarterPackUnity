using System;
using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostable
{
    [Header("References")]
    [SerializeField] private Animator _spatulaAnimator;


    [Header("Settings")]
    [SerializeField] private float _jumpForce;

    private bool _isActivated;

    public void Boost(PlayerController playerController)
    {
        if (_isActivated) return;
        PlayBoostAnimation();
        Rigidbody rigidbody = playerController.GetPlayerRigidbody();
        rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, 0f, rigidbody.linearVelocity.z);
        rigidbody.AddForce(transform.forward * _jumpForce, ForceMode.Impulse);
        _isActivated = true;
        Invoke(nameof(ResetActivation), 0.2f);
    }
    private void PlayBoostAnimation()
    {
        _spatulaAnimator.SetTrigger(Consts.OtherAnimations.IS_SPATULA_JUMPING);
    }
    private void ResetActivation()
    {
        _isActivated = false;
    }

}
