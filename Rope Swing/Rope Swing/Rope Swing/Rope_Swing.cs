using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Rope_Swing : PhysicsGame
{
    PhysicsObject paa;
    PhysicsObject Keho;
    PhysicsObject kasi1;
    PhysicsObject kasi2;
    IntMeter pisteLaskuri;
    PhysicsObject vasen;
    PhysicsObject oikea;
    PhysicsObject yla;
    PhysicsObject ala;
    public override void Begin()
    {
        Image taustaKuva = LoadImage("Kentta1");
        Level.Background.Image = taustaKuva;
        Level.Background.FitToLevel();
        Camera.ZoomToLevel();
       ala = Level.CreateBottomBorder();
       oikea =  Level.CreateRightBorder();
       vasen =  Level.CreateLeftBorder();
       yla = Level.CreateTopBorder();

        paa = new PhysicsObject(20, 20);
        paa.Image = LoadImage("poop1");
        Add(paa);

        Keho = new PhysicsObject(20, 40);
        Keho.Image = LoadImage("poop2");
        Add(Keho);

        Keho.X = 0;
        Keho.Y = -40;

         kasi1 = new PhysicsObject(10, 40);
        kasi1.Image = LoadImage("poop3");
        Add(kasi1);

         kasi2 = new PhysicsObject(10, 40);
        kasi2.Image = LoadImage("poop3");
        Add(kasi2);

        kasi1.X = 20;
        kasi1.Angle = Angle.FromDegrees(30);
        kasi1.Y = -40;
        kasi2.X = -20;
        kasi2.Angle = Angle.FromDegrees(-30);
        kasi2.Y = -40;

        AddCollisionHandler(paa, Osui);

        /*
        PhysicsObject Leggy1 = new PhysicsObject(10, 40);
        Add(Leggy1);

        PhysicsObject Leggy2 = new PhysicsObject(10, 40);
        Add(Leggy2);

        Leggy1.X = 10;
        Leggy1.Y = -90;
        Leggy2.X = -10;
        Leggy2.Y = -90;*/

        lisaaliitos(paa, Keho, new Vector(0, 0));
        lisaaliitos(kasi1, Keho, new Vector(10, -10));
        lisaaliitos(kasi2, Keho, new Vector(-10, -10));
        //lisaaliitos(Leggy1, Keho, new Vector(10, -60));
        //lisaaliitos(Leggy2, Keho, new Vector(10, -60));

        LuoPistelaskuri();

        Gravity = new Vector(0, -500);

        Surface maasto = Surface.CreateBottom(Level, 30, 50, 60, 10);
        Add(maasto);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Mouse.Listen(MouseButton.Left, ButtonState.Pressed, PoopyBlow, "lenna");
        Mouse.IsCursorVisible = true;
    }
    void lisaaliitos(PhysicsObject olio1, PhysicsObject olio2, Vector akselinpaikka)
    {
        AxleJoint liitos = new AxleJoint(olio1, olio2, akselinpaikka);
        olio1.CollisionIgnoreGroup = 1;
        olio2.CollisionIgnoreGroup = 1;
        Add(liitos);

        olio1.Mass = 0.5;
    }
    void PoopyBlow()
    {
        Explosion rajahdys = new Explosion(50);
        rajahdys.Position = Mouse.PositionOnScreen;
        Add(rajahdys);
    }
    void LuoKentta()
    {
        //ColorTileMap ruudut = ColorTileMap.FromLevelAsset("Kentta1");
        //ruudut.SetTileMethod(Color.Green, LuoPelaaja);
       // ruudut.Execute(20, 20);
    }
    void LuoPelaaja()
    {

    }

    void LuoPistelaskuri()
    {
        pisteLaskuri = new IntMeter(0);

        Label pisteNaytto = new Label();
        pisteNaytto.X = Screen.Left + 100;
        pisteNaytto.Y = Screen.Top - 100;
        pisteNaytto.TextColor = Color.Black;
        pisteNaytto.Color = Color.White;

        pisteNaytto.BindTo(pisteLaskuri);
        Add(pisteNaytto);
    }
    void Osui(PhysicsObject tormaaja, PhysicsObject kohde)
    {
        if (kohde == ala)
        {
            pisteLaskuri.Value += 1;
        }
        else if(kohde== vasen)
        {
         pisteLaskuri.Value += 5;
        }
        else if(kohde==oikea)
        {
         pisteLaskuri.Value += 5;
        }
        else if (kohde == yla)
        {
            pisteLaskuri.Value += 10;
        }
    }
}
