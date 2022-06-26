using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Animations;
using System;

namespace StorybrewScripts
{
    class SpectrumDots : StoryboardObjectGenerator
    {
        OsbSpritePool pool;
        public override void Generate()
        {
		    using (pool = new OsbSpritePool(GetLayer("Spectrum"), "sb/p.png", OsbOrigin.Centre, false))
            {
                pool.MaxPoolDuration = (int)AudioDuration;

                Spectrum(92600, 119367, false);
                Spectrum(125766, 150788, false);
                Spectrum(125766, 150788, false);
                Spectrum(181919, 222522, false);
                Spectrum(269366, 306829, true);
            }
        }
        void Spectrum(int StartTime, int EndTime, bool DisplayBottom)
        {
            var MinimalHeight = 0.25f;
            var ScaleY = 70;
            float LogScale = 7;
            var Position = new Vector2(-103, 257);
            var Width = 854f;

            int BarCount = 100;
            int fftCount = BarCount + 10;

            var heightKeyframes = new KeyframedValue<float>[fftCount];
            for (var i = 0; i < fftCount; i++)
                heightKeyframes[i] = new KeyframedValue<float>(null);

            var timeStep = 40;
            var offset = timeStep * 0.2;
            
            for (var t = (double)StartTime; t <= EndTime; t += timeStep)
            {
                var fft = GetFft(t + offset, fftCount, null, OsbEasing.InExpo);
                for (var i = 0; i < fftCount; i++)
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

                var topBar = pool.Get(StartTime, EndTime);
                var bottomBar = pool.Get(StartTime, EndTime);

                topBar.MoveX(StartTime, Position.X + i * barWidth);
                topBar.Scale(StartTime, barWidth / 3);
                topBar.Fade(StartTime, 1);
                topBar.Fade(EndTime - 1000, EndTime, 1, 0);

                if (DisplayBottom)
                {
                    bottomBar.MoveX(StartTime, Position.X + i * barWidth);
                    bottomBar.Scale(StartTime, barWidth / 3);
                    bottomBar.Color(StartTime, Color4.Black);
                    bottomBar.Fade(StartTime, 1);
                    bottomBar.Fade(EndTime - 1000, EndTime, 1, 0);

                    Position.Y = 240;
                    LogScale = 5.5f;
                }

                keyframes.ForEachPair(
                    (start, end) =>
                    {
                        topBar.MoveY(start.Time, end.Time, 
                        (int)(Position.Y - start.Value / 2 * LogScale), (int)(Position.Y - end.Value / 2 * LogScale));

                        if (DisplayBottom)
                        {
                            bottomBar.MoveY(start.Time, end.Time, 
                            (int)(Position.Y + start.Value / 2 * LogScale), (int)(Position.Y + end.Value / 2 * LogScale));
                        }
                    },
                    MinimalHeight,
                    s => s
                );
            }
        }
    }
}
