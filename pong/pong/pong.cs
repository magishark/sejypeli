using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class pong : PhysicsGame
{
    PhysicsObject Ball;

    public override void Begin()
    {
        LuoKentta();
        AsetaOhjaimet();
        AloitaPeli();

        void AsetaOhjaimet()
        {
            Keyboard.Listen(Key.A, ButtonState.Down; LiikutaMaila1Ylös, "pelaaja 1: Liikuta mailaa ylös");
            Keyboard.Listen(Key.A; ButtonState.Released; PysautaMaila1, null);

        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void LuoKentta()
    {
         Ball = new PhysicsObject(50, 50);
        Ball.Restitution = 1.0;
        Ball.Shape = Shape.Circle;
        Ball.X = -200.0;
        Ball.Y = 0.0;
        Add(Ball);
        
        LuoMaila(Level.Left + 20.0, 0.0);
        LuoMaila(Level.Right - 20.0, 0.0);

       

        Level.CreateBorders(1.0, false);
        Level.BackgroundColor = Color.YellowGreen;

        Camera.ZoomToLevel();
    }

    void AloitaPeli()
    {
        Vector impulssi = new Vector(500.0, 0.0);
        Ball.Hit(impulssi);
    }
    void LuoMaila(double x, double y)
    {
        PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0);
        maila.Shape = Shape.Rectangle;
        maila.X = x;
        maila.Y = y;
        maila.Restitution = 1.0;
        Add(maila);
    }
}
