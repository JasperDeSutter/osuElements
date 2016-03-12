using System;
using System.Linq;
using osuElements.Helpers;
using static osuElements.Helpers.TransformTypes;

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
                        startTime + duration*i,
                        endTime + duration*i, floats[i], floats[i + 1]));
                }
            }
        }

        public static void Color(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params Colour[] values) {
            transformable.AddTransformation(C, startTime, endTime, easing,
                values.Select(c => new float[]{c.Red, c.Green, c.Blue}).ToArray());
        }

        public static void Move(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params Position[] values) {
            transformable.AddTransformation(M, startTime, endTime, easing, values.Select(p => new[]{p.X, p.Y}).ToArray());
        }

        public static void ScaleVector(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params Position[] values) {
            transformable.AddTransformation(V, startTime, endTime, easing, values.Select(p => new[]{p.X, p.Y}).ToArray());
        }

        public static void Scale(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params float[] values) {
            transformable.AddTransformation(S, startTime, endTime, easing, values.Select(p => new[]{p}).ToArray());
        }

        public static void MoveX(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params float[] values) {
            transformable.AddTransformation(MX, startTime, endTime, easing, values.Select(p => new[]{p}).ToArray());
        }

        public static void MoveY(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params float[] values) {
            transformable.AddTransformation(MY, startTime, endTime, easing, values.Select(p => new[]{p}).ToArray());
        }

        public static void Rotate(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params float[] values) {
            transformable.AddTransformation(R, startTime, endTime, easing, values.Select(p => new[]{p}).ToArray());
        }

        public static void Fade(this ITransformable transformable, int startTime, int endTime = int.MinValue,
            Easing easing = Easing.None, params float[] values) {
            transformable.AddTransformation(F, startTime, endTime, easing, values.Select(p => new[]{p}).ToArray());
        }

        public static void FlipH(this ITransformable transformable, int startTime, int endTime = int.MinValue) {
            transformable.AddTransformation(new ParameterEvent(startTime, Math.Max(startTime, endTime), ParameterTypes.H));
        }

        public static void FlipV(this ITransformable transformable, int startTime, int endTime = int.MinValue) {
            transformable.AddTransformation(new ParameterEvent(startTime, Math.Max(startTime, endTime), ParameterTypes.V));
        }

        public static void Additive(this ITransformable transformable, int startTime, int endTime = int.MinValue) {
            transformable.AddTransformation(new ParameterEvent(startTime, Math.Max(startTime, endTime), ParameterTypes.A));
        }

        private static readonly TransformTypes[] _normalTransformations = {M, MX, MY, F, R, S, V, C, P};

        public static void OptimizeTransformations(this ITransformable transformable) {
            var transforms = transformable.Transformations.GroupBy(t => t.Transformtype)
                .ToDictionary(t => t.Key, t => t.ToList());
            //splits all M transforms in separate MX and MY, otherwise they will not work
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
                transforms[M].Clear();
            }



            //TODO disable invisible parts of transformations

            var fade0 = 0f.AsArray();

            var fades = transformable.Transformations.Where(t => t.Transformtype == F);
            if (!fades.Any(t => t.StartValues == fade0 || t.EndValues == fade0)) return; //everything is always visible
            foreach (var transformType in _normalTransformations) {
                var transformables = transformable.Transformations.Where(t => t.Transformtype == transformType);
                if (!transformables.Any()) continue;

            }
        }
    }
}