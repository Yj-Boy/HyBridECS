using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class CreateCubeEntitesManager : MonoBehaviour
{
    //游戏对象预设
    public GameObject goPrefab;
    //对象克隆数量
    public int XNum = 10;
    public int YNum = 10;
    //实体对象
    Entity entity;
    //实体管理器对象
    EntityManager entityMgr;

    private void Start()
    {
        //参数检查
        if (goPrefab == null)
        {
            Debug.Log(GetType() + "/Start()/游戏预设没有指定，请检查！");
        }
        //将对象转为实体（entity）
        entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(goPrefab, World.Active);
        //得到实体管理器（EntityManager）
        entityMgr = World.Active.EntityManager;
        //按照指定的数量，克隆大量实体，且指定分布位置
        for (int x=0; x < XNum; x++)
        {
            for (int y = 0; y < YNum; y++)
            {
                //从实体预设，大量克隆实体
                Entity entityClone = entityMgr.Instantiate(entity);
                //对克隆实体，定义其初始位置
                Vector3 postition = transform.TransformPoint(new float3(x - XNum / 2, noise.cnoise(new float2(x, y) * 0.21f), y - YNum / 2));
                //实体管理器设置其中的组件参数
                entityMgr.SetComponentData(entityClone, new Translation() { Value = postition });
                //把定义的组件加入到实体管理器中
                entityMgr.AddComponentData(entityClone, new MovementComponent() { speed = 1f });
            }
        }
    }
}
