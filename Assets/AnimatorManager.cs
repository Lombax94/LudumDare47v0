using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {

    Animator _Animator;
    public Animator Animator { get => _Animator; }

    // Start is called before the first frame update
    void Start() {
        _Animator = transform.GetComponentInChildren<Animator>();


    }

    public void Slide(bool Slide) {
     //   _Animator.SetFloat("Forward", v);
        _Animator.SetBool("Slide", Slide);
      //  _Animator.SetBool("Fire", fire);
    }

    public void InAir(bool InAir) {
        //   _Animator.SetFloat("Forward", v);
        _Animator.SetBool("InAir", InAir);
        //  _Animator.SetBool("Fire", fire);
    }

    public void ChargeJump(bool ChargeJump) {
        //   _Animator.SetFloat("Forward", v);
        _Animator.SetBool("ChargeJump", ChargeJump);
        //  _Animator.SetBool("Fire", fire);
    }

    public void Falling(bool Falling) {
        //   _Animator.SetFloat("Forward", v);
        _Animator.SetBool("Falling", Falling);
        //  _Animator.SetBool("Fire", fire);
    }

}
