using System.Collections;
using UnityEngine;

public class AnimatorLabels : MonoBehaviour
{
    [SerializeField] private Animator _animatorResultatLabel;
    [SerializeField] private Animator _animatorPrematureResultatLabel;

    private float _time;

    private void Awake()
    {
        _time = _animatorResultatLabel.GetCurrentAnimatorStateInfo(0).length;

    }

    private void OnEnable()
    {
        StartCoroutine(StartAnimatin(_time));
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
