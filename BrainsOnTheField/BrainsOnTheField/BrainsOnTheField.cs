using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class BrainsOnTheField : PhysicsGame
{
    PlatformCharacter pelaaja;
    PlatformCharacter Zombie1;

    void LiikutaPelaajaaVasemmalle()
    {
        pelaaja.Walk(-300);
    }
    void LiikutaPelaajaaOikealle() 
    {
        pelaaja.Walk(300);
    }
    void PelaajaHyppaa()
    {
        pelaaja.Jump(400);
    }
    void PelaajaLyo()
    { 
    }
    void luoukko()
    {
        pelaaja = new PlatformCharacter(50, 100);
        Add(pelaaja);
        Image ukko = LoadImage("Ninja1");
        pelaaja.Image = ukko;
    }
    void LuoZombie1()
    {
        Zombie1 = new PlatformCharacter(50, 100);
        Add(Zombie1);
        Image ukko = LoadImage("Zombie1");
        Zombie1.Image = ukko;
        Zombie1.X = 100;
        FollowerBrain aivot = new FollowerBrain(pelaaja);
        aivot.Active = true;
        aivot.Speed = 300;
        aivot.DistanceFar = 600;
        aivot.DistanceClose = 1;
        aivot.StopWhenTargetClose = true;
        Zombie1.Brain = aivot;
    }
    public override void Begin()
    {
        Surface alaReuna = Surface.CreateBottom(Level);
        Add(alaReuna);

        alaReuna.Color = Color.Gray;

       Surface vasenReuna = Surface.CreateLeft(Level);
       Add(vasenReuna);

        vasenReuna.Color = Color.Gray;

       Surface oikeaReuna = Surface.CreateRight(Level);
       Add(oikeaReuna);

        oikeaReuna.Color = Color.Gray;

       Surface ylaReuna = Surface.CreateTop(Level);
       Add(ylaReuna);

       ylaReuna.Color = Color.Gray;

       Level.Background.CreateStars();

       luoukko();
       Gravity = new Vector(0, -1000);
       LuoZombie1();
       Timer ajastin = new Timer();
       ajastin.Interval = 5.0;
       ajastin.Timeout += LuoZombie1;
       ajastin.Start();
        

       Keyboard.Listen(Key.Left, ButtonState.Down,
 LiikutaPelaajaaVasemmalle, "Pelaaja liikkuu vasemmalle");
       Keyboard.Listen(Key.Right, ButtonState.Down,
 LiikutaPelaajaaOikealle, "Pelaaja liikkuu oikealle");
       Keyboard.Listen(Key.Up, ButtonState.Down,
PelaajaHyppaa, "Pelaaja liikkuu hyppaa");
       Keyboard.Listen(Key.Q, ButtonState.Down,
PelaajaLyo, "Pelaaja liikkuu Lyo");

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
}
