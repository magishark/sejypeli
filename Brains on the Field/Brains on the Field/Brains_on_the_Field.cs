using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Brains_on_the_Field : PhysicsGame
{
    public override void Begin()
    {
        Surface alaReuna = Surface.CreateBottom(Level);
        Add(alaReuna);

        alaReuna.Color = Color.Black;

       Surface vasenReuna = Surface.CreateLeft(Level);
       Add(vasenReuna);

        vasenReuna.Color = Color.Black;

       Surface oikeaReuna = Surface.CreateRight(Level);
       Add(oikeaReuna);

        oikeaReuna.Color = Color.Black;

       Surface ylaReuna = Surface.CreateTop(Level);
       Add(ylaReuna);

       ylaReuna.Color = Color.Black;

        // TODO: Kirjoita ohjelmakoodisi tähän

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
}
