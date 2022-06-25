using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using System;

namespace StorybrewScripts
{
    class Hitobject : StoryboardObjectGenerator
    {
        OsbSpritePools pool;
        public override void Generate()
        {
            int[] times = new int[]{
                64390, 64621, 66237, 66467, 67737, 68083, 68314, 69929, 70160, 70390, 70737, 71083, 71429, 71775, 71997,
                73552, 73775, 74997, 75552, 75997, 77108, 77330, 77552, 77886, 78219, 78552, 78886, 92600, 92814, 106217,
                106423, 119367, 119567, 120967, 121166, 122266, 122567, 122766, 124166, 124366, 124567, 124967, 125266,
                125766, 125967, 132166, 132363, 138481, 138674, 144673, 144865, 150788, 150975, 156787, 156975, 158287,
                158475, 159506, 159787, 159975, 161287, 161475, 161662, 161944, 162225, 162506, 162787, 162964, 164199,
                164376, 165346, 165787, 166140, 167023, 167199, 167376, 167640, 167905, 168170, 168434, 181919, 182086,
                187253, 187416, 192526, 241268, 241415, 242439, 242586, 243171, 243610, 243756, 244781, 244927, 245220,
                245439, 245659, 245951, 246098, 247122, 247268, 247854, 248293, 248439, 248586, 249025, 249464, 249903, 
                250195, 250415, 250634, 288390, 344292, 344435, 348435, 348864, 349000, 351045, 351318, 351727, 352136,
                352545, 352954, 353226, 394966, 395096, 396009, 396140, 396661, 397053, 397183, 397705, 398096, 398226,
                398618, 398879, 399074, 399270
            };
            using (pool = new OsbSpritePools(GetLayer("Rings")))
            {
                pool.MaxPoolDuration = (int)AudioDuration;
                foreach (var time in times)
                {
                    BiggerRings(time);
                }
            }

            using (pool = new OsbSpritePools(GetLayer("")))
            {
                pool.MaxPoolDuration = (int)AudioDuration;

                CircleRings(46460, 48700, false);
                CircleRings(64390, 92493, false);
                CircleRings(104104, 106113, false);
                CircleRings(122567, 125266, false);
                CircleRings(173919, 181836, false);
                BeamStrike(181919, 202768);
                Diamond(202848, 222522);
                CircleRings(206953, 207821, false);
                CircleRings(231888, 250561, false);
                CircleRings(216833, 217442, false);
                CircleRings(260000, 269293, false);
                CircleRings(286195, 288317, false);
                CircleRings(295122, 297683, false);
                CircleRings(324390, 325488, false);
                CircleRings(344292, 356357, false);
                CircleRings(357400, 361509, false);
                BeamStrike(361574, 378205);
                Diamond(378270, 380292);
                CircleRings(380357, 382379, false);
                Diamond(382444, 384466);
                CircleRings(384531, 386096, false);
                Diamond(386226, 399270);
                CircleRings(386618, 394900, false);
                CircleRings(394966, 399270, true);
            }
        }
        void CircleRings(int startTime, int endTime, bool squares)
        {
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (hitobject.StartTime >= startTime && hitobject.StartTime <= endTime)
                {
                    var sprite = pool.Get(hitobject.StartTime, hitobject.EndTime + 1000, "sb/c.png", OsbOrigin.Centre, false);
                    sprite.Move(hitobject.StartTime, hitobject.Position);
                    sprite.Scale(OsbEasing.OutQuint, hitobject.StartTime, hitobject.EndTime + 1000, 0.08, 0.2);
                    sprite.Color(hitobject.StartTime, hitobject.Color);
                    sprite.Fade(OsbEasing.Out, hitobject.StartTime, hitobject.EndTime + 1000, 1, 0);

                    if (squares)
                    {
                        double angle = Random(0, 0.8);
                        var amount = Random(4, 8);
                        for (int i = 0; i < amount; i++)
                        {
                            var square = pool.Get(hitobject.StartTime, hitobject.StartTime + 500, "sb/p.png", OsbOrigin.Centre, false);
                            square.Scale(OsbEasing.OutQuad, hitobject.StartTime, hitobject.StartTime + 500, 50, 0);

                            var nPosition = new Vector2(
                                hitobject.Position.X + (float)Math.Sin(angle) * 80,
                                hitobject.Position.Y + (float)Math.Cos(angle) * 80);

                            var rotation = Math.Atan2(hitobject.Position.Y - nPosition.Y, hitobject.Position.X - nPosition.X) - Math.PI / 4;

                            square.Move(OsbEasing.OutQuad, hitobject.StartTime, hitobject.StartTime + 500, hitobject.Position, nPosition);
                            square.Rotate(hitobject.StartTime, rotation);
                            square.Color(hitobject.StartTime, hitobject.Color);

                            angle += Math.PI / amount * 2;
                        }
                    }
                }
            }
        }
        void BiggerRings(int time)
        {
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (hitobject.StartTime >= time - 1 && hitobject.StartTime <= time + 1)
                {
                    var sprite = pool.Get(hitobject.StartTime, hitobject.EndTime + 1000, "sb/c.png", OsbOrigin.Centre, false);
                    sprite.Move(hitobject.StartTime, hitobject.Position);
                    sprite.Scale(OsbEasing.OutQuad, hitobject.StartTime, hitobject.EndTime + 1000, 0.1, 0.5);
                    sprite.Color(hitobject.StartTime, new Color4(230, 230, 230, 1));
                    sprite.Fade(OsbEasing.Out, hitobject.StartTime, hitobject.EndTime + 1000, 1, 0);

                    double angle = Random(0, 0.8);
                    var amount = Random(6, 12);
                    for (int i = 0; i < amount; i++)
                    {
                        var square = pool.Get(hitobject.StartTime, hitobject.StartTime + 500, "sb/p.png", OsbOrigin.Centre, false);
                        square.Scale(OsbEasing.OutQuad, hitobject.StartTime, hitobject.StartTime + 500, 50, 0);
                        square.Color(hitobject.StartTime, new Color4(220, 220, 220, 1));

                        var nPosition = new Vector2(
                            hitobject.Position.X + (float)Math.Sin(angle) * 150,
                            hitobject.Position.Y + (float)Math.Cos(angle) * 150);

                        var rotation = Math.Atan2(hitobject.Position.Y - nPosition.Y, hitobject.Position.X - nPosition.X) - Math.PI / 4;

                        square.Move(OsbEasing.OutQuad, hitobject.StartTime, hitobject.StartTime + 500, hitobject.Position, nPosition);
                        square.Rotate(hitobject.StartTime, rotation);

                        angle += Math.PI / amount * 2;
                    }
                }
            }
        }
        void BeamStrike(int startTime, int endTime)
        {
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (hitobject.StartTime >= startTime && hitobject.StartTime <= endTime)
                {
                    int scaleY = 1000;
                    var sprite = pool.Get(hitobject.StartTime, hitobject.StartTime + 1000, "sb/p.png", OsbOrigin.Centre, false, 1);
                    sprite.Move(hitobject.StartTime, hitobject.Position);
                    sprite.Rotate(hitobject.StartTime, Random(-0.08, 0.08));
                    sprite.ScaleVec(OsbEasing.OutExpo, hitobject.StartTime, hitobject.StartTime + 1000, 1.5, scaleY, 0, scaleY);
                    sprite.Fade(hitobject.StartTime, 0.8);
                }
            }
        }
        void Diamond(int startTime, int endTime)
        {
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (hitobject.StartTime > startTime - 5 && hitobject.StartTime < endTime + 5)
                {
                    var sprite = pool.Get(hitobject.StartTime, hitobject.EndTime + 300, "sb/p.png", OsbOrigin.Centre, false);
                    sprite.Move(hitobject.StartTime, hitobject.Position);
                    sprite.Scale(OsbEasing.OutElasticHalf, hitobject.StartTime, hitobject.StartTime + 300, 110, 80);
                    sprite.Rotate(hitobject.StartTime, Math.PI / 4);
                    sprite.Fade(hitobject.StartTime, 0.8);
                    sprite.Fade(OsbEasing.InQuad, hitobject.EndTime, hitobject.EndTime + 300, 0.8, 0);
                    sprite.Color(hitobject.StartTime, hitobject.Color);

                    if (hitobject is OsuSlider)
                    {
                        var s = hitobject as OsuSlider;
                        var StartTime = hitobject.StartTime;
                        var timeStep = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration;
                        if (s.ControlPointCount > 1 && s.TravelDuration >= timeStep / 8 - 1 && s.RepeatCount == 0)
                        {
                            timeStep = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration / 16;
                        }
                        if (s.ControlPointCount > 1 && s.TravelDuration >= timeStep / 8 - 1)
                        {
                            timeStep = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration / 8;
                        }
                        else if (s.TravelDuration >= timeStep / 4 - 1)
                        {
                            timeStep = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration / 4;
                        }
                        else if (s.TravelDuration >= timeStep / 12 - 1 && s.RepeatCount != 0)
                        {
                            timeStep = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration / 12;
                        }
                        while (true && s.RepeatCount != 0 | s.ControlPointCount > 1)
                        {
                            var EndTime = StartTime + timeStep;

                            var complete = hitobject.EndTime - EndTime < 5;
                            if (complete) EndTime = hitobject.EndTime;

                            var startPosition = sprite.PositionAt(StartTime);
                            sprite.Move(StartTime, EndTime, startPosition, hitobject.PositionAtTime(EndTime));

                            if (complete) break;
                            StartTime += timeStep;
                        }
                        if (s.RepeatCount == 0 && s.ControlPointCount == 1)
                        {
                            sprite.Move(StartTime, hitobject.EndTime, hitobject.Position, hitobject.PositionAtTime(hitobject.EndTime));
                        }
                    }
                    double angle = 0;
                    var startRadius = 75;
                    var endRadius = 100;
                    var pos = hitobject.Position;

                    for (int i = 0; i < 4; i++)
                    {
                        var startPos = new Vector2(
                            (float)(pos.X + Math.Cos(angle) * startRadius),
                            (float)(pos.Y + Math.Sin(angle) * startRadius));

                        var endPos = new Vector2(
                            (float)(pos.X + Math.Cos(angle) * endRadius),
                            (float)(pos.Y + Math.Sin(angle) * endRadius));

                        double startScale = Math.Sqrt(2 * Math.Pow(startRadius, 2));
                        double endScale = Math.Sqrt(2 * Math.Pow(endRadius, 2));

                        var border = pool.Get(hitobject.StartTime, hitobject.StartTime + 500, "sb/p.png", OsbOrigin.BottomCentre, false);
                        border.Rotate(hitobject.StartTime, angle - Math.PI / 4);
                        border.ScaleVec(OsbEasing.OutQuint, hitobject.StartTime, hitobject.StartTime + 500, 1.23, startScale + 0.5, 0.6, endScale);
                        border.Move(OsbEasing.OutQuint, hitobject.StartTime, hitobject.StartTime + 500, startPos, endPos);
                        border.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + 500, 0.6, 0);
                        border.Color(hitobject.StartTime, hitobject.Color);
                        angle += Math.PI / 2;
                    }
                }
            }
        }
    }
}