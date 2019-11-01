using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DnDBot.Services;
using System.Linq;

namespace DnDBot.Modules
{
    public class RollModule : ModuleBase<SocketCommandContext>
    {
        [Command("roll")]
        [Summary("Rolls dice")]
        public async Task RollASync([Summary("Type of dice to roll")] int dieSize)
        {
            await ReplyAsync(RollDice(dieSize).ToString());
        }

        [Command("roll")]
        [Summary("Rolls dice")]
        public async Task RollASync([Summary("Type of dice to roll")] int dieSize, [Summary("Number of dice to roll")] int dieNum)
        {
            List<int> rolls = new List<int>();
            for(int i = 0; i < dieNum; i++)
            {
                rolls.Add(RollDice(dieSize));
            }

            await ReplyAsync(FormatDiceRolls(rolls));
        }

        public int RollDice(int size)
        {
            Random rand = new Random();
            return rand.Next(size) + 1;
        }

        public string FormatDiceRolls(List<int> rolls)
        {
            string formatedRolls = "";
            for (int i = 0; i < rolls.Count; i++)
            {
                formatedRolls = formatedRolls + rolls[i].ToString();
                if (i < rolls.Count - 1)
                {
                    formatedRolls = formatedRolls + ",";
                }
            }

            return formatedRolls + " = " + rolls.Sum().ToString();
        }
    }
}
