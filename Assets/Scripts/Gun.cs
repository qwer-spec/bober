using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform stvol;
    [SerializeField] private Transform bulletPoll;
    [SerializeField] private Bullet[] bullets;
    
    [SerializeField] private int bulletSpeed = 10;

    private int currentBullerId = 0;
    private bool isCanShoot = true;
    private void Awake()
    {
        bullets = bulletPoll.GetComponentsInChildren<Bullet>();

        foreach (var bullet in bullets)
            bullet.gameObject.SetActive(false);
    }


    private void Update()
    {
        Rotate();

        if (Input.GetKey(KeyCode.Mouse0))
            Fire();
    }

    private void Rotate()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - stvol.position;
        stvol.eulerAngles = new Vector3 (0, 0, Mathf.Atan2  (dir.y, dir.x) * Mathf.Rad2Deg);
    }

    private void Fire()
    {
            if (!isCanShoot) return;

            bullets[currentBullerId].Fire(stvol.right, bulletSpeed);

            if (currentBullerId < bullets.Length - 1)
                currentBullerId++;
            else
                currentBullerId = 0;

        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown() 
    {
      isCanShoot = false;
      yield return new WaitForSeconds(0.5f);
      isCanShoot = true;
      yield return null;
    }
}
