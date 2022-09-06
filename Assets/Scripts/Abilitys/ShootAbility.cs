using UnityEngine;

public class ShootAbility : AbilityBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _bullet;
    
    protected override void StartAbility()
    {
        _animator.SetTrigger("Attack");
    }

    protected override void StopAbility()
    {
        Instantiate(_bullet, _gun.transform.position, _gun.transform.rotation);
    }

    public void SetBullet(GameObject newBullet)
    {
        _bullet = newBullet;
    }
}
