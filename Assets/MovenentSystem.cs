using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MovenentSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MovementComponent movement, ref Translation translation) =>
        {
            translation.Value.y += movement.speed * Time.deltaTime;
            //上下移动边界数控制
            if (translation.Value.y > 4f)
            {
                //改为负数
                movement.speed = -Mathf.Abs(movement.speed);
            }
            if(translation.Value.y<-1f)
            {
                //改为正数
                movement.speed = Mathf.Abs(movement.speed);
            }
        });
    }
}
