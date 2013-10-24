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
    IntMeter Elamalaskuri;
    IntMeter tasoLaskuri;
    int omenoitaIlmassa;

    void LuoNaytto(IntMeter laskuri, double x, double y)
    {
        Label naytto = new Label();
        naytto.X = x;
        naytto.Y = y;
        naytto.BindTo(laskuri);

        Add(naytto);
    }

    public override void Begin()
    {
        pistelaskuri = new IntMeter(0);
        LuoNaytto(pistelaskuri, Screen.Left + 50, Screen.Top - 50);
        Elamalaskuri = new IntMeter(100, 0, 100);
        LuoNaytto(Elamalaskuri, Screen.Right - 50, Screen.Top - 50);
        tasoLaskuri = new IntMeter(1, 1, 10);
        LuoNaytto(tasoLaskuri, Screen.Left + 50, Screen.Top - 100);

        PudotaOmenoita(tasoLaskuri.Value);

        // Luo reunat
        Level.CreateLeftBorder();
        Level.CreateRightBorder();
        PhysicsObject pohja =
            Level.CreateBottomBorder();
        AddCollisionHandler(pohja, Putosimaahan);
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
        omppu.Destroy();

        omenoitaIlmassa = omenoitaIlmassa - 1;
        TarkistaOnkoKaikkiKiinni();
    }

    void omppunapattu(PhysicsObject KlikattuOmppu)
    {
        if (KlikattuOmppu.Color == Color.Red)
        {
            KlikattuOmppu.Destroy();
            pistelaskuri.AddValue(1);
        }

        omenoitaIlmassa = omenoitaIlmassa - 1;
        TarkistaOnkoKaikkiKiinni();
    }

    void TarkistaOnkoKaikkiKiinni()
    {
        if (omenoitaIlmassa == 0)
        {
            tasoLaskuri.AddValue(1000);
            PudotaOmenoita(tasoLaskuri.Value);
        }
    }

    void PudotaOmenoita(int lukumaara)
    {
        for (int i = 0; i < lukumaara; i++)
        {
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
            omppu.Hit(RandomGen.NextVector(0, 100.0));
            Mouse.ListenOn(omppu, MouseButton.Left, ButtonState.Pressed, omppunapattu, "omppua klikattu", omppu);
        }
        omenoitaIlmassa = lukumaara;

    }
}
