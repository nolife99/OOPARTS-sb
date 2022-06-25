using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using System;

namespace StorybrewScripts
{
    class Transitions : StoryboardObjectGenerator
    {
        OsbSpritePools pool;
        public override void Generate()
        {
            using (pool = new OsbSpritePools(GetLayer("Transition")))
            {
                pool.MaxPoolDuration = (int)AudioDuration;

                TransitionLines(78886, 79743, 79743, true, false);
                SquareTransition(150406, 150788, 55f, new Color4(240, 240, 240, 1), OsbEasing.None, false);
                DoubleTransition(63430, 63910, 64390);
                DoubleTransition(118959, 119366, 119366);
                DoubleTransition2(64390, 64852);
                DoubleTransition2(260000, 260293);
            }
            
            var sprite = GetLayer("").CreateSprite("sb/p.png");
            sprite.ScaleVec(109527, 854, 480);
            sprite.Fade(109527, 119366, 0, 0.5);
            sprite.Additive(109527, 250634);
            sprite.Fade(119366, 0);

            sprite.Fade(144673, 149259, 0, 0.5);
            sprite.Fade(149259, 150787, 0.5, 0);

            sprite.Fade(173919, 177919, 0, 0.5);
            sprite.Fade(177919, 179253, 0.5, 0);

            sprite.Fade(195120, 202848, 0, 0.5);
            sprite.Fade(202848, 0);

            sprite.Fade(250634, 258829, 0, 1);
            sprite.Color(250634, 260000, new Color4(255, 255, 255, 1), new Color4(240, 240, 240, 1));
            sprite.Fade(260000, 0);

            sprite.Fade(305659, 306829, 0, 0.25);
            sprite.Fade(306829, 307122, 0.25, 0);
        }
        void TransitionLines(int startTransition, int endTransition, int endTime, bool Out, bool FadeOut)
        {
            int transitionDuration = endTransition - startTransition;
            var posX = -124f;
            int scaleY = 484;

            for (int i = 0; i < 52; i++)
            {
                var sprite = pool.Get(startTransition, endTime + 1000, "sb/p.png", OsbOrigin.Centre, false);
                if (Out)
                {
                    sprite.ScaleVec(OsbEasing.OutQuad, startTransition, startTransition + 300, 17.415f, scaleY, 0, scaleY);
                }
                else
                {
                    sprite.ScaleVec(startTransition, startTransition + 300, 0, scaleY, 17.415f, scaleY);
                    if (FadeOut) sprite.Fade(endTime, endTime + 1000, 1, 0);
                    else sprite.Fade(startTransition, 1); sprite.Fade(endTime, 0);
                }
                sprite.Rotate(startTransition, 0.1);
                sprite.Move(startTransition, posX, 240);

                posX += 17.5f;
            }
        }
        void DoubleTransition(int startTime, int endTime, int fadeTime)
        {
            var sprite1 = pool.Get(startTime, fadeTime, "sb/p.png", OsbOrigin.TopCentre, false);
            sprite1.Move(startTime, 106.5f, 0);
            sprite1.ScaleVec(OsbEasing.OutQuad, startTime, endTime, 427, 0, 427, 480);
            sprite1.Fade(startTime, 1);
            sprite1.Fade(fadeTime, 0);
            sprite1.Color(startTime, new Color4(240, 240, 240, 1));

            var sprite2 = pool.Get(startTime, fadeTime, "sb/p.png", OsbOrigin.BottomCentre, false);
            sprite2.Move(startTime, 533.5f, 480);
            sprite2.ScaleVec(OsbEasing.OutQuad, startTime, endTime, 427, 0, 427, 480);
            sprite2.Fade(startTime, 1);
            sprite2.Fade(fadeTime, 0);
            sprite2.Color(startTime, new Color4(240, 240, 240, 1));
        }
        void DoubleTransition2(int startTime, int endTime)
        {
            var sprite1 = pool.Get(startTime, endTime, "sb/p.png", OsbOrigin.CentreLeft, false);
            sprite1.Move(startTime, -107, 120);
            sprite1.ScaleVec(OsbEasing.OutQuad, startTime, endTime, 854, 240, 0, 240);
            sprite1.Color(startTime, new Color4(240, 240, 240, 1));

            var sprite2 = pool.Get(startTime, endTime, "sb/p.png", OsbOrigin.CentreRight, false);
            sprite2.Move(startTime, 747, 360);
            sprite2.ScaleVec(OsbEasing.OutQuad, startTime, endTime, -854, 240, 0, 240);
            sprite2.Color(startTime, new Color4(240, 240, 240, 1));
        }
        public void SquareTransition(int startTime, int endTime, float squareScale, Color4 color, OsbEasing easing, bool Out)
        {
            float posX = -90;
            float posY = 20;

            while (posX < 727 + squareScale)
            {
                while (posY < 440 + squareScale)
                {
                    var sprite = pool.Get(startTime, endTime, "sb/p.png", OsbOrigin.Centre, false);

                    if (Out)
                    {
                        sprite.ScaleVec(OsbEasing.InSine, startTime, endTime, squareScale, squareScale, 0, 0);
                        sprite.Rotate(OsbEasing.InSine, startTime, endTime, -Math.PI, 0);
                    }
                    else
                    {
                        sprite.ScaleVec(easing, startTime, endTime, 0, 0, squareScale, squareScale);
                        sprite.Rotate(easing, startTime, endTime, Math.PI, 0);
                    }
                    sprite.Color(startTime, color);
                    sprite.Move(startTime, new Vector2(posX, posY));

                    posY += squareScale;
                }
                posY = 20;
                posX += squareScale;
            }
        }
    }
}
