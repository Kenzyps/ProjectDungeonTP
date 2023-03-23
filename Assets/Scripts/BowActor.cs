using UnityEngine;
using System.Collections;

public class BowActor : MonoBehaviour
{
    private Vector3 mousePosition;

    [SerializeField] private Transform Player;

    [SerializeField] private GameObject bullet;
    [SerializeField] private bool canFire = true;
    private float reloadTime = 0.5f;
    [SerializeField] Transform firePoint;
    [SerializeField] private float fireForce = 10f;

    private void FixedUpdate()
    {
        transform.position = new Vector2(Player.position.x, Player.position.y - 0.5f);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Fire();
            canFire = false;
            StartCoroutine(reloadController());
        }
    }

    private IEnumerator reloadController()
    {
        yield return new WaitForSeconds(reloadTime);
        canFire = true;
    }

    private void Fire()
    {
        GameObject arrow = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Vector2 aimDirection = mousePosition - transform.position;
        arrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, aimDirection);
        arrow.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }
}
