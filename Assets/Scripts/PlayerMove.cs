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
    private SpriteRenderer spriteRenderer = null;
    private bool isDamaged = false;

    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab=null;
    [SerializeField]
    private float bulletDelay = 0.5f;
    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
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
            //InstantiateOrPool();
            GameObject newBullet = Instantiate(bulletPrefab, bulletPosition);
            newBullet.transform.position = bulletPosition.position;
            newBullet.transform.SetParent(null);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    //private GameObject InstantiateOrPool()
    //{
    //    GameObject result = null;
    //    if (gameManager.poolManager.transform.childCount > 0)
    //    {
    //        result = gameManager.poolManager.transform.GetChild(0).gameObject;
    //        result.transform.position = bulletPosition.position;
    //        result.transform.SetParent(null);
    //        result.SetActive(true);
    //    }
    //    else
    //    {
    //        GameObject newBullet = Instantiate(bulletPrefab, bulletPosition);
    //        newBullet.transform.position = bulletPosition.position;
    //        newBullet.transform.SetParent(null);
    //        result = newBullet;
    //    }
    //    return result;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isDamaged = true;
            //StartCoroutine(Damaged());
            gameManager.LifeDead();
        }
    }

    //private IEnumerator Damaged()
    //{
    //    for(int i=0;i<3;i++)
    //    {
    //        gameObject.SetActive(false);
    //        yield return new WaitForSeconds(0.1f);
    //        gameObject.SetActive(true);
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    isDamaged = false;
    //}


}
