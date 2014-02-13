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

        kasi1.X = 30;
        kasi1.Y = -40;
        kasi2.X = -30;
        kasi2.Y = -40;

        PhysicsObject Leggy1 = new PhysicsObject(10, 40);
        Add(Leggy1);

        PhysicsObject Leggy2 = new PhysicsObject(10, 40);
        Add(Leggy2);

        Leggy1.X = 10;
        Leggy1.Y = -90;
        Leggy2.X = -10;
        Leggy2.Y = -90;

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
}
