using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public abstract class Symbol
    {
        public List<Symbol> ConstituentSymbols;

        public Symbol ()
        {

        }

        public Symbol (params object[] symbols)
        {
            List<Symbol> tmpSymbols = new List<Symbol> ();

            foreach (var symbol in symbols)
            {
                if (symbol is Symbol)
                {
                    tmpSymbols.Add (symbol as Symbol);
                }
                else if (symbol is IEnumerable<Symbol>)
                {
                    tmpSymbols.AddRange (symbol as IEnumerable<Symbol>);
                }
                else
                {
                    throw new ParseException ("Invalid symbol " + symbol.ToString ());
                }
            }

            ConstituentSymbols = tmpSymbols;
        }

        public override string ToString ()
        {

            return StringConcatenate (ConstituentSymbols.Select (x => x.ToString ()));
        }

        private string StringConcatenate (IEnumerable<string> strs)
        {
            StringBuilder strBuilder = new StringBuilder ();

            foreach (var str in strs)
            {
                strBuilder.Append (str);
            }

            return strBuilder.ToString ();
        }
    }
}