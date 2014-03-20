using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Rope_Swing : PhysicsGame
{
    public override void Begin()
    {
        PhysicsObject paa = new PhysicsObject(20, 20);
        Add(paa);

        PhysicsObject Keho = new PhysicsObject(20, 40);
        Add(Keho);

        Keho.X = 0;
        Keho.Y = -40;

        PhysicsObject kasi1 = new PhysicsObject(10, 40);
        Add(kasi1);

        PhysicsObject kasi2 = new PhysicsObject(10, 40);
        Add(kasi2);

        kasi1.X = 20;
        kasi1.Angle = Angle.FromDegrees(30);
        kasi1.Y = -40;
        kasi2.X = -20;
        kasi2.Angle = Angle.FromDegrees(-30);
        kasi2.Y = -40;

        PhysicsObject Leggy1 = new PhysicsObject(10, 40);
        Add(Leggy1);

        PhysicsObject Leggy2 = new PhysicsObject(10, 40);
        Add(Leggy2);

        Leggy1.X = 10;
        Leggy1.Y = -90;
        Leggy2.X = -10;
        Leggy2.Y = -90;

        lisaaliitos(paa, Keho, new Vector(0, 0));
        lisaaliitos(kasi1, Keho, new Vector(10, -10));
        lisaaliitos(kasi2, Keho, new Vector(-10, -10));
        lisaaliitos(Leggy1, Keho, new Vector(10, -60));
        lisaaliitos(Leggy2, Keho, new Vector(10, -60));

        Gravity = new Vector(0, -500);

        Surface maasto = Surface.CreateBottom(Level, 30, 50, 60, 10);
        Add(maasto);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void lisaaliitos(PhysicsObject olio1, PhysicsObject olio2, Vector akselinpaikka)
    {
        AxleJoint liitos = new AxleJoint(olio1, olio2, akselinpaikka);
        olio1.CollisionIgnoreGroup = 1;
        olio2.CollisionIgnoreGroup = 1;
        Add(liitos);

        olio1.Mass = 0.5;
    }
}
