/// <summary>
/// ''' The EndingGameController is responsible for managing the interactions at the end
/// ''' of a game.
/// ''' </summary>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SwinGameSDK;

static class EndingGameController
{

    /// <summary>
    ///     ''' Draw the end of the game screen, shows the win/lose state
    ///     ''' </summary>
    public static void DrawEndOfGame()
    {
        Rectangle toDraw = new Rectangle();
        string whatShouldIPrint;

        //UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
        //UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

        toDraw.X = 0;
        toDraw.Y = 250;
        toDraw.Width = SwinGame.ScreenWidth();
        toDraw.Height = SwinGame.ScreenHeight();

        if (GameController.HumanPlayer.IsDestroyed)
            whatShouldIPrint = "YOU LOSE!";
        else
            whatShouldIPrint = "-- WINNER --";


        //Jayden's Additions to the game - a replay button that takes you back to the deploy screen, and a continue button that either
        //takes you back to the main menu, or goes to the high scores if you got a high score.
        SwinGame.ClearScreen();
        SwinGame.DrawText(whatShouldIPrint, Color.Black, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw);
        SwinGame.DrawText("Play Again", Color.Black, GameResources.GameFont("Courier"), 325, 350);
        SwinGame.DrawText("Continue", Color.Black, GameResources.GameFont("Courier"), 420, 350);
        Rectangle play = new Rectangle();
        Rectangle cont = new Rectangle();
        play.X = 315;
        play.Y = 345;
        play.Width = 90;
        play.Height = 25;
        cont.X = 415;
        cont.Y = 345;
        cont.Width = 75;
        cont.Height = 25;
        SwinGame.DrawRectangle(Color.Black, play);
        SwinGame.DrawRectangle(Color.Black, cont);


    }

    /// <summary>
    ///     ''' Handle the input during the end of the game. Different buttons do different things
    ///     ''' </summary>
    public static void HandleEndOfGameInput()
    {
        Rectangle play = new Rectangle();
        Rectangle cont = new Rectangle();
        play.X = 315;
        play.Y = 345;
        play.Width = 90;
        play.Height = 25;
        cont.X = 415;
        cont.Y = 345;
        cont.Width = 75;
        cont.Height = 25;

        if (SwinGame.PointInRect(SwinGame.MousePosition(), play)) {
            SwinGame.FillRectangle(Color.Grey, play);
            if (SwinGame.MouseClicked(MouseButton.LeftButton)) {
                HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
                GameController.EndCurrentState();
                GameController.StartGame();
            }
        }
        if (SwinGame.PointInRect(SwinGame.MousePosition(), cont)) {
            SwinGame.FillRectangle(Color.Grey, cont);
            if (SwinGame.MouseClicked(MouseButton.LeftButton)) {
                HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
                GameController.EndCurrentState();
            }       
        }
        SwinGame.RefreshScreen();
    }
}
