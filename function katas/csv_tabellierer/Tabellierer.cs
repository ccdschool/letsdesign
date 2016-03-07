using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csv_tabellierer
{

	class Tabellierer {
		public IEnumerable<string> Formatieren(IEnumerable<Datensatz> datensätze) {
			var spaltenbreiten = Spaltenbreiten_bestimmen (datensätze);
			var tabellenzeilen = Tabellenzeilen_bauen (datensätze, spaltenbreiten);
			var unterstreichung = Unterstreichung_bauen (spaltenbreiten);
			return Unterstreichung_einfügen (tabellenzeilen, unterstreichung);
		}


		int[] Spaltenbreiten_bestimmen(IEnumerable<Datensatz> datensätze) {
			var spaltenbreiten = new int[datensätze.First().Werte.Length];
			for (var iSpalte = 0; iSpalte < spaltenbreiten.Length; iSpalte++) {
				spaltenbreiten[iSpalte] = datensätze.Select (ds => ds.Werte [iSpalte].Length).Max ();
			}
			return spaltenbreiten;
		}

		IEnumerable<string> Tabellenzeilen_bauen(IEnumerable<Datensatz> datensätze, int[] spaltenbreiten) {
			return datensätze.Select (ds => {
				var werteAufgefüllt = ds.Werte.Select((w,i) => w.PadRight(spaltenbreiten[i]));
				return string.Join("|", werteAufgefüllt) + "|";
			});
		}

		string Unterstreichung_bauen(int[] spaltenbreiten) {
			var spaltenUnterstriche = spaltenbreiten.Select (sb => "".PadLeft(sb, '-')); // "-", "--", "---"
			return string.Join("+", spaltenUnterstriche) + "+";
		}

		IEnumerable<string> Unterstreichung_einfügen(IEnumerable<string> tabellenzeilen, string unterstreichung) {
			var tabListe = tabellenzeilen.ToList ();
			tabListe.Insert (1, unterstreichung);
			return tabListe;
		}

	}
	
}
