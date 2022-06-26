using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;

namespace StorybrewScripts
{
    class Background : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            GenerateBackground();
            Overlay();
            Gray();
        }
        void GenerateBackground()
        {
            var s = GetLayer("1").CreateSprite("Camellia_OOParts_OWC_BGwoText.jpg");
            s.Fade(0, 0);

            var bitmap = GetMapsetBitmap("sb/b.jpg");

            var sprite = GetLayer("1").CreateSprite("sb/b.jpg");
            sprite.Scale(3980, 935f / bitmap.Width);
            sprite.Rotate(3980, 0);
            sprite.Fade(3980, 11980, 0, 1);
            sprite.Color(11980, 27981, new Color4(64, 64, 64, 1), new Color4(255, 255, 255, 1));
            sprite.Fade(OsbEasing.OutSine, 42615, 46460, 1, 0.5);
            sprite.Fade(OsbEasing.InSine, 46460, 48710, 0.5, 1);
            sprite.Fade(48710, 0);
            sprite.Fade(78886, 1);
            sprite.Fade(OsbEasing.OutSine, 84243, 85743, 1, 0.6);
            sprite.Fade(92600, 1);
            sprite.Fade(119366, 0);
            sprite.Fade(125766, 1);
            sprite.Fade(150788, 0);
            sprite.Fade(168434, 1);
            sprite.Rotate(168434, 0);
            sprite.Fade(172549, 173919, 1, 0.7);
            sprite.Fade(173919, 1);
            sprite.Fade(179253, 181919, 1, 0.7);
            sprite.Fade(181919, 1);
            sprite.Fade(222522, 0);
            sprite.Fade(269366, 1);
            sprite.Fade(306829, 0.8);
            sprite.Fade(324390, 325561, 0.8, 0);
            sprite.Rotate(378270, 0);
            sprite.Fade(378270, 0.6);
            sprite.Fade(399140, 407487, 0.6, 0);

            var velocity = 7500;
            var rotateStart = MathHelper.DegreesToRadians(Random(-5, 5));
            var rotateEnd = MathHelper.DegreesToRadians(Random(-5, 5));

            var startPos = new Vector2(Random(315, 325), Random(235, 245));
            var endPos = new Vector2(Random(315, 325), Random(235, 245));
            var startPos1 = new Vector2(Random(315, 325), Random(235, 245));
            var endPos1 = new Vector2(Random(315, 325), Random(235, 245));

            sprite.StartLoopGroup(92600, (119366 - 92600) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 4, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 4, velocity / 2, endPos, startPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity / 4 * 3, startPos1, endPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 4 * 3, velocity, endPos1, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotateStart, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotateStart);
            sprite.EndGroup();

            sprite.StartLoopGroup(125766, (149259 - 125766) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 4, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 4, velocity / 2, endPos, startPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity / 4 * 3, startPos1, endPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 4 * 3, velocity, endPos1, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotateStart, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotateStart);
            sprite.EndGroup();

            sprite.StartLoopGroup(181919, (221329 - 181919) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 4, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 4, velocity / 2, endPos, startPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity / 4 * 3, startPos1, endPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 4 * 3, velocity, endPos1, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotateStart, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotateStart);
            sprite.EndGroup();

            sprite.StartLoopGroup(269366, (324390 - 269366) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 4, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 4, velocity / 2, endPos, startPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity / 4 * 3, startPos1, endPos1);
            sprite.Move(OsbEasing.InOutSine, velocity / 4 * 3, velocity, endPos1, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotateStart, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotateStart);
            sprite.EndGroup();
        }
        void Overlay()
        {
            var back = GetLayer("Back").CreateSprite("sb/p.png");
            back.ScaleVec(64390, 854, 480);
            back.Color(64390, new Color4(255, 255, 255, 1));
            back.Fade(64390, 1);
            back.Fade(78886, 0);
            back.Fade(119366, 1);
            back.Additive(125766, 126166);
            back.Fade(125766, 126166, 1, 0);
            back.Color(119366, 120967, new Color4(240, 240, 240, 1), new Color4(255, 255, 255, 1));
            back.Fade(150788, 1);
            back.Color(150788, 153787, new Color4(240, 240, 240, 1), new Color4(200, 200, 200, 1));
            back.Color(OsbEasing.OutSine, 165611, 165787, new Color4(200, 200, 200, 1), new Color4(150, 150, 150, 1));
            back.Color(OsbEasing.InSine, 165787, 165964, new Color4(150, 150, 150, 1), new Color4(200, 200, 200, 1));
            back.Fade(168434, 168777, 1, 0);
            back.Additive(168434, 168777);
            back.Fade(260000, 1);
            back.Color(258829, new Color4(255, 255, 255, 1));
            back.Color(264683, 268195, new Color4(255, 255, 255, 1), new Color4(0, 0, 0, 1));
            back.Fade(269366, 0);
            back.Color(344293, new Color4(255, 255, 255, 1));
            back.Fade(344293, 348864, 0, 1);
            back.Additive(361574, 362618);
            back.Fade(361574, 362618, 1, 0);

            var q = GetLayer("Back").CreateSprite("sb/hl.png");
            q.Scale(75330, 2);
            q.Color(75330, new Color4(0, 0, 0, 1));
            q.Fade(75330, 75552, 0, 0.6);
            q.Fade(75552, 75775, 0.6, 0);

            var vig = GetLayer("Vignette").CreateSprite("sb/v.png");
            vig.Fade(63430, 64390, 0, 1);
            vig.Fade(78886, 79100, 1, 0);
            vig.Fade(118959, 119367, 0, 1);
            vig.Fade(125366, 125766, 1, 0);
            vig.Fade(150406, 150788, 0, 1);
            vig.Fade(168434, 168777, 1, 0);
            vig.Fade(250634, 258829, 0, 1);
            vig.Fade(269366, 0);
            vig.Fade(325561, 326732, 0, 1);
            vig.Fade(399140, 403313, 1, 0);

            var timeStep = Beatmap.GetTimingPointAt(386618).BeatDuration / 4;
            back.StartLoopGroup(386618, (int)((394379 - 386618) / timeStep));
            back.Fade(0, timeStep, 0.1, 0);
            back.EndGroup();

            timeStep = Beatmap.GetTimingPointAt(394444).BeatDuration / 3;
            back.StartLoopGroup(394444, (int)((394922 - 394444) / timeStep));
            back.Fade(0, timeStep, 0.1, 0);
            back.EndGroup();

            timeStep = Beatmap.GetTimingPointAt(394966).BeatDuration / 4;
            back.StartLoopGroup(394966, (int)((399270 - 394966) / timeStep));
            back.Fade(0, timeStep, 0.1, 0);
            back.EndGroup();
        }
        void Gray()
        {
            var bitmap = GetMapsetBitmap("sb/b1.jpg");
            var sprite = GetLayer("1").CreateSprite("sb/b1.jpg");
            sprite.Scale(325561, 854f / bitmap.Width);
            sprite.Fade(325561, 0.6);
            sprite.Fade(344293, 0);

            var timeStep = Beatmap.GetTimingPointAt(325561).BeatDuration;
            var pulse = GetLayer("1").CreateSprite("sb/b1.jpg");
            pulse.StartLoopGroup(325561, (334927 - 325561) / (int)timeStep);
            pulse.Scale(0, timeStep, 854f / bitmap.Width, 854f / bitmap.Width + 0.01);
            pulse.Fade(0, timeStep, 0.3, 0);
            pulse.EndGroup();

            pulse.StartLoopGroup(336098, (339537 - 336098) / (int)timeStep);
            pulse.Scale(0, timeStep, 854f / bitmap.Width, 854f / bitmap.Width + 0.01);
            pulse.Fade(0, timeStep, 0.3, 0);
            pulse.EndGroup();

            pulse.StartLoopGroup(339610, 2);
            pulse.Scale(0, 219, 854f / bitmap.Width, 854f / bitmap.Width + 0.01);
            pulse.Fade(0, 219, 0.3, 0);
            pulse.Scale(219, 538, 854f / bitmap.Width, 854f / bitmap.Width + 0.01);
            pulse.Fade(219, 538, 0.3, 0);
            pulse.Scale(538, 677, 854f / bitmap.Width, 854f / bitmap.Width + 0.01);
            pulse.Fade(538, 677, 0.3, 0);
            pulse.Scale(677, 1263, 854f / bitmap.Width, 854f / bitmap.Width + 0.01);
            pulse.Fade(677, 1263, 0.3, 0);
            pulse.EndGroup();

            timeStep = Beatmap.GetTimingPointAt(342244).BeatDuration / 2;
            pulse.StartLoopGroup(342244, (343122 - 342244) / (int)timeStep);
            pulse.Scale(0, timeStep, 854f / bitmap.Width, 854f / bitmap.Width + 0.01);
            pulse.Fade(0, timeStep, 0.3, 0);
            pulse.EndGroup();

            sprite.Fade(361574, 0.6);
            sprite.Fade(378270, 0);

            pulse.Scale(361574, 854f / bitmap.Width);
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (hitobject.StartTime >= 361574 && hitobject.StartTime <= 378205)
                {
                    pulse.Fade(hitobject.StartTime, hitobject.EndTime + 30, 0.2, 0);
                }
            }
        }
    }
}
