using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Animations;
using System;

namespace StorybrewScripts
{
    class BG : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            Background();
            Effects();
            SmallParticles(27981, 48710);
            Flash();
            HighlightBubbles(48710, 63910, 17);
            SmallParticles(77108, 90886);
            BackgroundBlur(78886, 84028, 0.5, false);
            BackgroundBlur(85743, 89171, 2, false);
            BackgroundBlur(89171, 90886, 4, false);
            Spectrum(92600, 119366, false);

            //BPM changes here
            BackgroundBlur(92600, 99457, 0.5, true, true);
            BackgroundBlur(99457, 106217, 0.5, true, true);
            BackgroundBlur(106217, 112836, 0.5, true, true);
            BackgroundBlur(112836, 118449, 0.5, true, true);

            Spectrum(125766, 150788, false);
            BackgroundBlur(126567, 132167, 0.5, true);
            BackgroundBlur(132955, 136902, 0.5, true);
            BackgroundBlur(138481, 144577, 1, true);
            BackgroundBlur(144673, 149259, 1, true);

            SmallParticles(150788, 177919);

            BackgroundBlur(168434, 172549, 1, false);
            BackgroundBlur(173919, 176586, 1, false);
            BackgroundBlur(176753, 177919, 2, false);

            Spectrum(181919, 222522, false);
            BackgroundBlur(181919, 187169, 0.5, true, true);
            BackgroundBlur(187251, 192444, 0.5, true, true);
            BackgroundBlur(192526, 197634, 0.5, true, true);
            BackgroundBlur(197714, 201565, 0.5, true, true);
            BackgroundBlur(202848, 205374, 0.5, true, true);
            BackgroundBlur(207899, 212873, 0.5, true, true);
            BackgroundBlur(212873, 216833, 0.5, true, true);
            BackgroundBlur(217746, 221926, 0.5, true, true);

            HighlightBubbles(227205, 258829, 20);

            Spectrum(269366, 306829, true);
            BackgroundBlur(269366, 285756, 0.5, true, true);
            BackgroundBlur(278439, 278440, 1, true);
            BackgroundBlur(286927, 287366, 0.75, true);
            BackgroundBlur(287512, 287951, 0.75, true);
            BackgroundBlur(288390, 304488, 0.5, true);
            BackgroundBlur(295122, 295634, 0.75, true);
            BackgroundBlur(295708, 296220, 0.75, true);
            BackgroundBlur(296293, 297464, 0.5, true);
            BackgroundBlur(288829, 305220, 0.25, false);
            BackgroundBlur(304781, 306172, 3, true);
            BackgroundBlur(306244, 306829, 4, true);
            BackgroundBlur(307415, 324390, 0.5, true, true);
            SmallParticles(306829, 344292);
            BackgroundBlur(315244, 315464, 1, true);
            BackgroundBlur(378270, 386096, 1, false);

            Gray();
        }
        private void Background()
        {
            var s = GetLayer("1").CreateSprite("Camellia_OOParts_OWC_BGwoText.jpg");
            s.Fade(0, 0);
            var bitmap = GetMapsetBitmap("sb/b.jpg");
            var sprite = GetLayer("1").CreateSprite("sb/b.jpg");
            sprite.Scale(3980, 915f / bitmap.Width);
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

            int startRotation = -2;
            int endRotation = 2;
            var velocity = 10000;
            var rotation = MathHelper.DegreesToRadians(startRotation);
            var rotateEnd = MathHelper.DegreesToRadians(endRotation);
            var startPos = new Vector2(320, 240);
            var endPos = new Vector2(Random(310, 330), Random(230, 250));

            sprite.StartLoopGroup(92600, (119366 - 92600) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 2, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity, endPos, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotation, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotation);
            sprite.EndGroup();

            sprite.StartLoopGroup(125766, (149259 - 125766) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 2, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity, endPos, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotation, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotation);
            sprite.EndGroup();

            sprite.StartLoopGroup(181919, (221329 - 181919) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 2, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity, endPos, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotation, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotation);
            sprite.EndGroup();

            sprite.StartLoopGroup(269366, (324390 - 269366) / velocity + 1);
            sprite.Move(OsbEasing.InOutSine, 0, velocity / 2, startPos, endPos);
            sprite.Move(OsbEasing.InOutSine, velocity / 2, velocity, endPos, startPos);
            sprite.Rotate(OsbEasing.InOutSine, 0, velocity / 2, rotation, rotateEnd);
            sprite.Rotate(OsbEasing.InOutSine, velocity / 2, velocity, rotateEnd, rotation);
            sprite.EndGroup();
        }
        private void Effects()
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
            back.Fade(264683, 268195, 1, 0);
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
        private void HighlightBubbles(int startTime, int endTime, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var fade = Random(0.05, 0.3);
                var sprite = GetLayer("Highlights").CreateSprite("sb/hl.png", OsbOrigin.Centre, new Vector2(0, Random(240, 480)));
                sprite.Fade(startTime + i * 700, startTime + i * 700 + 3000, 0, fade);
                sprite.MoveX(startTime + i * 700, endTime + i * 1000, Random(-157, 460), Random(707, 747));
                sprite.Scale(startTime + i * 1000, Random(0.1, 0.5));
                sprite.Fade(endTime, endTime + 1000, fade, 0);
            }
            for (int i = 0; i < amount; i++)
            {
                var fade = Random(0.1, 0.5);
                var sprite = GetLayer("Highlights").CreateSprite("sb/hl.png", OsbOrigin.Centre, new Vector2(0, Random(240, 480)));
                sprite.Fade(startTime + i * 700, startTime + i * 700 + 3000, 0, fade);
                sprite.MoveX(startTime + i * 700, endTime + i * 1000, Random(-157, 450), Random(707, 757));
                sprite.Scale(startTime + i * 1000, Random(0.01, 0.05));
                sprite.Fade(endTime, endTime + 1000, fade, 0);
            }
        }
        private void Gray()
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
        private void Flash()
        {
            var sprite = GetLayer("2").CreateSprite("sb/p.png");
            sprite.Additive(48710);
            sprite.ScaleVec(48710, 854, 480);
            sprite.Fade(48710, 52710, 1, 0);

            sprite.Fade(92600, 94314, 0.8, 0);

            sprite.Fade(106217, 107872, 0.8, 0);

            sprite.Fade(132166, 133744, 0.6, 0);
            sprite.Fade(136902, 138481, 0, 0.4);
            sprite.Fade(138481, 140029, 0.6, 0);
            sprite.Fade(144674, 146202, 0.6, 0);
            sprite.Fade(173919, 175253, 0.6, 0);

            var tStep = Beatmap.GetTimingPointAt(179753).BeatDuration / 4;

            sprite.StartLoopGroup(179753, (180586 - 179753) / (int)tStep);
            sprite.Fade(0, tStep, 0.1, 0);
            sprite.EndGroup();

            sprite.StartLoopGroup(180586, (181836 - 180586) / (int)tStep);
            sprite.Fade(0, tStep, 0.2, 0);
            sprite.EndGroup();

            sprite.Fade(181919, 183253, 0.8, 0);
            sprite.Fade(192526, 193823, 0.8, 0);
            sprite.Fade(202848, 204111, 0.8, 0);

            sprite.Fade(205690, 206005, 0.2, 0);
            sprite.Fade(206005, 206321, 0.2, 0);
            sprite.Fade(206637, 206953, 0.2, 0);
            sprite.Fade(207899, 209143, 0.8, 0);
            sprite.Fade(212873, 214092, 0.8, 0);
            sprite.Fade(217746, 218941, 0.8, 0);
            sprite.Fade(222522, 227205, 1, 0);
            sprite.Fade(269366, 270537, 1, 0);

            sprite.Fade(278732, 279903, 0.8, 0);
            sprite.Fade(288390, 290439, 0.8, 0);
            sprite.Fade(292781, 293951, 0.8, 0);
            sprite.Fade(297756, 299805, 0.8, 0);
            sprite.Fade(302147, 303317, 0.8, 0);
            sprite.Fade(305659, 306829, 0, 1);
            sprite.Fade(306829, 309171, 1, 0);

            sprite.Fade(320878, 324390, 0, 1);
            sprite.Fade(324390, 324976, 1, 0);
            sprite.Fade(325561, 326732, 1, 0);

            sprite.Fade(336098, 337269, 0.5, 0);
            sprite.Fade(344292, 346578, 1, 0);

            sprite.Fade(378270, 379313, 1, 0);
            sprite.Fade(382444, 383487, 0.8, 0);
            sprite.Fade(386618, 387661, 0.8, 0);

            sprite.Fade(391313, 394966, 0, 0.5);
            sprite.Fade(394966, 395487, 0.6, 0);
            sprite.Fade(399270, 402270, 0.6, 0);
        }
        private void BackgroundBlur(int startTime, int endTime, double BeatDivisor, bool Grad, bool split = false)
        {
            var bitmap = GetMapsetBitmap("sb/b.jpg");
            
            var timeStep = Beatmap.GetTimingPointAt(startTime).BeatDuration / BeatDivisor;
            for (double i = startTime; i <= endTime; i += timeStep)
            {
                var pos = Grad ? new Vector2(Random(310, 330), Random(230, 250)) : new Vector2(320, 240);
                var sprite = GetLayer("1Blur").CreateSprite("sb/b.jpg", OsbOrigin.Centre, pos);
                sprite.Additive(i);
                sprite.Scale(i, i + 750, 915f / bitmap.Width, 915f / bitmap.Width + 0.01);
                sprite.Fade(i, i + 750, 0.4, 0);

                sprite.ColorHsb(i, Random(180, 340), Random(0.25, 0.75), 0.8);

                if (Grad)
                {
                    sprite.Rotate(i, Random(-0.0314, 0.0314));
                    if (BeatDivisor <= 2)
                    {
                        var gMap = GetMapsetBitmap("sb/g.png");
                        var grad = GetLayer("GradientFlashes").CreateSprite("sb/g.png");
                        var start = split ? i + timeStep / 2 : i;
                        var end = split ? i + timeStep / 2 + 750 : i + 750;
                        grad.Scale(start, end, 854f / gMap.Width, 854f / gMap.Width + 0.02);
                        grad.Fade(start, end, 0.5, 0);
                    }
                }
            }
        }
        private void Buildup1()
        {
            var basicHL = GetLayer("a Highlight").CreateSprite("sb/hl.png");
            basicHL.Color(75330, new Color4(0, 0, 0, 1));
            basicHL.Fade(OsbEasing.Out, 75330, 75552, 0, 0.7);
            basicHL.Fade(OsbEasing.In, 75552, 75775, 0.7, 0);
        }
        private void SmallParticles(int startTime, int endTime)
        {
            for (int i = 0; i < 80; i++)
            {
                var delay = Random(1, 5000);
                var sprite = GetLayer("Particles").CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(0, Random(0, 480)));
                sprite.Fade(startTime + delay, startTime + delay + 1000, 0, 1);
                sprite.Fade(endTime, endTime + 1000, 1, 0);
                sprite.Scale(startTime + delay, Random(0.5, 1));
                sprite.Rotate(startTime + delay, Random(0, 1.0));

                var elementStartTime = startTime + delay;
                var duration = Random(7000, 20000);
                while (elementStartTime < endTime)
                {
                    var elementEndTime = elementStartTime + duration;
                    sprite.MoveX(elementStartTime, elementEndTime, -107, 750);

                    elementStartTime += duration;
                }
            }
        }
        private void Spectrum(int StartTime, int EndTime, bool DisplayBottom)
        {
            var MinimalHeight = 0.1f;
            var ScaleY = 70;
            float LogScale = 7;
            var Position = new Vector2(-103, 240);

            int BarCount = 100;
            var Width = 854f;

            var heightKeyframes = new KeyframedValue<float>[BarCount];
            for (var i = 0; i < BarCount; i++)
                heightKeyframes[i] = new KeyframedValue<float>(null);

            double timeStep = Beatmap.GetTimingPointAt(StartTime).BeatDuration / 8;
            double offset = timeStep * 0.2;
            for (var t = (double)StartTime; t < EndTime; t += timeStep)
            {
                var fft = GetFft(t + offset, BarCount, null, OsbEasing.InExpo);
                for (var i = 0; i < BarCount; i++)
                {
                    var height = (float)Math.Log10(1 + fft[i] * LogScale) * ScaleY;
                    if (height < MinimalHeight) height = MinimalHeight;

                    heightKeyframes[i].Add(t, height);
                }
            }
            var barWidth = Width / BarCount;
            for (var i = 0; i < BarCount; i++)
            {
                var keyframes = heightKeyframes[i];
                keyframes.Simplify1dKeyframes(1, h => h);

                var topBar = GetLayer("Spectrum").CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Position.X + i * barWidth, Position.Y));
                var bottomBar = GetLayer("Spectrum").CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Position.X + i * barWidth, Position.Y));

                topBar.Scale(StartTime, barWidth / 3);
                topBar.Fade(StartTime, StartTime + 1500, 0, 1);
                topBar.Fade(EndTime - 1000, EndTime, 1, 0);
                if (DisplayBottom)
                {
                    bottomBar.Scale(StartTime, barWidth / 3);
                    bottomBar.Color(StartTime, Color4.Black);
                    bottomBar.Fade(StartTime, StartTime + 1500, 0, 1);
                    bottomBar.Fade(EndTime - 1000, EndTime, 1, 0);
                    LogScale = 5;
                }
                keyframes.ForEachPair(
                    (start, end) =>
                    {
                        topBar.MoveY(start.Time, end.Time, 
                        Position.Y - start.Value / 2 * LogScale, Position.Y - end.Value / 2 * LogScale);

                        if (DisplayBottom)
                        {
                            bottomBar.MoveY(start.Time, end.Time, 
                            Position.Y + start.Value / 2 * LogScale, Position.Y + end.Value / 2 * LogScale);
                        }
                    },
                    MinimalHeight,
                    s => (int)s
                );
            }
        }
    }
}
