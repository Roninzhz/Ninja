using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//移动力
	public float force_move;
	//跳跃速度
	public float jumpspeed;
	private Rigidbody2D rb;
	private Animator an;
	//判断是否在地面
	private bool isGround = false;
	// Update is called once per frame

	//获取组件
	void Awake()
    {
		rb = this.GetComponent<Rigidbody2D>();
		an = this.GetComponent<Animator>();
    }
	void Update () {

		Vector2 vector = rb.velocity;
		//判断水平方向
		float h = Input.GetAxis("Horizontal");
		//右
        if (h > 0.01f)
        {
			//右
            rb.AddForce(Vector2.right * force_move);
			//朝向
			transform.localScale = new Vector3(1, 1, 1);
        }
		else if(h<-0.01f)//左
        {
			//左
			rb.AddForce(Vector2.left * force_move);
			//朝向
			transform.localScale = new Vector3(-1, 1, 1);
		}

		//两个方式  vector.x
		//Vector2 vector = rb.velocity;
		//奔跑
		an.SetFloat("Horizontal", Mathf.Abs(vector.x));
		//跳跃
		if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
			//进行跳跃
			vector.y = jumpspeed;
			rb.velocity = vector;
        }

		an.SetFloat("vertical", rb.velocity.y);
	}

	//碰撞检测
	public void OnCollisionEnter2D()
    {
		isGround = true;
    }
	public void OnCollisionExit2D()
	{
		isGround = false;
	}
}
