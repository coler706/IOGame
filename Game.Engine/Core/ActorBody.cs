﻿namespace Game.Engine.Core
{
    using System.Linq;

    public abstract class ActorBody : Body, IActor
    {
        public World World = null;

        public bool PendingDestruction { get; set; } = false;

        public virtual void Destroy()
        {
            if (this.Exists)
            {
                World.Actors.Remove(this);
                World.Bodies.Remove(this);
                this.Exists = false;
            }
        }

        public virtual void Init(World world)
        {
            World = world;
            this.ID = world.NextID();
            world.Actors.Add(this);
            world.Bodies.Add(this);

            this.OriginalPosition = this.Position;
            this.OriginalAngle = this.Angle;
            this.DefinitionTime = world.Time;
            this.Project(world.Time);

            this.Exists = true;
        }

        public virtual void Think()
        {
            var collisionSet =
                World.BodiesNear(this.Position, this.Size, offsetSize: true)
                .Where(b => b != this);

            if (collisionSet.Any())
            {
                foreach (var hit in collisionSet.OfType<ICollide>()
                    .Where(c => c.IsCollision(this))
                    .ToList())
                {
                    hit.CollisionExecute(this);
                    Collided(hit);
                }
            }
        }

        public virtual void CreateDestroy()
        {
            if (PendingDestruction)
            {
                PendingDestruction = false;
                Destroy();
            }
        }

        protected virtual void Collided(ICollide otherObject)
        {

        }
    }
}
