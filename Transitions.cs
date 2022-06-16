using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;

namespace StorybrewScripts
{
    class Transitions : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            TransitionLines(78886, 79743, 79743, "Transition", true, false);
            DoubleTransition(63430, 63910, 64390);
            DoubleTransition2(64390, 64852);
            DoubleTransition(118959, 119366, 119366);
            var sprite = GetLayer("").CreateSprite("sb/p.png");
            sprite.ScaleVec(109527, 854, 480);
            sprite.Fade(109527, 119366, 0, 0.5);
            sprite.Additive(109527);
            sprite.Fade(119366, 0);

            sprite.Fade(144673, 149259, 0, 0.5);
            sprite.Fade(149259, 150787, 0.5, 0);

            sprite.Fade(173919, 177919, 0, 0.5);
            sprite.Fade(177919, 179253, 0.5, 0);

            sprite.Fade(195120, 202848, 0, 0.5);
            sprite.Fade(202848, 0);

            sprite.Fade(250634, 258829, 0, 1);
            sprite.Color(259708, 260000, new Color4(255, 255, 255, 1), new Color4(240, 240, 240, 1));
            sprite.Fade(260000, 0);

            sprite.Fade(305659, 306829, 0, 0.25);
            sprite.Fade(306829, 307122, 0.25, 0);

            DoubleTransition2(260000, 260293);

            SquareTransition(150406, 150788, 55f, new Color4(240, 240, 240, 1), OsbEasing.None, false);
        }
        private void TransitionLines(int startTransition, int endTransition, int endTime, string layer, bool Out, bool FadeOut)
        {
            int transitionDuration = endTransition - startTransition;
            int delay = 0;
            var posX = -124f;
            int scaleY = 484;

            for (int i = 0; i < 52; i++)
            {
                var sprite = GetLayer(layer).CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(posX, 240));
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
                sprite.Rotate(startTransition + delay, 0.1);

                delay += transitionDuration / 60;
                posX += 17.5f;
            }
        }
        private void DoubleTransition(int startTime, int endTime, int fadeTime)
        {
            var sprite1 = GetLayer("Transition").CreateSprite("sb/p.png", OsbOrigin.TopCentre, new Vector2(106.5f, 0));
            sprite1.ScaleVec(OsbEasing.OutQuad, startTime, endTime, 427, 0, 427, 480);
            sprite1.Fade(startTime, fadeTime, 1, 1);
            sprite1.Color(startTime, new Color4(240, 240, 240, 1));

            var sprite2 = GetLayer("Transition").CreateSprite("sb/p.png", OsbOrigin.BottomCentre, new Vector2(533.5f, 480));
            sprite2.ScaleVec(OsbEasing.OutQuad, startTime, endTime, 427, 0, 427, 480);
            sprite2.Fade(startTime, fadeTime, 1, 1);
            sprite2.Color(startTime, new Color4(240, 240, 240, 1));
        }
        private void DoubleTransition2(int startTime, int endTime)
        {
            var sprite1 = GetLayer("Transition").CreateSprite("sb/p.png", OsbOrigin.CentreLeft, new Vector2(-107, 120));
            sprite1.ScaleVec(OsbEasing.OutQuad, startTime, endTime, 854, 240, 0, 240);
            sprite1.Color(startTime, new Color4(240, 240, 240, 1));

            var sprite2 = GetLayer("Transition").CreateSprite("sb/p.png", OsbOrigin.CentreRight, new Vector2(747, 360));
            sprite2.ScaleVec(OsbEasing.OutQuad, startTime, endTime, -854, 240, 0, 240);
            sprite2.Color(startTime, new Color4(240, 240, 240, 1));
        }
        public void SquareTransition(int startTime, int endTime, float squareScale, Color4 color, OsbEasing easing, bool Out, string layer = "Transition")
        {
            float posX = -90;
            float posY = 20;

            while (posX < 727 + squareScale)
            {
                while (posY < 440 + squareScale)
                {
                    var sprite = GetLayer(layer).CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(posX, posY));

                    if (Out)
                    {
                        sprite.Scale(OsbEasing.InSine, startTime, endTime, squareScale, 0);
                        sprite.Rotate(OsbEasing.InSine, startTime, endTime, -Math.PI, 0);
                    }
                    else
                    {
                        sprite.Scale(easing, startTime, endTime, 0, squareScale);
                        sprite.Rotate(easing, startTime, endTime, Math.PI, 0);
                    }
                    sprite.Color(startTime, color);
                    posY += squareScale;
                }
                posY = 20;
                posX += squareScale;
            }
        }
    }
}
