using System;
using System.Collections.Generic;
using System.Numerics;
using ACE.Server.Physics.Common;
using ACE.Server.Physics.Animation;

namespace ACE.Server.Physics.Collision
{
    public class CollisionInfo
    {
        public bool LastKnownContactPlaneValid;
        public Plane LastKnownContactPlane;
        public bool LastKnownContactPlaneIsWater;
        public bool ContactPlaneValid;
        public Plane ContactPlane;
        public uint ContactPlaneCellID;
        public uint LastKnownContactPlaneCellID;
        public bool ContactPlaneIsWater;
        public bool SlidingNormalValid;
        public Vector3 SlidingNormal;
        public bool CollisionNormalValid;
        public Vector3 CollisionNormal;
        public Vector3 AdjustOffset;
        public int NumCollideObject;
        public List<PhysicsObj> CollideObject;
        public PhysicsObj LastCollidedObject;
        public bool CollidedWithEnvironment;
        public int FramesStationaryFall;

        public CollisionInfo()
        {
            Init();
        }

        public void Init()
        {
            CollideObject = new List<PhysicsObj>();
        }

        public void SetContactPlane(Plane plane, bool isWater)
        {
            ContactPlaneValid = true;
            ContactPlane = new Plane(plane.Normal, plane.D);
            ContactPlaneIsWater = isWater;
        }

        public void SetCollisionNormal(Vector3 normal)
        {
            CollisionNormalValid = true;
            CollisionNormal = normal;   // use original?
            if (Vec.NormalizeCheckSmall(ref normal))
                CollisionNormal = Vector3.Zero;
        }

        public void SetSlidingNormal(Vector3 normal)
        {
            SlidingNormalValid = true;
            SlidingNormal = new Vector3(normal.X, normal.Y, 0.0f);
            if (Vec.NormalizeCheckSmall(ref normal))
                SlidingNormal = Vector3.Zero;
        }

        public void AddObject(PhysicsObj obj, TransitionState state)
        {
            if (CollideObject.Contains(obj))
                return;

            CollideObject.Add(obj);
            NumCollideObject++;

            if (state != TransitionState.OK)
                LastCollidedObject = obj;
        }

        public override string ToString()
        {
            var str = $"LastKnownContactPlaneValid: {LastKnownContactPlaneValid}\n";

            if (LastKnownContactPlane != null)
                str += $"LastKnownContactPlane: {LastKnownContactPlane}\n";

            str += $"LastKnownContactPlaneIsWater: {LastKnownContactPlaneIsWater}\n";
            str += $"ContactPlaneValid: {ContactPlaneValid}\n";
            str += $"ContactPlaneCellID: {ContactPlaneCellID:X8}\n";
            str += $"LastKnownContactPlaneCellID: {LastKnownContactPlaneCellID:X8}\n";
            str += $"ContactPlaneIsWater: {ContactPlaneIsWater}\n";
            str += $"SlidingNormalValid: {SlidingNormalValid}\n";
            str += $"CollisionNormalValid: {CollisionNormalValid}\n";
            str += $"CollisionNormal: {CollisionNormal}\n";
            str += $"AdjustOffset: {AdjustOffset}\n";
            str += $"NumCollidObject: {NumCollideObject}\n";
            if (CollideObject != null)
                for (var i = 0; i < CollideObject.Count; i++)
                    str += $"CollideObject[{i}]: {CollideObject[i].Name} ({CollideObject[i].ID:X8})\n";

            if (LastCollidedObject != null)
                str += $"LastCollidedObject: {LastCollidedObject.Name} ({LastCollidedObject.ID:X8}\n";

            str += $"CollidedWithEnvironment: {CollidedWithEnvironment}\n";
            str += $"FramesStationaryFall: {FramesStationaryFall}\n";

            return str;
        }
    }
}
