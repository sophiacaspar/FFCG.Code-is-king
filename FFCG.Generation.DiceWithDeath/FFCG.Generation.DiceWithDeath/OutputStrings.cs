using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Generation.DiceWithDeath
{
    class OutputStrings
    {
        public string newGame = "************************************************************************************************************" +
                                "\nWelcome to a new game of Dice with Death! " +
                                "\nIn this game, you will have to guess if the next dice roll will be higher or lower than the previous roll." +
                                "\nQuit at anytime by typing the letter q \n" +
                                "************************************************************************************************************\n";
        public string yourDiceRoll = "This is your current dice roll: \n";
        public string newDiceRoll = "\nThe new dice roll was: \n";
        public string correctGuess = "Congratulations! Your guess was correct! Well done!\n" +
                                    "Your score is increased by one.\n" +
                                    "Now you get to guess again!\n";
        public string wrongInput = "Wrong input, try again by only typing either the letter h or the letter l";
        public string death = 
                                "              ...\n" +
                                "             ;::::;\n" +
                                "           ;::::; :;\n" +
                                "         ;:::::\'   :;\n" +
                                "        ;:::::;     ;.\n" +
                                "       ,:::::\'       ;           OOO\\ \n" +
                                "       ::::::;       ;          OOOOO\\ \n" +
                                "       ;:::::;       ;         OOOOOOOO \n" +
                                "      ,;::::::;     ;\'         / OOOOOOO \n" +
                                "    ;:::::::::`. ,,,;.        /  / DOOOOOO \n" +
                                "  .\';:::::::::::::::::;,     /  /     DOOOO \n" +
                                " ,::::::;::::::;;;;::::;,   /  /        DOOO \n" +
                                ";`::::::`\'::::::;;;::::: ,#/  /          DOOO \n" +
                                ":`:::::::`;::::::;;::: ;::#  /            DOOO \n" +
                                "::`:::::::`;:::::::: ;::::# /              DOO \n" +
                                "`:`:::::::`;:::::: ;::::::#/               DOO \n" +
                                " :::`:::::::`;; ;:::::::::##                OO \n" +
                                " ::::`:::::::`;::::::::;:::#                OO \n" +
                                "`:::::`::::::::::::;\'`:;::#                O \n" +
                                "  `:::::`::::::::;\' /  / `:# \n" +
                                "   ::::::`:::::;\'  /  /   `# \n";


        public string GameOver(int finalScore)
        {
            string gameOver = "           GAME OVER\n" +
                              $"        Final score: {finalScore}\n";

            return gameOver;

    }

        public string Instructions(int diceValue)
        {
            return $"Guess if the next dice roll will be higher (h) or lower (l) than {diceValue}. \nType the letter h to guess higher or type the letter l to guess lower.";
        }

        public string RollDice(int diceValue)
        {
            if (diceValue == 1) { return "________\n|       |\n|   o   |\n|       |\n|_______|\n"; }
            else if (diceValue == 2) { return "________\n|       |\n| o   o |\n|       |\n|_______|\n"; }
            else if (diceValue == 3) { return "________\n|     o |\n|   o   |\n| o     |\n|_______|\n"; }
            else if (diceValue == 4) { return "________\n| o   o |\n|       |\n| o   o |\n|_______|\n"; }
            else if (diceValue == 5) { return "________\n| o   o |\n|   o   |\n| o   o |\n|_______|\n"; }
            else if (diceValue == 6) { return "________\n| o   o |\n| o   o |\n| o   o |\n|_______|\n"; }
            else { return ""; }

        }
    }
}
