using UnityEditor;
using UnityEngine;

public class crabMovement : MonoBehaviour
{
    [SerializeField] private Transform pos1, pos2;
    [SerializeField] private float speed;
    private SpriteRenderer crabSprite;
    private Vector2 posTarget;
    Animator animCrab;
    private void Start()
    {
        crabSprite = GetComponent<SpriteRenderer>();
        posTarget=pos1.position;
        animCrab = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position,pos1.position) < .1f)
        {
            posTarget = pos2.position;
            crabSprite.flipX = true;
        }
        if (Vector2.Distance(transform.position, pos2.position) < .1f)
        {
            posTarget = pos1.position;
            crabSprite.flipX = false;
        }
        transform.position=Vector2.MoveTowards(transform.position, posTarget, speed*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Nếu con cua va chạm sẽ đẩy nhân vật ra xa
        }
        if(collision.gameObject.tag == "Bullet")
        {
            // Nếu con cua va chạm với đạn của nhân vật thì sẽ bị trừ máu, hết máu thì chết, xóa đạn
            animCrab.SetTrigger("Death2");
            Destroy(gameObject, 0.6f);
        }
    }
}
