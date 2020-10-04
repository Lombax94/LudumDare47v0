using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {

    bool _Slide = false;
    bool _InAir = false;
    bool _ChargeJump = false;
    bool _Falling = false;
    bool _JumpImpact = false;



    public bool TheSlide { get => _Slide; }
    public bool TheInAir { get => _InAir; }
    public bool TheChargeJump { get => _ChargeJump; }
    public bool TheFalling { get => _Falling; }
    public bool TheJumpImpact { get => _JumpImpact; }



    Animator _Animator;
    public Animator Animator { get => _Animator; }

    // Start is called before the first frame update
    void Start() {
        _Animator = transform.GetComponentInChildren<Animator>();


    }

    public void Slide(bool Slide) {
        //   _Animator.SetFloat("Forward", v);
        _Slide = Slide;
        _Animator.SetBool("Slide", Slide);
      //  _Animator.SetBool("Fire", fire);
    }

    public void InAir(bool InAir) {
        //   _Animator.SetFloat("Forward", v);
        _InAir = InAir;
        _Animator.SetBool("InAir", InAir);
        //  _Animator.SetBool("Fire", fire);
    }

    public void ChargeJump(bool ChargeJump) {
        //   _Animator.SetFloat("Forward", v);
        _ChargeJump = ChargeJump;
        _Animator.SetBool("ChargeJump", ChargeJump);
        //  _Animator.SetBool("Fire", fire);
    }

    public void Falling(bool Falling) {
        //   _Animator.SetFloat("Forward", v);
        _Falling = Falling;
        _Animator.SetBool("Falling", Falling);
        //  _Animator.SetBool("Fire", fire);
    }

    public void Speed(float Speed) {
        //   _Animator.SetFloat("Forward", v);
        _Animator.SetFloat("Speed", Speed);
        //  _Animator.SetBool("Fire", fire);
    }


    /// <summary>
    /// 0 == true, 1 == false
    /// </summary>
    /// <param name="JumpImpact"></param>
    public void JumpImpacts(int JumpImpact) {
        //   _Animator.SetFloat("Forward", v);
        if(JumpImpact <= 0) {
            _JumpImpact = true;
        _Animator.SetBool("JumpImpact", true);
        } else {
            _JumpImpact = false;
            _Animator.SetBool("JumpImpact", false);
        }
        //  _Animator.SetBool("Fire", fire);
    }




}
