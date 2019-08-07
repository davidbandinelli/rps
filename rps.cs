using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS {
    class Program {
        static void Main(string[] args) {
            string test3_1 = RPSHelper.NumToLiteral(1001);
            string test3_2 = RPSHelper.NumToLiteral(10001);
            string test3_3 = RPSHelper.NumToLiteral(100001);
            string test3_4 = RPSHelper.NumToLiteral(1000001);
            string test3_5 = RPSHelper.NumToLiteral(10000001);
            string test3_6 = RPSHelper.NumToLiteral(100000001);
            string test3_7 = RPSHelper.NumToLiteral(1000000001);
            string test3_8 = RPSHelper.NumToLiteral(10000000001);
            string test3_9 = RPSHelper.NumToLiteral(100000000001);
            string test3_10 = RPSHelper.NumToLiteral(99099099099);

            string test0_3 = RPSHelper.NumToLiteral(63489505);
            string test0_4 = RPSHelper.NumToLiteral(49063489505);

            string test0 = RPSHelper.NumToLiteral(21);
            string test0_1 = RPSHelper.NumToLiteral(121);
            string test0_5 = RPSHelper.NumToLiteral(111);
            string test0_6 = RPSHelper.NumToLiteral(131);
            string test0_7 = RPSHelper.NumToLiteral(181181181);
            string test0_2 = RPSHelper.NumToLiteral(99);
            string test1 = RPSHelper.NumToLiteral(14583);
            string test2 = RPSHelper.NumToLiteral(100);
            string test2_1 = RPSHelper.NumToLiteral(101);
            string test3 = RPSHelper.NumToLiteral(1000);
            string test3_0 = RPSHelper.NumToLiteral(99021);
            string test4 = RPSHelper.NumToLiteral(10000);
            string test5 = RPSHelper.NumToLiteral(100000);
            string test6 = RPSHelper.NumToLiteral(1000000);
            string test7 = RPSHelper.NumToLiteral(10000000);
            string test8 = RPSHelper.NumToLiteral(100000000);
            string test9 = RPSHelper.NumToLiteral(1000000000);
            string test10 = RPSHelper.NumToLiteral(999000000000);
            string test11 = RPSHelper.NumToLiteral(999001001001);
        }
    }

    public static class RPSHelper {
        private static Dictionary<long, string> dicNumToLit = new Dictionary<long, string>();

        public static string NumToLiteral(long numero) {
            string risultato = string.Empty;
            string numeroString = numero.ToString();
            int lenNum = numeroString.Length;
            int zeroToAdd = 3 - (lenNum % 3);
            if (zeroToAdd > 0) {
                for (int j = 0; j < zeroToAdd; j++) {
                    numeroString = "0" + numeroString;
                }
            }
            InizializzaDictionary();
            if (numero < 20) {
                risultato = dicNumToLit[numero];
                return risultato;
            }
            if (numero == 100 || numero == 1000 || numero == 10000 || numero == 100000 || numero == 1000000 || numero == 10000000 || numero == 100000000
                || numero == 1000000000 || numero == 10000000000 || numero == 100000000000) {
                risultato = dicNumToLit[numero];
                return risultato;
            }
            int iterazioni = lenNum % 3 == 0 ? ((int)(lenNum / 3))  : ((int)(lenNum / 3)) + 1;
            
            for (int k = 1; k <= iterazioni; k++) {
                string blocco = string.Empty;
                blocco = numeroString.Substring((numeroString.Length - 1) - ((k * 3) - 1), 3);
                string tmpRisult = DecodBloccoCifre(blocco, k);
                //tmpRisult = tmpRisult.Replace("unomila", "mille");
                //tmpRisult = tmpRisult.Replace("unomilioni", "unmilione");
                //tmpRisult = tmpRisult.Replace("unomiliardi", "unmiliardo");
                tmpRisult = tmpRisult.Replace("ventiuno", "ventuno");
                tmpRisult = tmpRisult.Replace("trentauno", "trentuno");
                tmpRisult = tmpRisult.Replace("trentauno", "trentuno");
                tmpRisult = tmpRisult.Replace("quarantauno", "quarantuno");
                tmpRisult = tmpRisult.Replace("cinquantauno", "cinquantuno");
                tmpRisult = tmpRisult.Replace("sessantauno", "sessantuno");
                tmpRisult = tmpRisult.Replace("settantauno", "settantuno");
                tmpRisult = tmpRisult.Replace("ottantauno", "ottantuno");
                tmpRisult = tmpRisult.Replace("novantauno", "novantuno");
                risultato = tmpRisult + risultato;
            }
            return risultato;
        }

        public static string DecodBloccoCifre(string blocco, int iterazione) {
            string risultato = string.Empty;
            // elimina 0 non significativi
            blocco = blocco.TrimStart('0');
            if (blocco.Length == 0) {
                return string.Empty;
            }
            System.Int64 numeroInt = System.Int64.Parse(blocco);
            string suffisso = string.Empty, unita = string.Empty;
            int lenBlocco = blocco.Length;
            if (lenBlocco == 3)
                suffisso = "cento";
            else
                suffisso = string.Empty;
            switch (iterazione) {
                case 1:
                    unita = string.Empty;
                    break;
                case 2:
                    unita = "mila";
                    break;
                case 3:
                    unita = "milioni";
                    break;
                case 4:
                    unita = "miliardi";
                    break;
            }
            if (lenBlocco == 3) {
                int digit = System.Int32.Parse(blocco.Substring(0, 1));
                string literal = string.Empty;
                if (digit == 1) {
                    //literal = dicNumToLit[digit];
                    risultato = suffisso;
                } else {
                    literal = dicNumToLit[digit];
                    risultato = literal + suffisso;
                }
                digit = System.Int32.Parse(blocco.Substring(1, 2));
                if (digit > 0) {
                    if (digit <= 19) {
                        literal = dicNumToLit[digit];
                        risultato = risultato + literal;
                    } else {
                        string digitTmp = blocco.Substring(1, 1);
                        digitTmp = digitTmp + "0";
                        literal = dicNumToLit[System.Int32.Parse(digitTmp)];
                        risultato = risultato + literal;
                        digitTmp = blocco.Substring(2, 1);
                        literal = dicNumToLit[System.Int32.Parse(digitTmp)];
                        risultato = risultato + literal;
                    }
                }
            }
            if (lenBlocco == 2) {
                int digit = System.Int32.Parse(blocco.Substring(0, 2));
                if (digit <= 19) {
                    string literal = dicNumToLit[digit];
                    risultato = risultato + literal + suffisso;
                } else {
                    string digitTmp = blocco.Substring(0, 1);
                    digitTmp = digitTmp + "0";
                    string literal = dicNumToLit[System.Int32.Parse(digitTmp)];
                    risultato = risultato + literal;
                    digitTmp = blocco.Substring(1, 1);
                    literal = dicNumToLit[System.Int32.Parse(digitTmp)];
                    risultato = risultato + literal + suffisso;
                }
            }
            if (lenBlocco == 1) {
               string digitTmp = blocco.Substring(0, 1);
               int digit = System.Int32.Parse(digitTmp);
               /*
               if (digit == 1 && iterazione > 1) {
                   risultato = unita;
               } else {
                   string literal = dicNumToLit[digit];
                   risultato = risultato + literal + suffisso;
               }
               */
               string literal = dicNumToLit[digit];
               risultato = risultato + literal + suffisso;
            }
            if (risultato.Length > 0) {
                return risultato + unita;
            } else
                return risultato;
        }

        public static void InizializzaDictionary() {
            if (dicNumToLit.Count == 0) {
                dicNumToLit.Add(0, "zero");
                dicNumToLit.Add(1, "uno");
                dicNumToLit.Add(2, "due");
                dicNumToLit.Add(3, "tre");
                dicNumToLit.Add(4, "quattro");
                dicNumToLit.Add(5, "cinque");
                dicNumToLit.Add(6, "sei");
                dicNumToLit.Add(7, "sette");
                dicNumToLit.Add(8, "otto");
                dicNumToLit.Add(9, "nove");
                dicNumToLit.Add(10, "dieci");
                dicNumToLit.Add(11, "undici");
                dicNumToLit.Add(12, "dodici");
                dicNumToLit.Add(13, "tredici");
                dicNumToLit.Add(14, "quattordici");
                dicNumToLit.Add(15, "quindici");
                dicNumToLit.Add(16, "sedici");
                dicNumToLit.Add(17, "diciassette");
                dicNumToLit.Add(18, "diciotto");
                dicNumToLit.Add(19, "diciannove");
                dicNumToLit.Add(20, "venti");
                dicNumToLit.Add(30, "trenta");
                dicNumToLit.Add(40, "quaranta");
                dicNumToLit.Add(50, "cinquanta");
                dicNumToLit.Add(60, "sessanta");
                dicNumToLit.Add(70, "settanta");
                dicNumToLit.Add(80, "ottanta");
                dicNumToLit.Add(90, "novanta");
                dicNumToLit.Add(100, "cento");
                dicNumToLit.Add(1000, "mille");
                dicNumToLit.Add(10000, "diecimila");
                dicNumToLit.Add(100000, "centomila");
                dicNumToLit.Add(1000000, "unmilione");
                dicNumToLit.Add(10000000, "diecimilioni");
                dicNumToLit.Add(100000000, "centomilioni");
                dicNumToLit.Add(1000000000, "unmiliardo");
                dicNumToLit.Add(10000000000, "diecimiliardi");
                dicNumToLit.Add(100000000000, "centomiliardi");
            }
        }
    }
}
