﻿using UnityEngine;

namespace LearnGame
{
    public static class LayerUtils
    {
        public const string BulletLayerName = "Bullet";
        public const string EnemyLayerName = "Enemy";
        public const string PLayerLayerName = "Player";

        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);

        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName);

        public static readonly int PLayerMask = LayerMask.GetMask(PLayerLayerName);

        public static bool IsBullet(GameObject other) => other.layer == BulletLayer;
    }
    
}