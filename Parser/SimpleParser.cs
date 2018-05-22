using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public class SimpleParser
    {
        public static Symbol ParserFormula (List<DecafToken> tokens)
        {
            var symbols = tokens.Select (x => new TerminalSymbol (x));

            if (symbols.Any ())
            {
                Console.WriteLine ("Terminal Symbols");
                Console.WriteLine ("================");

                foreach (var terminal in symbols)
                {
                    Console.WriteLine ("{0} ({1})", terminal.TokenType, terminal.LineInfo);
                }

                Console.WriteLine ();
            }

            ProgramSymbol programSymbol = new ProgramSymbol (symbols);

            return programSymbol;
        }
    }
}