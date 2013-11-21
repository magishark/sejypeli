using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Brains_on_the_Field : PhysicsGame
{
    void luoukko()
    {
        PlatformCharacter pelaaja = new PlatformCharacter(50, 100);
        Add(pelaaja);
        Image ukko = LoadImage("Ninja1");
        pelaaja.Image = ukko;
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

        // TODO: Kirjoita ohjelmakoodisi tähän

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
}
