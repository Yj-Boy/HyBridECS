using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

//自己定义的数据组件，必须是struct
public struct MovementComponent : IComponentData
{
    public float speed;
}
