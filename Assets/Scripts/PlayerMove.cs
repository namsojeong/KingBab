using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    [SerializeField]
    private float movespeed = 10;
    private GameManager gameManager = null;

    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab=null;
    [SerializeField]
    private float bulletDelay = 0.5f;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(Fire());
    }
    void Update()
    {
        //조이스틱
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();
        if(x!=0||y!=0)
        {
            transform.position += new Vector3(x, y, 0) * movespeed * Time.deltaTime;
        }
    }
    private IEnumerator Fire()
    {
        // TODO: 총알 발사 스크립트를 작성해 주세요.
        while (true)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletPosition);
            newBullet.transform.position = bulletPosition.position;
            newBullet.transform.SetParent(null);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    
}
