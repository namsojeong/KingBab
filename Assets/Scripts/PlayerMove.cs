using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    [SerializeField]
    private float movespeed = 12f;
    [SerializeField]
    private Transform bulletPosition;
    [SerializeField]
    private GameObject bulletPrefab;
    private GameManager gameManager = null;
    private SoundManager soundManager = null;
    private SpriteRenderer spriteRenderer = null;
    private bool isDamaged = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        soundManager = FindObjectOfType<SoundManager>();
        StartCoroutine(Fire());
    }

    //�Ѿ� �ڷ�ƾ
    private IEnumerator Fire()
    {
        while (true)
        {
            InstanBullet();
            yield return new WaitForSeconds(0.22f);
        }
    }

    //�Ѿ� Ǯ��
    private GameObject InstanBullet()
    {
        GameObject result = null;
        if (gameManager.poolManager.transform.childCount > 0)
        {
            result = gameManager.poolManager.transform.GetChild(0).gameObject;
            result.transform.position = bulletPosition.position;
            result.transform.SetParent(null);
            result.SetActive(true);
        }
        else
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletPosition);
            newBullet.transform.position = bulletPosition.position;
            newBullet.transform.SetParent(null);
            result = newBullet;
        }
        return result;
    }

    //���̽�ƽ�� �̿��� �̵�
    private void Update()
    {
        //���̽�ƽ
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
        float x = virtualJoystick.Horizontal();
        float y = virtualJoystick.Vertical();
        if (x != 0 || y != 0)
        {
            transform.position += new Vector3(x, y, 0) * movespeed * Time.deltaTime;
        }
    }

    //�浹��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDamaged) return;
        isDamaged = true;
        soundManager.LifeDead();
        StartCoroutine(Damaged());
        gameManager.LifeDead();
    }

    //������ �Ծ��� �� ȿ��
    private IEnumerator Damaged()
    {
        for (int i = 0; i < 4; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        isDamaged = false;
    }

}
