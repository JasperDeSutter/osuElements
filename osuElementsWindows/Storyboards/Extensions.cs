using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;
using static osuElements.Storyboards.Easing;
using static osuElements.Storyboards.TransformTypes;

namespace osuElements.Storyboards
{
    public static class TransformableExtensions
    {
        public static void AddTransformation(this ITransformable transformable, TransformTypes transformType,
            int startTime, int endTime, Easing easing, params float[][] floats) {
            if (floats == null || floats.Length < 1) return;
            endTime = Math.Max(endTime, startTime);
            if (floats.Length < 3)
                transformable.AddTransformation(new TransformationEvent(transformType, easing, startTime, endTime,
                    floats.First(),
                    floats.Last()));
            else {
                var duration = endTime - startTime;
                for (var i = 0; i < floats.Length - 1; i++) {
                    transformable.AddTransformation(new TransformationEvent(transformType, easing,
                        startTime + duration * i,
                        endTime + duration * i, floats[i], floats[i + 1]));
                }
            }
        }

        #region Multifloat

        public static void Color(this ITransformable transformable, int startTime, int endTime,
            Easing easing = None, params Colour[] values) {
            transformable.AddTransformation(C, startTime, endTime, easing,
                values.Select(c => new float[] { c.RedValue, c.GreenValue, c.BlueValue }).ToArray());
        }
        public static void Color(this ITransformable transformable, int startTime, Colour value) {
            Color(transformable, startTime, startTime, None, value);
        }

        public static void Move(this ITransformable transformable, int startTime, int endTime,
            Easing easing = None, params Position[] values) {
            transformable.AddTransformation(M, startTime, endTime, easing, values.Select(p => new[] { p.X, p.Y }).ToArray());
        }
        public static void Move(this ITransformable transformable, int startTime, Position value) {
            transformable.Move(startTime, startTime, None, value);
        }

        public static void ScaleVector(this ITransformable transformable, int startTime, int endTime,
            Easing easing = None, params Position[] values) {
            transformable.AddTransformation(V, startTime, endTime, easing, values.Select(p => new[] { p.X, p.Y }).ToArray());
        }
        public static void ScaleVector(this ITransformable transformable, int startTime, Position value) {
            transformable.ScaleVector(startTime, startTime, None, value);
        }



        #endregion

        #region Singlefloat

        public static void Scale(this ITransformable transformable, int startTime, int endTime,
            Easing easing, params float[] values) {
            transformable.AddTransformation(S, startTime, endTime, easing, values.Select(p => new[] { p }).ToArray());
        }

        public static void Scale(this ITransformable transformable, int startTime, float value) {
            transformable.Scale(startTime, startTime, None, value);
        }

        public static void MoveX(this ITransformable transformable, int startTime, int endTime,
            Easing easing, params float[] values) {
            transformable.AddTransformation(MX, startTime, endTime, easing, values.Select(p => new[] { p }).ToArray());
        }

        public static void MoveX(this ITransformable transformable, int startTime, float value) {
            transformable.MoveX(startTime, startTime, None, value);
        }

        public static void MoveY(this ITransformable transformable, int startTime, int endTime,
            Easing easing, params float[] values) {
            transformable.AddTransformation(MY, startTime, endTime, easing, values.Select(p => new[] { p }).ToArray());
        }

        public static void MoveY(this ITransformable transformable, int startTime, float value) {
            transformable.MoveY(startTime, startTime, None, value);
        }

        public static void Rotate(this ITransformable transformable, int startTime, int endTime,
            Easing easing, params float[] values) {
            transformable.AddTransformation(R, startTime, endTime, easing, values.Select(p => new[] { p }).ToArray());
        }

        public static void Rotate(this ITransformable transformable, int startTime, float value) {
            transformable.Rotate(startTime, startTime, None, value);
        }

        public static void Fade(this ITransformable transformable, int startTime, int endTime,
            Easing easing, params float[] values) {
            transformable.AddTransformation(F, startTime, endTime, easing, values.Select(p => new[] { p }).ToArray());
        }

        public static void Fade(this ITransformable transformable, int startTime, float value) {
            transformable.Fade(startTime, startTime, None, value);
        }

        #endregion

        #region Parameters

        public static void FlipH(this ITransformable transformable, int startTime, int endTime) {
            transformable.AddTransformation(new ParameterEvent(startTime, Math.Max(startTime, endTime), ParameterTypes.H));
        }

        public static void FlipV(this ITransformable transformable, int startTime, int endTime) {
            transformable.AddTransformation(new ParameterEvent(startTime, Math.Max(startTime, endTime), ParameterTypes.V));
        }

        public static void Additive(this ITransformable transformable, int startTime, int endTime) {
            transformable.AddTransformation(new ParameterEvent(startTime, Math.Max(startTime, endTime), ParameterTypes.A));
        }
        #endregion


        private static void Optimization2(ICollection<TransformationEvent> passed, TransformationEvent transform) {
            foreach (var pass in passed.Where(pass => MathHelper.Between(transform.StartTime, pass.StartTime, pass.EndTime))) {
                if (MathHelper.Between(transform.EndTime, pass.StartTime, pass.EndTime))
                    return; //event is completely useless
                //we can only interpolate without easing, otherwise not desired effect (might look into this further)
                if (transform.Tweening && transform.Easing != None) continue;
                transform.StartValues = transform.ValuesAt(pass.EndTime);
                transform.StartTime = pass.EndTime; //move the starttime and interpolate values
            }
            passed.Add(transform);
        }

        public static void OptimizeTransformations(this ITransformable transformable) {
            var transforms = transformable.Transformations.OrderBy(t => t.StartTime).GroupBy(t => t.Transformtype)
                .ToDictionary(t => t.Key, t => t.ToList());
            var globalstart = transformable.Transformations.Min(t => t.StartTime);
            var globalend = transformable.Transformations.Max(t => t.EndTime);
            //splits all M transforms in separate MX and MY, otherwise they will not work
            //only when there are other MX or MY events, M is fine otherwise
            if (transforms[M].Any() && (transforms[MX].Any() || transforms[MY].Any())) {
                foreach (var m in transforms[M]) {
                    var mx = new TransformationEvent(MX, m.Easing, m.StartTime, m.EndTime, m.StartValues[0].AsArray(),
                        m.EndValues[0].AsArray());
                    var my = new TransformationEvent(MY, m.Easing, m.StartTime, m.EndTime, m.StartValues[1].AsArray(),
                        m.EndValues[1].AsArray());
                    transformable.AddTransformation(mx);
                    transformable.AddTransformation(my);
                }
                transformable.Transformations.RemoveAll(t => t.Transformtype == M);
                transforms = transformable.Transformations.OrderBy(t => t.StartTime).GroupBy(t => t.Transformtype)
                .ToDictionary(t => t.Key, t => t.ToList());
                globalstart = transformable.Transformations.Min(t => t.StartTime);
                globalend = transformable.Transformations.Max(t => t.EndTime);
            }

            //strip off unneeded parts of transformations
            foreach (var transformList in transforms.Values) {
                var passed = new List<TransformationEvent>();
                //resulting collection after optimization, might contain less or modifed transforms
                foreach (var transform in transformList) {
                    Optimization2(passed, transform);
                }
                //we can now trim down events without tweening
                foreach (var transform in passed) {
                    if (transform.EndTime == globalend && transform.StartTime == globalstart)
                        continue; //might be needed for visibility of the sprite
                    if (!passed.Any(p => MathHelper.Between(p.StartTime, transform.StartTime, transform.EndTime) ||
                                         MathHelper.Between(p.EndTime, transform.StartTime, transform.EndTime))) {
                        //no other transforms are active
                        transform.EndTime = transform.StartTime;
                    }
                }
                transforms[transformList[0].Transformtype] = passed;
            }

            //TODO disable invisible parts of transformations

            //var fade0 = 0f.AsArray();

            //var fades = transformable.Transformations.Where(t => t.Transformtype == F);
            //if (!fades.Any(t => t.StartValues == fade0 || t.EndValues == fade0)) return; //everything is always visible
            //foreach (var transformType in _normalTransformations) {
            //    var transformables = transformable.Transformations.Where(t => t.Transformtype == transformType);
            //    if (!transformables.Any()) continue;
            //}
        }
    }
}