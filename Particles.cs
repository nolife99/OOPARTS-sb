using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using System;

namespace StorybrewScripts
{
    class Particles : StoryboardObjectGenerator
    {
        OsbSpritePool pool;
        public override void Generate()
        {
            using (pool = new OsbSpritePool(GetLayer("Highlights"), "sb/hl.png", OsbOrigin.Centre, false))
            {
                pool.MaxPoolDuration = (int)AudioDuration;
                
                HighlightBubbles(48710, 63910);
                HighlightBubbles(227205, 258829);
            }
            
            using (pool = new OsbSpritePool(GetLayer("Particles"), "sb/p.png", OsbOrigin.Centre, false))
            {
                pool.MaxPoolDuration = (int)AudioDuration;

                SmallParticles(27981, 48710);
                SmallParticles(77108, 90886);
                SmallParticles(150788, 177919);
                SmallParticles(306829, 344292);
            }
        }
        void HighlightBubbles(int startTime, int endTime)
        {
            for (int i = startTime; i < endTime; i += 500)
            {
                var fade = Random(0.05, 0.3);
                var duration = Random(10000, 30000);
                var scale = Random(0, 10) < 5 ? Random(0.1, 0.5) : Random(0.01, 0.05);
                var sprite = pool.Get(i, i + duration);
                sprite.Fade(i, i + 3000, 0, fade);
                sprite.Move(i, i + duration, Random(-157, 460), Random(240, 480), 747, Random(240, 480));
                sprite.Scale(i, scale);
                sprite.Fade(i + duration - 1000, i + duration, fade, 0);
            }
        }
        void SmallParticles(int startTime, int endTime)
        {
            for (int i = startTime; i < endTime; i += 300)
            {
                var duration = Random(7000, 20000);
                int posY = Random(0, 480);

                var sprite = pool.Get(i, i + duration + 1000);
                sprite.Fade(i, i + 1000, 0, 1);
                sprite.Fade(i + duration, i + duration + 1000, 1, 0);
                sprite.Scale(i, Random(0.5, 1));
                sprite.Rotate(i, Random(0, 1.0));

                sprite.Move(i, i + duration, -107, posY, 750, posY);
            }
        }
    }
}
