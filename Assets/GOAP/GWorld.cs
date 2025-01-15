using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public static class GWorld
    {
        private static readonly WorldStates World;
        
        private static readonly Queue<GameObject> ArcherTowers = new();
        private static readonly List<GameObject> DefensePosts = new();

        static GWorld()
        {
            World = new WorldStates();

            var towers = GameObject.FindGameObjectsWithTag("ArcherTower");
            foreach (var tower in towers)
                ArcherTowers.Enqueue(tower);
            
            var posts = GameObject.FindGameObjectsWithTag("DefensePost");
            foreach (var post in posts)
                DefensePosts.Add(post);

            Time.timeScale = 5;
        }

        public static WorldStates GetWorld()
        {
            return World;
        }
        
        public static void AddArcherTower(GameObject tower)
        {
            ArcherTowers.Enqueue(tower);
        }
        
        public static GameObject RemoveArcherTower()
        {
            if (ArcherTowers.Count == 0)
                return null;
            var tower = ArcherTowers.Dequeue();
            return tower;
        }
        
        public static void AddDefensePost(GameObject post)
        {
            DefensePosts.Add(post);
        }
        
        public static GameObject RemoveNearestDefensePost(Vector3 position)
        {
            if (DefensePosts.Count == 0)
                return null;
            var nearestPost = DefensePosts[0];
            var nearestDistance = Vector3.Distance(nearestPost.transform.position, position);
            foreach (var post in DefensePosts)
            {
                var distance = Vector3.Distance(post.transform.position, position);
                if (distance < nearestDistance)
                {
                    nearestPost = post;
                    nearestDistance = distance;
                }
            }
            DefensePosts.Remove(nearestPost);
            return nearestPost;
        }
    }
}
