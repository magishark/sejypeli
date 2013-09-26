using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Koppi : PhysicsGame
{
    IntMeter pistelaskuri;
    IntMeter Elamalaskuri = new IntMeter(3, 0, 5);
    int evel = 1000000;
        int omenoitailmassa = 1000000;
    void PeliLoppui()
    { 
    
    }

    void LuoElamalaskuri()
    {
        Label elamanaytto = new Label();
        elamanaytto.X = Screen.Right - 50;
        elamanaytto.Y = Screen.Top - 50;
        elamanaytto.BindTo(Elamalaskuri);
        Elamalaskuri.LowerLimit += PeliLoppui;
        Add(elamanaytto);
    }
    
    void LuoPistelaskuri()
    {
        pistelaskuri = new IntMeter(0);
        Label Pistenaytto = new Label();
        Pistenaytto.X = Screen.Left + 50;
        Pistenaytto.Y = Screen.Top - 50;
        Pistenaytto.BindTo(pistelaskuri);
        Add(Pistenaytto);
    }

    public override void Begin()
    {
        LuoPistelaskuri();
        LuoElamalaskuri();

        // Luo reunat
        Level.CreateLeftBorder();
        Level.CreateRightBorder();
        PhysicsObject pohja =
            Level.CreateBottomBorder();
        AddCollisionHandler(pohja, Putosimaahan);

        PhysicsObject omppu = new PhysicsObject(50, 50);
        omppu.Shape = Shape.Circle;
        omppu.Color = Color.Red;
        omppu.Y = Screen.Top;
        GameObject lehti = new GameObject(20, 20);
        lehti.Shape = Shape.Star;
        lehti.Color = Color.Green;
        Add(omppu);
        lehti.Y = 30;
        omppu.Add(lehti);
        Mouse.ListenOn(omppu, MouseButton.Left, ButtonState.Pressed, omppunapattu, "omppua klikattu", omppu);


        omppu.Hit(RandomGen.NextVector(0, 100.0));

        Gravity = new Vector(0.0, -100);

        IsMouseVisible = true;

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    void Putosimaahan(PhysicsObject maa, PhysicsObject omppu)
    {
        if (omppu.Color != Color.Black)
        {
           Elamalaskuri.AddValue(-1);
        }
        omppu.Color = Color.Black;
    }

    void omppunapattu(PhysicsObject KlikattuOmppu)
    {
        KlikattuOmppu.Destroy();
        pistelaskuri.AddValue(1);
    }
}
