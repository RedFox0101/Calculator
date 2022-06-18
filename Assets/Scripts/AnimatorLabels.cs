using System.Collections;
using UnityEngine;

public class AnimatorLabels : MonoBehaviour
{
    [SerializeField] private Animator _animatorResultatLabel;
    [SerializeField] private Animator _animatorPrematureResultatLabel;

    private float _animationPlayTime;

    private void Awake()
    {
        _animationPlayTime = _animatorResultatLabel.GetCurrentAnimatorStateInfo(0).length;

    }

    private void OnEnable()
    {
        StartCoroutine(StartAnimatin(_animationPlayTime));
    }

    private void OnDisable()
    {
        _animatorPrematureResultatLabel.SetBool("Start", false);
        _animatorResultatLabel.SetBool("Start", false);
    }

    private IEnumerator StartAnimatin(float timeSecond)
    {
        _animatorPrematureResultatLabel.SetBool("Start", true);
        _animatorResultatLabel.SetBool("Start", true);
        yield return new WaitForSeconds(timeSecond);
        enabled = false;
    }
}
