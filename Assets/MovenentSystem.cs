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

        });
    }
}
