using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public static GameObject CreateBullet(BulletConfigSO config, DecalsHandler decalsHandler, Transform parent)
    {
        GameObject bulletObject = new GameObject("Bullet", typeof(MeshFilter), typeof(MeshRenderer), typeof(Rigidbody));

        bulletObject.layer = config.layerIndex;
        bulletObject.GetComponent<MeshFilter>().mesh = config.mesh;
        bulletObject.GetComponent<MeshRenderer>().material = config.mat;
        bulletObject.AddComponent<BoxCollider>();
        bulletObject.AddComponent<Bullet>();
        bulletObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;

        if (config.trailObject != null)
            Instantiate(config.trailObject, bulletObject.transform);

        Bullet bullet = bulletObject.GetComponent<Bullet>();

        bullet.ShootingForce = config.bulletForce;
        bullet.LifeTime = config.lifeTime;
        bullet.Decals = decalsHandler;

        bulletObject.transform.parent = parent;
        bulletObject.transform.localPosition = Vector3.zero;
        bulletObject.transform.rotation = parent.rotation;

        return bulletObject;
    }
}
