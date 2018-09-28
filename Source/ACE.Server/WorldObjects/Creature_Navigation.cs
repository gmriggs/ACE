using System;
using System.Numerics;

using ACE.Entity;
using ACE.Entity.Enum;
using ACE.Server.Entity;
using ACE.Server.Entity.Actions;
using ACE.Server.Network.Motion;
using ACE.Server.Physics.Animation;
using ACE.Server.Physics.Extensions;

namespace ACE.Server.WorldObjects
{
    /// <summary>
    /// Creature navigation / position / rotation
    /// </summary>
    partial class Creature
    {
        /// <summary>
        /// Returns the 3D distance between this creature and target
        /// </summary>
        public float GetDistance(WorldObject target)
        {
            return Location.DistanceTo(target.Location);
        }

        /// <summary>
        /// Returns the 2D angle between current direction
        /// and position from an input target
        /// </summary>
        public float GetAngle(WorldObject target)
        {
            var currentDir = Location.GetCurrentDir();
            var targetDir = GetDirection(Location.ToGlobal(), target.Location.ToGlobal());
            
            // get the 2D angle between these vectors
            return GetAngle(currentDir, targetDir);
        }

        /// <summary>
        /// Returns the 2D angle between current direction
        /// and rotation from an input position
        /// </summary>
        public float GetAngle(Position position)
        {
            var currentDir = Location.GetCurrentDir();
            var targetDir = position.GetCurrentDir();

            // get the 2D angle between these vectors
            return GetAngle(currentDir, targetDir);
        }

        /// <summary>
        /// Returns the 2D angle of the input vector
        /// </summary>
        public static float GetAngle(Vector3 dir)
        {
            var rads = Math.Atan2(dir.Y, dir.X);
            if (double.IsNaN(rads)) return 0.0f;

            var angle = rads * 57.2958f;
            return (float)angle;
        }

        /// <summary>
        /// Returns the 2D angle between 2 vectors
        /// </summary>
        public static float GetAngle(Vector3 a, Vector3 b)
        {
            var cosTheta = a.Dot2D(b);
            var rads = Math.Acos(cosTheta);
            if (double.IsNaN(rads)) return 0.0f;

            var angle = rads * (180.0f / Math.PI);
            return (float)angle;
        }

        /// <summary>
        /// Returns a normalized 2D vector from self to target
        /// </summary>
        public Vector3 GetDirection(Vector3 self, Vector3 target)
        {
            var target2D = new Vector3(self.X, self.Y, 0);
            var self2D = new Vector3(target.X, target.Y, 0);

            return (target - self).Normalize();
        }

        /// <summary>
        /// Starts rotating a creature from its current direction
        /// so that it eventually is facing the target position
        /// </summary>
        /// <returns>The amount of time in seconds for the rotation to complete</returns>
        public virtual float Rotate(WorldObject target)
        {
            // send network message to start turning creature
            var turnToMotion = new UniversalMotion(CurrentMotionState.Stance, target.Location, target.Guid);
            turnToMotion.MovementTypes = MovementTypes.TurnToObject;
            EnqueueBroadcastMotion(turnToMotion);

            var angle = GetAngle(target);
            //Console.WriteLine("Angle: " + angle);

            // estimate time to rotate to target
            var rotateDelay = GetRotateDelay(angle);
            //Console.WriteLine("RotateTime: " + rotateTime);

            // update server object rotation on completion
            // TODO: proper incremental rotation
            var actionChain = new ActionChain();
            actionChain.AddDelaySeconds(rotateDelay);
            actionChain.AddAction(this, () =>
            {
                var targetDir = GetDirection(Location.ToGlobal(), target.Location.ToGlobal());
                Location.Rotate(targetDir);
            });
            actionChain.EnqueueChain();

            return rotateDelay;
        }

        /// <summary>
        /// Returns the amount of time for this creature to rotate by the # of degrees
        /// from the input angle, using the omega speed from its MotionTable
        /// </summary>
        public virtual float GetRotateDelay(float angle)
        {
            var turnSpeed = MotionTable.GetTurnSpeed(MotionTableId);
            if (turnSpeed == 0.0f) return 0.0f;

            var rotateTime = Math.PI / turnSpeed / 180.0f * angle;
            return (float)rotateTime;
        }

        /// <summary>
        /// Returns the amount of time for this creature to rotate
        /// towards its target, based on the omega speed from its MotionTable
        /// </summary>
        public float GetRotateDelay(WorldObject target)
        {
            var angle = GetAngle(target);
            return GetRotateDelay(angle);
        }

        /// <summary>
        /// Starts rotating a creature from its current direction
        /// so that it eventually is facing the rotation from the input position
        /// Used by the emote system, which has the target rotation stored in positions
        /// </summary>
        /// <returns>The amount of time in seconds for the rotation to complete</returns>
        public float TurnTo(Position position)
        {
            // send network message to start turning creature
            var turnToMotion = new UniversalMotion(CurrentMotionState.Stance, position);
            turnToMotion.MovementTypes = MovementTypes.TurnToHeading;
            EnqueueBroadcastMotion(turnToMotion);

            var angle = GetAngle(position);
            //Console.WriteLine("Angle: " + angle);

            // estimate time to rotate to target
            var rotateDelay = GetRotateDelay(angle);
            //Console.WriteLine("RotateTime: " + rotateTime);

            // update server object rotation on completion
            // TODO: proper incremental rotation
            var actionChain = new ActionChain();
            actionChain.AddDelaySeconds(rotateDelay);
            actionChain.AddAction(this, () =>
            {
                var targetDir = position.GetCurrentDir();
                Location.Rotate(targetDir);
            });
            actionChain.EnqueueChain();

            return rotateDelay;
        }

        /// <summary>
        /// Returns the amount of time for this creature to rotate
        /// towards the rotation from the input position, based on the omega speed from its MotionTable
        /// Used by the emote system, which has the target rotation stored in positions
        /// </summary>
        /// <param name="position">Only the rotation information from this position is used here</param>
        public float GetRotateDelay(Position position)
        {
            var angle = GetAngle(position);
            return GetRotateDelay(angle);
        }

        /// <summary>
        /// This is called by the monster AI system for ranged attacks
        /// It is mostly a duplicate of Rotate(), and should be refactored eventually...
        /// It sets CurrentMotionState and AttackTarget here
        /// </summary>
        public float TurnTo(WorldObject target, bool debug = false)
        {
            if (DebugMove)
                Console.WriteLine($"{Name}.TurnTo({target.Name})");

            if (this is Player) return 0.0f;

            var turnToMotion = new UniversalMotion(CurrentMotionState.Stance, target.Location, target.Guid);
            turnToMotion.MovementTypes = MovementTypes.TurnToObject;
            EnqueueBroadcastMotion(turnToMotion);

            CurrentMotionState = turnToMotion;

            AttackTarget = target;
            var rotateDelay = EstimateTurnTo();
            if (debug)
                Console.WriteLine("TurnTime = " + rotateDelay);
            var actionChain = new ActionChain();
            actionChain.AddDelaySeconds(rotateDelay);
            actionChain.AddAction(this, () =>
            {
                // fix me: in progress turn
                //var targetDir = GetDirection(Location.ToGlobal(), target.Location.ToGlobal());
                //Location.Rotate(targetDir);
                if (debug)
                    Console.WriteLine("Finished turning - " + rotateDelay + "s");
            });
            actionChain.EnqueueChain();
            return rotateDelay;
        }

        /// <summary>
        /// Used by the monster AI system to start turning / running towards a target
        /// </summary>
        public void MoveTo(WorldObject target, float runRate = 1.0f)
        {
            if (DebugMove)
                Console.WriteLine($"{Name}.MoveTo({target.Name}, {runRate})");

            if (this is Player) return;

            var motion = new UniversalMotion(CurrentMotionState.Stance, target.Location, target.Guid);
            motion.MovementTypes = MovementTypes.MoveToObject;
            motion.Flag |= MovementParams.CanCharge | MovementParams.FailWalk | MovementParams.UseFinalHeading | MovementParams.Sticky | MovementParams.MoveAway;
            motion.WalkRunThreshold = 1.0f;
            motion.RunRate = runRate;

            CurrentMotionState = motion;

            EnqueueBroadcastMotion(motion);
        }

        /// <summary>
        /// Sends a network message for moving a creature to a new position
        /// </summary>
        public void MoveTo(Position position, float runRate = 1.0f)
        {
            var motion = new UniversalMotion(CurrentMotionState.Stance, position);
            motion.MovementTypes = MovementTypes.MoveToPosition;
            //motion.Flag |= MovementParams.CanCharge | MovementParams.FailWalk | MovementParams.UseFinalHeading | MovementParams.MoveAway;
            motion.WalkRunThreshold = 1.0f;
            motion.RunRate = runRate;

            // todo: use better movement system
            Location = position;

            EnqueueBroadcastMotion(motion);
        }
    }
}
