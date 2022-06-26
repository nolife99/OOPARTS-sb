using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using System;

namespace StorybrewScripts
{
    class BackgroundEffect : StoryboardObjectGenerator
    {
        OsbSpritePools pools;
        public override void Generate()
        {
		    Flash();
            
            using (pools = new OsbSpritePools(GetLayer("1Blur")))
            {
                pools.MaxPoolDuration = (int)AudioDuration;

                BackgroundBlur(78886, 84028, 0.5, false);
                BackgroundBlur(85743, 89171, 2, false);
                BackgroundBlur(89171, 90886, 4, false);

                BackgroundBlur(92600, 99457, 0.5, true, true);
                BackgroundBlur(99457, 106217, 0.5, true, true);
                BackgroundBlur(106217, 112836, 0.5, true, true);
                BackgroundBlur(112836, 118449, 0.5, true, true);

                BackgroundBlur(126567, 132167, 0.5, true);
                BackgroundBlur(132955, 136902, 0.5, true);
                BackgroundBlur(138481, 144577, 1, true);
                BackgroundBlur(144673, 149259, 1, true);

                BackgroundBlur(168434, 172549, 1, false);
                BackgroundBlur(173919, 176586, 1, false);
                BackgroundBlur(176753, 177919, 2, false);

                BackgroundBlur(181919, 187169, 0.5, true, true);
                BackgroundBlur(187251, 192444, 0.5, true, true);
                BackgroundBlur(192526, 197634, 0.5, true, true);
                BackgroundBlur(197714, 201565, 0.5, true, true);
                BackgroundBlur(202848, 205374, 0.5, true, true);
                BackgroundBlur(207899, 212873, 0.5, true, true);
                BackgroundBlur(212873, 216833, 0.5, true, true);
                BackgroundBlur(217746, 221926, 0.5, true, true);

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
                BackgroundBlur(315244, 315464, 1, true);
                BackgroundBlur(378270, 386096, 1, false);
            }
        }
        void Flash()
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
        void BackgroundBlur(int startTime, int endTime, double BeatDivisor, bool Grad, bool split = false)
        {
            var bitmap = GetMapsetBitmap("sb/b.jpg");
            
            var timeStep = Beatmap.GetTimingPointAt(startTime).BeatDuration / BeatDivisor;
            for (double i = startTime; i <= endTime; i += timeStep)
            {
                var sprite = pools.Get(i, i + 750, "sb/b.jpg", OsbOrigin.Centre, true);
                sprite.Scale(i, i + 750, 935f / bitmap.Width, 935f / bitmap.Width + Random(0, 0.01));
                sprite.Fade(i, i + 750, 0.4, 0);

                if (Grad)
                {
                    sprite.Move(i, new Vector2(Random(315, 325), Random(235, 245)));
                    sprite.Rotate(i, Random(-0.0314, 0.0314));

                    if (BeatDivisor <= 2)
                    {
                        var gMap = GetMapsetBitmap("sb/g.png");
                        var start = split ? i + timeStep / 2 : i;
                        var end = split ? i + timeStep / 2 + 750 : i + 750;
                        var grad = pools.Get(start, end, "sb/g.png", OsbOrigin.Centre, true);
                        grad.Scale(start, end, 854f / gMap.Width, 854f / gMap.Width + 0.02);
                        grad.Fade(start, end, 0.5, 0);
                    }
                }
                else
                {
                    sprite.Move(i, 320, 240);
                }

                sprite.ColorHsb(i, Random(180, 340), Random(0.25, 0.75), 0.8);
            }
        }
    }
}
